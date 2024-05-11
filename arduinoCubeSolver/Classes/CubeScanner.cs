using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arduinoCubeSolver.Classes
{
    public class CubeScanner
    {
        private VideoCapture _capture;
        private Rectangle[] _areasBeingScannedForCubelets;
        private RubiksCube _cubeBeingScanned;
        private Calibration _calibration;
        private readonly object _cameraLock = new object();

        public bool IsCubeFinishedBeingScanned 
        {
            private set;
            get;
        }
        public bool IsCalibrated
        { 
            get => this._calibration.IsCalibrated;
        }

        public RubiksCube CubeBeingScanned 
        {
            private set
            {
                this._cubeBeingScanned = value;
            }
            get
            {
                if (!this.IsCubeFinishedBeingScanned)
                    throw new Exception("The cube hasen't been scanned complitely");
                return this._cubeBeingScanned;
            }
        }
        public int CubesTileSize { get; set; }
        public int CubeDistance { get; set; }  

        // PUBLIC METHODS

        public CubeScanner(int cameraIndex)
        {
            this._cubeBeingScanned = new RubiksCube();
            this.IsCubeFinishedBeingScanned = false;
            this._capture = new VideoCapture(cameraIndex);
            this.CubesTileSize = 30;
            this.CubeDistance = 100;
            this._areasBeingScannedForCubelets = new Rectangle[RubiksCubeFace.CubeletCount];
            this._calibration = new Calibration();
        }

        public void ShowFrameInCameraViewPort(ref PictureBox cameraFeedViewPort)
        {
            lock(this._cameraLock) 
            {
                using (Mat frame = new Mat())
                {
                    this._capture.Read(frame);
                    this.SetAareasBeingScannedForCubelets(frame.Width, frame.Height);

                    foreach (Rectangle rectangle in this._areasBeingScannedForCubelets)
                        CvInvoke.Rectangle(frame, rectangle, new Bgr(Color.Red).MCvScalar, 2);

                    Bitmap bitmap = frame.ToBitmap();
                    cameraFeedViewPort.Image?.Dispose();
                    cameraFeedViewPort.Image = bitmap;
                }
            }
        }

        public void CalibrateNextColor()
        {
            lock(this._cameraLock) 
            {
                using (Mat frame = new Mat())
                {
                    this._capture.Read(frame);
                    const int CenterCubelet = 4;
                    this._calibration.CalibrateNextColor(frame, this._areasBeingScannedForCubelets[CenterCubelet]);
                }
            }
        }

        public void ScanNextFace()
        {
            if (this.IsCubeFinishedBeingScanned)
                throw new Exception("There are no more faces to scan");

            using (Mat frame = new Mat())
            {
                char[] cubeletsChar = new char[RubiksCubeFace.CubeletCount];
                this._capture.Read(frame);
                for (int i = 0; i < RubiksCubeFace.CubeletCount; i++)
                {
                    Rectangle regionOfInterest = this._areasBeingScannedForCubelets[i];
                    using (Mat cubeletMat = new Mat(frame, regionOfInterest))
                    {
                        Calibration.ApplyWhiteBalance(cubeletMat);
                        cubeletsChar[i] = this._calibration.GetClosestColorFromCalibration(GetAverageColorFromMat(cubeletMat));
                    }
                }
                _cubeBeingScanned.InitializeNextFace(cubeletsChar);
                if (this._cubeBeingScanned.IsInitialized)
                    this.IsCubeFinishedBeingScanned = true;
            }
        }

        public void ReScanCube()
        {
            this._cubeBeingScanned = new RubiksCube();
            this.IsCubeFinishedBeingScanned = false;
        }

        public void ChangeCamera(int newCameraIndex)
        {
            lock (this._cameraLock)
            {
                if (!CameraUtils.IsCameraIndexValid(newCameraIndex))
                {
                    MessageBox.Show("Error: la camara seleccionada no existe");
                    return;
                }
                this._capture?.Dispose();
                this._capture = new VideoCapture(newCameraIndex);
            }
        }




        // PRIVATE METHODS
        private void SetAareasBeingScannedForCubelets(int frameWidth, int frameHeight)
        {
            int halfTileSize = CubesTileSize / 2;
            int centerX = frameWidth / 2;
            int centerY = frameHeight / 2;

            this._areasBeingScannedForCubelets = new Rectangle[]
            {
                new Rectangle(centerX - CubeDistance - halfTileSize, centerY - CubeDistance - halfTileSize, CubesTileSize, CubesTileSize), // LeftCeil
                new Rectangle(centerX - halfTileSize, centerY - CubeDistance - halfTileSize, CubesTileSize, CubesTileSize),                // CenterCeil
                new Rectangle(centerX + CubeDistance - halfTileSize, centerY - CubeDistance - halfTileSize, CubesTileSize, CubesTileSize), // RightCeil
                new Rectangle(centerX - CubeDistance - halfTileSize, centerY - halfTileSize, CubesTileSize, CubesTileSize),                // LeftMiddle
                new Rectangle(centerX - halfTileSize, centerY - halfTileSize, CubesTileSize, CubesTileSize),                               // CenterTile
                new Rectangle(centerX + CubeDistance - halfTileSize, centerY - halfTileSize, CubesTileSize, CubesTileSize),                // RightMiddle
                new Rectangle(centerX - CubeDistance - halfTileSize, centerY + CubeDistance - halfTileSize, CubesTileSize, CubesTileSize), // LeftBottom
                new Rectangle(centerX - halfTileSize, centerY + CubeDistance - halfTileSize, CubesTileSize, CubesTileSize),                // CenterBottom
                new Rectangle(centerX + CubeDistance - halfTileSize, centerY + CubeDistance - halfTileSize, CubesTileSize, CubesTileSize)  // RightBottom
            };
        }

        private Color GetAverageColorFromMat(Mat mat)
        {
            MCvScalar mean = CvInvoke.Mean(mat);
            return Color.FromArgb((int)mean.V2, (int)mean.V1, (int)mean.V0);
        }
    }
}

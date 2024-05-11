using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arduinoCubeSolver.Classes
{
    public class Calibration
    {
        private readonly Queue<char> _colorOrder = new Queue<char>(new[] { 'g', 'o', 'b', 'r', 'y', 'w' });
        private Dictionary<char, Color> _averageColors;

        public Calibration()
        {
            this._averageColors = new Dictionary<char, Color>(RubiksCube.FacesCount);
        }

        public bool IsCalibrated => this._averageColors.Count == RubiksCube.FacesCount;

        public void CalibrateNextColor(Mat image, Rectangle centerCubeletArea)
        {
            if (this._colorOrder.Count == 0)
                throw new InvalidOperationException("All colors have already been calibrated.");

            char currentColor = this._colorOrder.Dequeue();
            using (Mat centerCubeletImage = new Mat(image, centerCubeletArea))
            {
                Color avgColor = GetAverageColorForCurrentColor(centerCubeletImage);
                this._averageColors[currentColor] = avgColor;
            }
        }

        public Dictionary<char, Color> GetAverageColors()
        {
            if (!this.IsCalibrated)
                throw new InvalidOperationException("Calibration is not complete.");

            return new Dictionary<char, Color>(this._averageColors);
        }

        public char GetClosestColorFromCalibration(Color inputColor)
        {
            if (!this.IsCalibrated)
                throw new InvalidOperationException("Calibration is not complete.");

            double minDistance = double.MaxValue;
            char closestColor = ' ';

            foreach (var calibratedColor in this._averageColors)
            {
                double distance = Math.Sqrt(Math.Pow(inputColor.R - calibratedColor.Value.R, 2) +
                                            Math.Pow(inputColor.G - calibratedColor.Value.G, 2) +
                                            Math.Pow(inputColor.B - calibratedColor.Value.B, 2));

                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestColor = calibratedColor.Key;
                }
            }

            return closestColor;
        }

        static public Mat ApplyWhiteBalance(Mat inputImage)
        {
            //// This method should be renamed to SaveImageToDesktop
            //string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //string fileName = "WhiteBalancedImage_" + DateTime.Now.ToString("yyyyMMdd_HHmmssfff") + ".png";
            //string filePath = Path.Combine(desktopPath, fileName);
            //inputImage.Save(filePath);
            //////////////////////////////////////////////////////////////////////

            return inputImage;
        }



        // PRIVATE METHODS
        private Color GetAverageColorForCurrentColor(Mat centerCubeletImage)
        {
            Mat whiteBalancedImage = ApplyWhiteBalance(centerCubeletImage);

            MCvScalar mean = CvInvoke.Mean(whiteBalancedImage);
            Color averageColor = Color.FromArgb((int)mean.V2, (int)mean.V1, (int)mean.V0);

            whiteBalancedImage.Dispose();
            return averageColor;
        }

    }

}

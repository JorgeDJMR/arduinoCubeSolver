using arduinoCubeSolver.Arduino;
using arduinoCubeSolver.Classes;
using Emgu.CV;
using Emgu.CV.DepthAI;
using Emgu.CV.Structure;
using System.IO.Ports;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;



namespace arduinoCubeSolver
{
    public partial class MainForm : Form
    {
        private readonly CubeScanner _cubeScanner;
        private readonly ArduinoController _arduinoController;
        private CubeFaceGroupBox[] _faceGroupBox;
        SerialPort puertoSalida = new SerialPort();
        public string numeroPuertoCOM;

        public MainForm(CubeScanner cubeScanner, ArduinoController arduinoController)
        {
            InitializeComponent();
            this._cubeScanner = cubeScanner;
            this._arduinoController = arduinoController;
            this._faceGroupBox = new CubeFaceGroupBox[RubiksCube.FacesCount];
            this.InitializeFaceGruopBoxes();
            this.InitializeComboBoxSelectedCamera();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void timerForWebCam_Tick(object sender, EventArgs e)
        {
            this._cubeScanner.ShowFrameInCameraViewPort(ref this.ptBoxCameraViewPort);
        }

        private void btnAumentarDistancia_Click(object sender, EventArgs e)
        {
            this._cubeScanner.CubeDistance += 5;
        }

        private void btnDisminuirDistancia_Click(object sender, EventArgs e)
        {
            this._cubeScanner.CubeDistance -= 5;
        }

        private void btnAumentarTamaño_Click(object sender, EventArgs e)
        {
            this._cubeScanner.CubesTileSize += 5;
        }

        private void btnDecrementarTamaño_Click(object sender, EventArgs e)
        {
            this._cubeScanner.CubesTileSize -= 5;
        }

        private void btnCalibrate_Click(object sender, EventArgs e)
        {

            this._arduinoController.PuertoCOM = cbListaCOM.Text.ToString();
            // btnCalibrate.Disable
            this._arduinoController.CalibrateCamera();
            if (this._cubeScanner.IsCalibrated)
            {
                // This souldnt be in an if, as after CalibrateCamera execution, IsCalibrated == true
                this.btnCalibrate.Enabled = false;
                this.btnScanCube.Enabled = true;
            }
        }

        private void btnScanCube_Click(object sender, EventArgs e)
        {
            if (this.btnScanCube.Text == "Re-escanear cubo")
            {
                this.btnStartSolving.Enabled = false;
                this._cubeScanner.ReScanCube();
                this.btnScanCube.Text = "Escanear cubo";
                return;
            }
            this.btnScanCube.Enabled = false;
            this._arduinoController.ScanCubeColors();
            if (_cubeScanner.IsCubeFinishedBeingScanned)
            {
                // This shouldt be in an if statement, after ScanCubeColors executon, IsCubeFinishedBeingScanned == true
                this.btnScanCube.Text = "Re-escanear cubo";
                this.DrawScannedCubeToFaceGroupBoxes();
                this.btnStartSolving.Enabled = true;
            }
            this.btnScanCube.Enabled = true;
        }

        private void btnStartSolving_Click(object sender, EventArgs e)
        {

            this.btnScanCube.Enabled = false;
            CubeXdotNET.FridrichSolver fridrichSolver = new CubeXdotNET.FridrichSolver(this._cubeScanner.CubeBeingScanned.GetCubeString());
            fridrichSolver.Solve();
            this.txtBoxSolution.Text = fridrichSolver.Solution;
            this.labelNumMoves.Text = "Numero de movimientos: " + fridrichSolver.Length;

            this._arduinoController.SolveCube(fridrichSolver.Solution);
            this.btnScanCube.Enabled = true;

            string Datos = txtBoxSolution.Text;
            string[] CadenaCompleta = Datos.Split(' ');



            //////////Prubas
            string numeroPuertoCOM = (string)this.cbListaCOM.SelectedItem;

            if (puertoSalida.IsOpen)
            {
                puertoSalida.Close();
            }

            if (puertoSalida.PortName != numeroPuertoCOM)
            {
                puertoSalida.PortName = numeroPuertoCOM;
            }

            try
            {
                puertoSalida.Open();
                string[] palabras = txtBoxSolution.Text.Split(' '); // Divide la cadena en palabras separadas
                foreach (string palabra in palabras)
                {
                    puertoSalida.Write(palabra);
                    puertoSalida.Write(" "); // envía un espacio para separar cada palabra
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo abrir el puerto {numeroPuertoCOM}: {ex.Message} ");
                throw;
            }



            ///////////////////////////////////
        }

        private void DrawScannedCubeToFaceGroupBoxes()
        {
            int currentFace = 0;
            foreach (RubiksCubeFace face in this._cubeScanner.CubeBeingScanned)
            {
                this._faceGroupBox[currentFace].SetCubeletColors(face.Cubelets);
                currentFace++;
            }
        }

        private void InitializeFaceGruopBoxes()
        {
            char[] cubeColors = { 'g', 'o', 'b', 'r', 'y', 'w' };
            for (int i = 0; i < RubiksCube.FacesCount; i++)
                _faceGroupBox[i] = new CubeFaceGroupBox(cubeColors[i]);

            const int marginBetweenFaces = 10;
            const int groupBoxWidth = CubeFaceGroupBox.GroupBoxWidth;
            const int groupBoxHeight = CubeFaceGroupBox.GroupBoxHeight;

            _faceGroupBox[0].Location = new Point(1100, 295); // Center
            _faceGroupBox[1].Location = new Point(1100 + groupBoxWidth + marginBetweenFaces, 295); // Right
            _faceGroupBox[2].Location = new Point(1100 + groupBoxWidth + marginBetweenFaces + groupBoxWidth + marginBetweenFaces, 295); // Rightmost
            _faceGroupBox[3].Location = new Point(1100 - groupBoxWidth - marginBetweenFaces, 295); // Left
            _faceGroupBox[4].Location = new Point(1100, 295 - groupBoxHeight - marginBetweenFaces); // Up
            _faceGroupBox[5].Location = new Point(1100, 295 + groupBoxHeight + marginBetweenFaces); // Down

            foreach (var faceGroupBox in _faceGroupBox)
            {
                this.Controls.Add(faceGroupBox);
            }

        }

        private void comboBoxSelectedCamera_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cameraIndex = this.comboBoxSelectedCamera.SelectedIndex;
            if (!CameraUtils.IsCameraIndexValid(cameraIndex))
            {
                MessageBox.Show("Error: la camara seleccionada no existe");
                return;
            }
            this._cubeScanner.ChangeCamera(cameraIndex);
        }

        private void InitializeComboBoxSelectedCamera()
        {
            List<string> listOfCameraNames = CameraUtils.GetAvailableCameraNames();
            foreach (var camera in listOfCameraNames)
                this.comboBoxSelectedCamera.Items.Add(camera);
            this.comboBoxSelectedCamera.SelectedIndex = 0;
        }

        private void IniciarPorts()
        {
            var puertosCOM = SerialPort.GetPortNames();

            this.cbListaCOM.Items.Clear();
            this.cbListaCOM.Items.AddRange(puertosCOM);

            //////////////////////////////////////////////////////////////////////
            //En caso de querer mostrar o regresar cosas desde el arduino ide 
            //puertoSalida.DataReceived += new SerialDataReceivedEventHandler();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            IniciarPorts();
        }

        private void txtBoxSolution_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            string numeroPuertoCOM = (string)this.cbListaCOM.SelectedItem;

            if (puertoSalida.IsOpen)
            {
                puertoSalida.Close();
            }

            if (puertoSalida.PortName != numeroPuertoCOM)
            {
                puertoSalida.PortName = numeroPuertoCOM;
            }

            try
            {
                puertoSalida.Open();

                puertoSalida.WriteLine("1");
                puertoSalida.Close();

                Console.WriteLine("Se ha enviado el valor '1' al Arduino.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo abrir el puerto {numeroPuertoCOM}: {ex.Message} ");
                throw;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            string numeroPuertoCOM = (string)this.cbListaCOM.SelectedItem;

            if (puertoSalida.IsOpen)
            {
                puertoSalida.Close();
            }

            if (puertoSalida.PortName != numeroPuertoCOM)
            {
                puertoSalida.PortName = numeroPuertoCOM;
            }

            try
            {
                puertoSalida.Open();

                puertoSalida.WriteLine("2");
                puertoSalida.Close();

                Console.WriteLine("Se ha enviado el valor '1' al Arduino.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo abrir el puerto {numeroPuertoCOM}: {ex.Message} ");
                throw;
            }
        }
    }
}

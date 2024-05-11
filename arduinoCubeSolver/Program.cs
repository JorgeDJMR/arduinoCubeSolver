using arduinoCubeSolver.Arduino;
using arduinoCubeSolver.Classes;

namespace arduinoCubeSolver
{
    internal static class Program
    {
        public const int DefaultCamera = 0;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            CubeScanner cubeScanner = new CubeScanner(DefaultCamera);
            ArduinoController arduinoController = new ArduinoController(cubeScanner);
            MainForm mainForm = new MainForm(cubeScanner, arduinoController);
            Application.Run(mainForm);
        }
    }
}
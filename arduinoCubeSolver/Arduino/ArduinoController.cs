using arduinoCubeSolver.Classes;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arduinoCubeSolver.Arduino
{
    public class ArduinoController
    {
        private readonly CubeScanner _cubeScanner;

        public ArduinoController(CubeScanner cubeScanner)
        {
            this._cubeScanner = cubeScanner;
        }
        public int cont = 0;
        public string PuertoCOM; 


        public void CalibrateCamera()
        {
            
            // for(int i = 1; i <= RubiksCube.FacesCount; i++)
            SerialPort puertoSalida = new SerialPort(PuertoCOM);
            string[] movements = { "V", "N", "A", "R", "Y", "B" };
            
            this._cubeScanner.CalibrateNextColor();

            try
            {
                if (!puertoSalida.IsOpen)
                {
                    puertoSalida.Open();
                }

                if (puertoSalida.IsOpen)
                {
                    if (cont == 6)
                    {
                        cont = 0;
                    }
                    puertoSalida.Write(movements[cont].ToString());

                    cont++;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
            finally
            {
                if (puertoSalida.IsOpen)
                {
                    puertoSalida.Close();
                }
            }



        }

        public void ScanCubeColors()
        {
            SerialPort puertoSalida = new SerialPort(PuertoCOM);
            string[] movements = { "q", "w", "e", "r", "t", "u" };

            this._cubeScanner.ScanNextFace();
            try
            {
                if (!puertoSalida.IsOpen)
                {
                    puertoSalida.Open();
                }

                if (puertoSalida.IsOpen)
                {
                    if (cont == 6)
                    {
                        cont = 0;
                    }
                    puertoSalida.Write(movements[cont].ToString());

                    cont++;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
            finally
            {
                if (puertoSalida.IsOpen)
                {
                    puertoSalida.Close();
                }
            }

        }

        public void SolveCube(string stepsToSolve)
        {

        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace arduinoCubeSolver.Classes
{
    public class RubiksCube : IEnumerable<RubiksCubeFace>
    {
        private List<RubiksCubeFace> faces;
        public const int FacesCount = 6;

        public bool IsInitialized 
        { 
            private set;
            get; 
        }


        public RubiksCube()
        {
            this.IsInitialized = false;
            this.faces = new List<RubiksCubeFace>(RubiksCube.FacesCount);
        }

        public void InitializeNextFace(char[] cubeletsColors)
        {
            if (cubeletsColors.Length != RubiksCubeFace.CubeletCount)
                throw new ArgumentException("You must only define 9 cubelets in a cube's face");
            this.faces.Add(new RubiksCubeFace(cubeletsColors));
            if (this.faces.Count >= RubiksCube.FacesCount)
                this.IsInitialized = true;
        }

        public string GetCubeString()
        {
            string cubeString = "";
            foreach(var face in this.faces)
            {
                foreach (char cubelet in face)
                    cubeString += cubelet;
            }
            return cubeString;
        }

        public IEnumerator<RubiksCubeFace> GetEnumerator()
        {
            if (!this.IsInitialized)
                throw new ArgumentOutOfRangeException("There's faces that haven't been initialized, initialize all faces first");
            return this.faces.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}

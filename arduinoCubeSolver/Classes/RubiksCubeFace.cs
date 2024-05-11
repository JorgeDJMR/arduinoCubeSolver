using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arduinoCubeSolver.Classes
{
    public class RubiksCubeFace : IEnumerable
    {
        private char[] _cubelets;
        public const int CubeletCount = 9;
        public char[] Cubelets
        {
            get => this._cubelets;
            private set => this._cubelets = value;
        }

        public RubiksCubeFace(char[] cubeletsColors)
        {
            this._cubelets = new char[RubiksCubeFace.CubeletCount];
            Array.Copy(cubeletsColors, this._cubelets, RubiksCubeFace.CubeletCount);
        }

        public char GetCubelet(int row, int column)
        {
            const int ELEMENTS_PER_ROW = 3,
                      ROW_COUNT = 3,
                      COLUMN_COUNT = 3;

            if (row < 1 || row > ROW_COUNT)
            {
                throw new ArgumentOutOfRangeException(nameof(row), "Row must be in the range of 1-3");
            }

            if (column < 1 || column > COLUMN_COUNT)
            {
                throw new ArgumentOutOfRangeException(nameof(column), "Column must be in the range of 1-3");
            }
            row--;
            column--;
            return this._cubelets[ELEMENTS_PER_ROW * row + column];
        }

        public IEnumerator GetEnumerator() 
        {
            return this._cubelets.GetEnumerator();
        }
    }
}

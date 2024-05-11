using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arduinoCubeSolver.Classes
{
    using System.Windows.Forms;
    using System.Drawing;

    public class CubeFaceGroupBox : GroupBox
    {
        private Button[] _cubelets;
        private const int ButtonSize = 30;
        private const int MarginBetweenButtons = 10;

        public const int Columns = 3;
        public const int GroupBoxWidth = ButtonSize * 3 + MarginBetweenButtons * 2;
        public const int GroupBoxHeight = ButtonSize * 3 + MarginBetweenButtons * 2 + 20;
        public new Size Size
        {
            get => base.Size;
            private set => base.Size = value;
        }
        public new string Text
        {
            get => base.Text; 
            private set => base.Text = value;
        }

        // PUBLIC METHODS
        public CubeFaceGroupBox(char faceColor)
        {
            this.Enabled = false;
            this.Text = "";
            this.Size = new Size(GroupBoxWidth, GroupBoxHeight);
            this._cubelets = new Button[RubiksCubeFace.CubeletCount];
            this.InitializeCubelets(faceColor);
        }

        public void SetCubeletColors(char[] cubelets)
        {
            if (cubelets.Length < RubiksCubeFace.CubeletCount)
                throw new ArgumentException("You must only define 9 cubelets in a cube's face");
            for(int i = 0; i < RubiksCubeFace.CubeletCount; i++)
                this._cubelets[i].BackColor = RubiksColorConverter.ConvertCharToColor(cubelets[i]);
        }

        // Private Methods
        private void InitializeCubelets(char faceColor)
        {
            for (int i = 0; i < RubiksCubeFace.CubeletCount; i++)
            {

                Button cubelet = new Button
                {
                    Size = new Size(ButtonSize, ButtonSize),
                    Location = new Point(ButtonSize * (i % Columns) + MarginBetweenButtons, ButtonSize * (i / Columns) + 20),
                    BackColor = RubiksColorConverter.ConvertCharToColor(faceColor)
                };
                this._cubelets[i] = cubelet;
                this.Controls.Add(cubelet);
            }
        }
    }
}

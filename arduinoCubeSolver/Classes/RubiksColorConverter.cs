using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arduinoCubeSolver.Classes
{
    public static class RubiksColorConverter
    {
        public static char ConvertColorToChar(Color color)
        {
            return color.Name switch
            {
                nameof(Color.White)  => 'w',
                nameof(Color.Yellow) => 'y',
                nameof(Color.Blue)   => 'b',
                nameof(Color.Green)  => 'g',
                nameof(Color.Orange) => 'o',
                nameof(Color.Red)    => 'r',
                _ => throw new ArgumentException("The given color is not a color that a Rubik's Cube has"),
            };
        }
        public static Color ConvertCharToColor(char cubeletChar)
        {
            return cubeletChar switch
            {
                'w' => Color.White,
                'y' => Color.Yellow,
                'b' => Color.Blue,
                'g' => Color.Green,
                'o' => Color.Orange,
                'r' => Color.Red,
                _ => throw new ArgumentException("The given character does not correspond to a Rubik's Cube color"),
            };
        }
    }   
}

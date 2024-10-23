using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyulakRokakLib
{
    public class Fox
    {
        public int MaxFullnes { get; init; }
        public int Fullness { get; set; }
        public int Reprodoction { get; init; }
        public int CoordX { get; set; }
        public int CoordY { get; set; }

        public Fox(int maxFullnes, int fullness, int reprodoction, int x, int y)
        {
            MaxFullnes = maxFullnes;
            Fullness = fullness;
            Reprodoction = reprodoction;
            CoordX = x;
            CoordY = y;
        }
        public Fox(int x, int y)
        {
            MaxFullnes = 5;
            Fullness = 0;
            Reprodoction = 3;
        }
    }
}

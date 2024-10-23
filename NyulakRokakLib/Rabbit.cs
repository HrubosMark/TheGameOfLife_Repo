using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyulakRokakLib
{
    public class Rabbit
    {
        public int MaxFullnes { get; init; }
        public int Fullness { get; set; }
        public int Reprodoction { get; init; }
        public int CoordX { get; set; }
        public int CoordY { get; set; }

        public Rabbit(int maxFullnes, int fullness, int reprodoction, int x, int y)
        {
            MaxFullnes = maxFullnes;
            Fullness = fullness;
            Reprodoction = reprodoction;
            CoordX = x;
            CoordY = y;
        }
        public Rabbit(int x, int y) 
        {
            MaxFullnes = 5;
            Fullness = 0;
            Reprodoction = 3;
        }
    }
}

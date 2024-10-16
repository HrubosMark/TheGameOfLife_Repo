using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyulakRokakLib
{
    public class Grid
    {
        private readonly int height;
        private readonly int width;

        public int Height { get => height; init => height = value; }
        public int Width { get => width; init => width = value; }

        public Tile[,] field { get; init; }
        
        public Grid() 
        {
            height = 10;
            width = 10;
            field = new Tile[height, width];
            BuildGrid();
        }
        // Létrehozzá pályát
        private void BuildGrid()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    field[i, j] = new Tile();
                }
            }
        }
        // Feltölti a pályát állatokkal
        public void FillUp(int foxNum, int rabbitNum)
        {
            Random r = new Random();
            for (int i = 0; i < foxNum; i++)
            {
                int x = r.Next(Width);
                int y = r.Next(Height);
                if (!field[x, y].ContainsFox)
                {
                    field[x, y].ContainsFox = true;
                }
                else
                {
                    i--;
                }
            }
            for (int i = 0; i < rabbitNum; i++)
            {
                int x = r.Next(Width);
                int y = r.Next(Height);
                if (!field[x, y].ContainsRabbit)
                {
                    field[x, y].ContainsRabbit = true;
                }
                else
                {
                    i--;
                }
            }
        }
        

    }
}

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
            width = 20;
            field = new Tile[height, width];
            BuildGrid();
        }
        // Létrehozza a pályát
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
        public void AddAnimals(int foxNum, int rabbitNum)
        {
            Random r = new Random();
            for (int i = 0; i < foxNum; i++)
            {
                int x = r.Next(Height);
                int y = r.Next(Width);
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
                int x = r.Next(Height);
                int y = r.Next(Width);
                if (!field[x, y].ContainsRabbit && !field[x, y].ContainsFox)
                {
                    field[x, y].ContainsRabbit = true;
                }
                else
                {
                    i--;
                }
            }
        }
        // Vissza adja egy adott mezejét a mátrixnak
        public string GetTile(int x, int y)
        {
            if (field[x, y].ContainsRabbit)
            {
                return "🐰"; // Ide jön a nyúl ikonja
            }
            else if (field[x, y].ContainsFox)
            {
                return "🦊"; // Ide jön a róka ikonja
            }
            else if (field[x, y].GrassState == "seedling")
            {
                return "🌱"; // Ide jön a fű kezdetleges ikonja
            }
            else if (field[x, y].GrassState == "young")
            {
                return "🍃"; // Ide jön a fű második ikonja
            }
            else if (field[x, y].GrassState == "mature")
            {
                return "🌿"; // Ide jön a megnőtt fű ikonja
            }
            else
            {
                return "⚪"; // Üres mező ikonja, ha lesz
            }
        }
    }
}

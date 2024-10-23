using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
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
        private List<Fox> Foxes { get; set; }
        private List<Rabbit> Rabbits { get; set; }

        // A fő mátrix
        public Tile[,] field { get; init; }

        public Grid(int height, int width)
        {
            this.height = height;
            this.width = width;
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
            Foxes = new List<Fox>();
            Random r = new Random();
            for (int i = 0; i < foxNum; i++)
            {
                int x = r.Next(Height);
                int y = r.Next(Width);
                if (!field[x, y].ContainsFox)
                {
                    field[x, y].ContainsFox = true;
                    Foxes.Add(new Fox(x, y));
                }
                else
                {
                    i--;
                }
            }
            Rabbits = new List<Rabbit>();
            for (int i = 0; i < rabbitNum; i++)
            {
                int x = r.Next(Height);
                int y = r.Next(Width);
                if (!field[x, y].ContainsRabbit && !field[x, y].ContainsFox)
                {
                    field[x, y].ContainsRabbit = true;
                    Rabbits.Add(new Rabbit(x, y));
                }
                else
                {
                    i--;
                }
            }
        }

        // Megjeleníti a mátrixot
        public void WriteMatrix()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (field[i, j].ContainsFox)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else if (field[i, j].ContainsRabbit)
                    {
                        Console.ForegroundColor= ConsoleColor.White;
                    }
                    else if (field[i, j].GrassState == "seedling")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    else if (field[i, j].GrassState == "young")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    }
                    else if (field[i, j].GrassState == "mature")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    Console.Write($"{GetTile(i, j)} ");
                }
                Console.WriteLine("");
            }
        }
        // Vissza adja egy adott mezejét a mátrixnak
        public string GetTile(int x, int y)
        {
            if (field[x, y].ContainsRabbit)
            {
                return "R"; // Ide jön a nyúl ikonja 🐰
            }
            else if (field[x, y].ContainsFox)
            {
                return "F"; // Ide jön a róka ikonja 🦊
            }
            else if (field[x, y].GrassState == "seedling")
            {
                return "S"; // Ide jön a fű kezdetleges ikonja 🌱
            }
            else if (field[x, y].GrassState == "young")
            {
                return "Y"; // Ide jön a fű második ikonja 🍃
            }
            else if (field[x, y].GrassState == "mature")
            {
                return "M"; // Ide jön a megnőtt fű ikonja 🌿
            }
            else
            {
                return "N"; // Üres mező ikonja, ha lesz ⚪
            }
        }
        // Körök rendszere
        public void Run(int timeBetweenRounds, int rounds)
        {
            Random r = new Random();
            for (int i = 0; i < rounds; i++) 
            {
                WriteMatrix();
                for (int j = 0; j < Height; j++)
                {
                    for (int k = 0; k < Width; k++)
                    {
                        field[j, k].Grow();
                    }
                }
                Thread.Sleep(timeBetweenRounds);
                foreach (var item in Rabbits)
                {
                    RabbitMove(item);
                }
                foreach (var item in Foxes)
                {
                    FoxMove(item);
                }
                
                Console.Clear();
            }
        }
        // Mozgás rendszer
        public void RabbitMove(Rabbit rabbit)
        {
            int attempts = 0;
            Random r = new Random();
            bool successful = false;
            while (!successful && attempts < 10)
            {
                int movePlace = r.Next(1, 9);
                int newX = rabbit.CoordX, newY = rabbit.CoordY;
                attempts++;
                switch (movePlace)
                {
                    case 1: // Felső
                        if (rabbit.CoordY + 1 < Height) newY++;
                        break;
                    case 2: // Jobb felső
                        if (rabbit.CoordX + 1 < Width && rabbit.CoordY + 1 < Height)
                        {
                            newX++;
                            newY++;
                        }
                        break;
                    case 3: // Jobb
                        if (rabbit.CoordX + 1 < Width) newX++;
                        break;
                    case 4: // Jobb alsó
                        if (rabbit.CoordX + 1 < Width && rabbit.CoordY - 1 >= 0)
                        {
                            newX++;
                            newY--;
                        }
                        break;
                    case 5: // Alsó
                        if (rabbit.CoordY - 1 >= 0) newY--;
                        break;
                    case 6: // Bal alsó
                        if (rabbit.CoordX - 1 >= 0 && rabbit.CoordY - 1 >= 0)
                        {
                            newX--;
                            newY--;
                        }
                        break;
                    case 7: // Bal
                        if (rabbit.CoordX - 1 >= 0) newX--;
                        break;
                    case 8: // Bal felső
                        if (rabbit.CoordX - 1 >= 0 && rabbit.CoordY + 1 < Height)
                        {
                            newX--;
                            newY++;
                        }
                        break;
                }

                Tile examined = field[newX, newY];
                if (!examined.ContainsFox && !examined.ContainsRabbit)
                {
                    field[rabbit.CoordX, rabbit.CoordY].ContainsRabbit = false;
                    rabbit.CoordX = newX;
                    rabbit.CoordY = newY;
                    field[rabbit.CoordX, rabbit.CoordY].ContainsRabbit = true;
                    successful = true;
                }
            }
        }

        public void FoxMove(Fox fox)
        {
            int attempts = 0;
            Random r = new Random();
            bool successful = false;
            while (!successful && attempts < 10)
            {
                int movePlace = r.Next(1, 9);
                int newX = fox.CoordX, newY = fox.CoordY;
                attempts++;
                switch (movePlace)
                {
                    case 1: // Felső
                        if (fox.CoordY + 1 < Height) newY++;
                        break;
                    case 2: // Jobb felső
                        if (fox.CoordX + 1 < Width && fox.CoordY + 1 < Height)
                        {
                            newX++;
                            newY++;
                        }
                        break;
                    case 3: // Jobb
                        if (fox.CoordX + 1 < Width) newX++;
                        break;
                    case 4: // Jobb alsó
                        if (fox.CoordX + 1 < Width && fox.CoordY - 1 >= 0)
                        {
                            newX++;
                            newY--;
                        }
                        break;
                    case 5: // Alsó
                        if (fox.CoordY - 1 >= 0) newY--;
                        break;
                    case 6: // Bal alsó
                        if (fox.CoordX - 1 >= 0 && fox.CoordY - 1 >= 0)
                        {
                            newX--;
                            newY--;
                        }
                        break;
                    case 7: // Bal
                        if (fox.CoordX - 1 >= 0) newX--;
                        break;
                    case 8: // Bal felső
                        if (fox.CoordX - 1 >= 0 && fox.CoordY + 1 < Height)
                        {
                            newX--;
                            newY++;
                        }
                        break;
                }

                Tile examined = field[newX, newY];
                if (!examined.ContainsFox && !examined.ContainsRabbit)
                {
                    field[fox.CoordX, fox.CoordY].ContainsFox = false;
                    fox.CoordX = newX;
                    fox.CoordY = newY;
                    field[fox.CoordX, fox.CoordY].ContainsFox = true;
                    successful = true;
                }
            }
        }
    }
}



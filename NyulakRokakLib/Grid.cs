using System;
using System.Collections.Generic;
using System.Linq;
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
        private List<Fox> Foxs { get; set; }
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
            Random r = new Random();
            for (int i = 0; i < foxNum; i++)
            {
                int x = r.Next(Height);
                int y = r.Next(Width);
                if (!field[x, y].ContainsFox)
                {
                    field[x, y].ContainsFox = true;
                    Foxs.Add(new Fox(x, y));
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
                RabbitMove(Rabbits[r.Next(0, Foxs.Count)]);
                FoxMove(Foxs[r.Next(0, Foxs.Count)]);
                Console.Clear();
            }
        }
        // Mozgás rendszer
        public void RabbitMove(Rabbit rabbit)
        {
            Random r = new Random();
            bool succesful = false;
            while (!succesful)
            {
                int movePlace = r.Next(1, 8); // 1-8 felülről indulva mező körüli mezők óra mutató járása szerint
                switch (movePlace)
                {
                    case 1: // Felette lévő
                        Tile examined = field[rabbit.CoordX, rabbit.CoordY + 1];
                        if (!examined.ContainsFox && examined.ContainsRabbit)
                        {
                            rabbit.CoordY++;
                            succesful = true;
                            if (examined.GrassState == "young" && rabbit.Fullness != rabbit.MaxFullnes)
                            {
                                rabbit.Fullness++;
                            }
                            else if (examined.GrassState == "mature" && rabbit.Fullness != rabbit.MaxFullnes)
                                break;
                        }
                        break;
                    case 2: // Jobb felső
                        examined = field[rabbit.CoordX + 1, rabbit.CoordY + 1];
                        if (!examined.ContainsFox && examined.ContainsRabbit)
                        {
                            rabbit.CoordX++;
                            rabbit.CoordY++;
                            succesful = true;
                            if (examined.GrassState == "young" && rabbit.Fullness != rabbit.MaxFullnes)
                            {
                                rabbit.Fullness++;
                            }
                            else if (examined.GrassState == "mature" && rabbit.Fullness != rabbit.MaxFullnes)
                                break;
                        }
                        break;
                    case 3: // Jobbra
                        examined = field[rabbit.CoordX + 1, rabbit.CoordY];
                        if (!examined.ContainsFox && examined.ContainsRabbit)
                        {
                            rabbit.CoordX++;
                            succesful = true;
                            if (examined.GrassState == "young" && rabbit.Fullness != rabbit.MaxFullnes)
                            {
                                rabbit.Fullness++;
                            }
                            else if (examined.GrassState == "mature" && rabbit.Fullness != rabbit.MaxFullnes)
                                break;
                        }
                        break;
                    case 4: // Jobb alsó
                        examined = field[rabbit.CoordX + 1, rabbit.CoordY - 1];
                        if (!examined.ContainsFox && examined.ContainsRabbit)
                        {
                            rabbit.CoordX++;
                            rabbit.CoordY--;
                            succesful = true;
                            if (examined.GrassState == "young" && rabbit.Fullness != rabbit.MaxFullnes)
                            {
                                rabbit.Fullness++;
                            }
                            else if (examined.GrassState == "mature" && rabbit.Fullness != rabbit.MaxFullnes)
                                break;
                        }
                        break;
                    case 5: // Alatta lévő
                        examined = field[rabbit.CoordX, rabbit.CoordY - 1];
                        if (!examined.ContainsFox && examined.ContainsRabbit)
                        {
                            rabbit.CoordY--;
                            succesful = true;
                            if (examined.GrassState == "young" && rabbit.Fullness != rabbit.MaxFullnes)
                            {
                                rabbit.Fullness++;
                            }
                            else if (examined.GrassState == "mature" && rabbit.Fullness != rabbit.MaxFullnes)
                                break;
                        }
                        break;
                    case 6: // Bal alsó
                        examined = field[rabbit.CoordX - 1, rabbit.CoordY - 1];
                        if (!examined.ContainsFox && examined.ContainsRabbit)
                        {
                            rabbit.CoordX--;
                            rabbit.CoordY--;
                            succesful = true;
                            if (examined.GrassState == "young" && rabbit.Fullness != rabbit.MaxFullnes)
                            {
                                rabbit.Fullness++;
                            }
                            else if (examined.GrassState == "mature" && rabbit.Fullness != rabbit.MaxFullnes)
                                break;
                        }
                        break;
                    case 7: // Balra lévő
                        examined = field[rabbit.CoordX - 1, rabbit.CoordY];
                        if (!examined.ContainsFox && examined.ContainsRabbit)
                        {
                            rabbit.CoordX--;
                            succesful = true;
                            if (examined.GrassState == "young" && rabbit.Fullness != rabbit.MaxFullnes)
                            {
                                rabbit.Fullness++;
                            }
                            else if (examined.GrassState == "mature" && rabbit.Fullness != rabbit.MaxFullnes)
                                break;
                        }
                        break;
                    case 8: // Bal felső
                        examined = field[rabbit.CoordX - 1, rabbit.CoordY + 1];
                        if (!examined.ContainsFox && examined.ContainsRabbit)
                        {
                            rabbit.CoordX--;
                            rabbit.CoordY++;
                            succesful = true;
                            if (examined.GrassState == "young" && rabbit.Fullness != rabbit.MaxFullnes)
                            {
                                rabbit.Fullness++;
                            }
                            else if (examined.GrassState == "mature" && rabbit.Fullness != rabbit.MaxFullnes)
                                break;
                        }
                        break;
                }
            }

        }
        public void FoxMove(Fox fox)
        {
            Random r = new Random();
            bool succesful = false;
            while (!succesful)
            {
                int movePlace = r.Next(1, 8); // 1-8 felülről indulva mező körüli mezők óra mutató járása szerint
                switch (movePlace)
                {
                    case 1: // Felette lévő
                        Tile examined = field[fox.CoordX, fox.CoordY + 1];
                        if (!examined.ContainsRabbit && examined.ContainsRabbit)
                        {
                            fox.CoordY++;
                            succesful = true;
                            if (examined.GrassState == "young" && fox.Fullness != fox.MaxFullnes)
                            {
                                fox.Fullness++;
                            }
                            else if (examined.GrassState == "mature" && fox.Fullness != fox.MaxFullnes)
                                break;
                        }
                        break;
                    case 2: // Jobb felső
                        examined = field[fox.CoordX + 1, fox.CoordY + 1];
                        if (!examined.ContainsRabbit && examined.ContainsRabbit)
                        {
                            fox.CoordX++;
                            fox.CoordY++;
                            succesful = true;
                            if (examined.GrassState == "young" && fox.Fullness != fox.MaxFullnes)
                            {
                                fox.Fullness++;
                            }
                            else if (examined.GrassState == "mature" && fox.Fullness != fox.MaxFullnes)
                                break;
                        }
                        break;
                    case 3: // Jobbra
                        examined = field[fox.CoordX + 1, fox.CoordY];
                        if (!examined.ContainsRabbit && examined.ContainsRabbit)
                        {
                            fox.CoordX++;
                            succesful = true;
                            if (examined.GrassState == "young" && fox.Fullness != fox.MaxFullnes)
                            {
                                fox.Fullness++;
                            }
                            else if (examined.GrassState == "mature" && fox.Fullness != fox.MaxFullnes)
                                break;
                        }
                        break;
                    case 4: // Jobb alsó
                        examined = field[fox.CoordX + 1, fox.CoordY - 1];
                        if (!examined.ContainsRabbit && examined.ContainsRabbit)
                        {
                            fox.CoordX++;
                            fox.CoordY--;
                            succesful = true;
                            if (examined.GrassState == "young" && fox.Fullness != fox.MaxFullnes)
                            {
                                fox.Fullness++;
                            }
                            else if (examined.GrassState == "mature" && fox.Fullness != fox.MaxFullnes)
                                break;
                        }
                        break;
                    case 5: // Alatta lévő
                        examined = field[fox.CoordX, fox.CoordY - 1];
                        if (!examined.ContainsRabbit && examined.ContainsRabbit)
                        {
                            fox.CoordY--;
                            succesful = true;
                            if (examined.GrassState == "young" && fox.Fullness != fox.MaxFullnes)
                            {
                                fox.Fullness++;
                            }
                            else if (examined.GrassState == "mature" && fox.Fullness != fox.MaxFullnes)
                                break;
                        }
                        break;
                    case 6: // Bal alsó
                        examined = field[fox.CoordX - 1, fox.CoordY - 1];
                        if (!examined.ContainsRabbit && examined.ContainsRabbit)
                        {
                            fox.CoordX--;
                            fox.CoordY--;
                            succesful = true;
                            if (examined.GrassState == "young" && fox.Fullness != fox.MaxFullnes)
                            {
                                fox.Fullness++;
                            }
                            else if (examined.GrassState == "mature" && fox.Fullness != fox.MaxFullnes)
                                break;
                        }
                        break;
                    case 7: // Balra lévő
                        examined = field[fox.CoordX - 1, fox.CoordY];
                        if (!examined.ContainsRabbit && examined.ContainsRabbit)
                        {
                            fox.CoordX--;
                            succesful = true;
                            if (examined.GrassState == "young" && fox.Fullness != fox.MaxFullnes)
                            {
                                fox.Fullness++;
                            }
                            else if (examined.GrassState == "mature" && fox.Fullness != fox.MaxFullnes)
                                break;
                        }
                        break;
                    case 8: // Bal felső
                        examined = field[fox.CoordX - 1, fox.CoordY + 1];
                        if (!examined.ContainsRabbit && examined.ContainsRabbit)
                        {
                            fox.CoordX--;
                            fox.CoordY++;
                            succesful = true;
                            if (examined.GrassState == "young" && fox.Fullness != fox.MaxFullnes)
                            {
                                fox.Fullness++;
                            }
                            else if (examined.GrassState == "mature" && fox.Fullness != fox.MaxFullnes)
                                break;
                        }
                        break;
                }
            }
        }
    }
}
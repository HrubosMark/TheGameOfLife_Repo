// Mikuska Péter Marcell 12.a
// 2024.10.16

using NyulakRokakLib;

Grid field = new Grid();

// Mátrix megjelenítése

field.AddAnimals(2, 3);

for (int i = 0; i < field.Height; i++)
{
    for (int j = 0; j < field.Width; j++)
    {
        Console.Write($"{field.GetTile(i, j)} ");
    }
    Console.WriteLine("");
}
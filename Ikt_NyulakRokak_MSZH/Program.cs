// Mikuska Péter Marcell 12.a, Hrubos Márk 12.a


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

//A Felhasználotól bekért körök száma

Console.WriteLine("Adja meg hány körös legyen a szimuláció: ");
string rounds  = Console.ReadLine();
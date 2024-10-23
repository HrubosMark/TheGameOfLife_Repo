// Mikuska Péter Marcell 12.a, Hrubos Márk 12.a


using NyulakRokakLib;


//A Felhasználotól bekért körök száma

Console.Write("Adja meg hány körös legyen a szimuláció: ");
string input = Console.ReadLine();
int rounds;
while (!int.TryParse(input, out rounds))
{
    Console.Write("Számot adjon meg!");
    input = Console.ReadLine();
}

//A Felhasználotól bekért mátrix szélessége és magassága

Console.Write("Adja meg, hogy mekkora legyen a pálya magassága: ");
string input1 = Console.ReadLine();
int height;
while (!int.TryParse(input1, out height))
{
    Console.Write("Számot adjon meg!");
    input1 = Console.ReadLine();
}

Console.Write("Adja meg, hogy mekkora legyen a pálya szélessége: ");
string input2 = Console.ReadLine();
int width;
while (!int.TryParse(input2, out width))
{
    Console.WriteLine("Számot adjon meg!");
    input2 = Console.ReadLine();
}

//A Felhasználotól bekért nyulak száma
Console.Write("Adja meg hány darab nyulall kezdődjön a szimuláció: ");
string input3 = Console.ReadLine();
int rabbits;

while (!int.TryParse(input3, out rabbits))
{
    Console.Write("Számot adjon meg!");
    input3 = Console.ReadLine();
}

//A Felhasználotól bekért rókák száma
Console.Write("Adja meg hány darab rókával kezdődjön a szimuláció: ");
string input4 = Console.ReadLine();
int foxes;

while (!int.TryParse(input4, out foxes))
{
    Console.Write("Számot adjon meg!");
    input4 = Console.ReadLine();
}

Grid field = new Grid(height, width);

field.AddAnimals(foxes, rabbits);


//A körök közti idő ms-ben
Console.Write("Adja meg hány másodperces legyen egy kör: ");
int betweenRounds = int.Parse(Console.ReadLine())*1000;
field.Run(betweenRounds, rounds);


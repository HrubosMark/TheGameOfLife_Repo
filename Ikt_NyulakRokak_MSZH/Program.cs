// Mikuska Péter Marcell 12.a, Hrubos Márk 12.a


using NyulakRokakLib;

Grid field = new Grid();

field.AddAnimals(2, 3);

//A Felhasználotól bekért körök száma

Console.WriteLine("Adja meg hány körös legyen a szimuláció: ");
string input = Console.ReadLine();
int rounds;

//A Felhasználotól bekért mátrix szélessége és magassága

Console.WriteLine("Adja meg ,hogy mekkora legyen a szimuláció mátrix magassága: ");
int height = int.Parse(Console.ReadLine());
Console.WriteLine("Adja meg ,hogy mekkora legyen a szimuláció mátrix szélessége: ");
int width = int.Parse(Console.ReadLine());

//A Felhasználotól bekért nyulak száma
Console.WriteLine("Adja meg hány darab nyulall kezdődjön a szimuláció: ");
int rabbits = int.Parse(Console.ReadLine());

//A Felhasználotól bekért rókák száma
Console.WriteLine("Adja meg hány darab rókával kezdődjön a szimuláció: ");
int foxes = int.Parse(Console.ReadLine());

while (!int.TryParse(input, out rounds))
{
    Console.WriteLine("Számot adjon meg!");
    input = Console.ReadLine();
}


//A körök közti idő ms-ben
int betweenRounds = 5000;
field.Run(betweenRounds, rounds);


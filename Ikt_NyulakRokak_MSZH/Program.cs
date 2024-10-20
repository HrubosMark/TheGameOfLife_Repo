// Mikuska Péter Marcell 12.a, Hrubos Márk 12.a


using NyulakRokakLib;

Grid field = new Grid();

field.AddAnimals(2, 3);

//A Felhasználotól bekért körök száma

Console.WriteLine("Adja meg hány körös legyen a szimuláció: ");
string input = Console.ReadLine();
int rounds;

while (!int.TryParse(input, out rounds))
{
    Console.WriteLine("Számot adjon meg!");
    input = Console.ReadLine();
}


//A körök közti idő ms-ben
int betweenRounds = 5000;
field.Run(betweenRounds, rounds);


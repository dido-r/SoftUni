using System;

namespace Tuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] personalInfo = Console.ReadLine().Split();
            string name = personalInfo[0] + " " + personalInfo[1];
            string address = personalInfo[2];
            string town = string.Empty;
            for (int i = 3; i < personalInfo.Length; i++)
            {
                town += personalInfo[i] + " ";
            }
            town.TrimEnd();

            string[] beerData = Console.ReadLine().Split();
            string[] bankDetails = Console.ReadLine().Split();

            Tuple<string, string, string> tuple = new Tuple<string, string, string>(name, address, town);
            Tuple<string, int, string> beer = new Tuple<string, int, string>(beerData[0], int.Parse(beerData[1]), beerData[2]);
            Tuple<string, double, string> bank = new Tuple<string, double, string>(bankDetails[0], double.Parse(bankDetails[1]), bankDetails[2]);

            Console.WriteLine($"{tuple.Item1} -> {tuple.Item2} -> {tuple.Item3}");
            Console.WriteLine($"{beer.Item1} -> {beer.Item2} -> {beer.IsDrunk()}");
            Console.WriteLine($"{bank.Item1} -> {bank.Item2} -> {bank.Item3}");
        }
    }
}

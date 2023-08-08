using System;

namespace Tuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] nameAndAddress = Console.ReadLine().Split();
            string[] beerData = Console.ReadLine().Split();
            string[] numbers = Console.ReadLine().Split();

            Tuple<string, string> tuple = new Tuple<string, string>(nameAndAddress[0] + " " + nameAndAddress[1], nameAndAddress[2]);
            Tuple<string, int> beer = new Tuple<string, int>(beerData[0], int.Parse(beerData[1]));
            Tuple<int, double> nums = new Tuple<int, double>(int.Parse(numbers[0]), double.Parse(numbers[1]));

            Console.WriteLine($"{tuple.Item1} -> {tuple.Item2}");
            Console.WriteLine($"{beer.Item1} -> {beer.Item2}");
            Console.WriteLine($"{nums.Item1} -> {nums.Item2}");
        }
    }
}

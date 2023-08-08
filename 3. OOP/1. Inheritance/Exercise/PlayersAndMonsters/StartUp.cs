using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            DarkWizard hero = new DarkWizard("hero", 20);
            Console.WriteLine(hero);
        }
    }
}
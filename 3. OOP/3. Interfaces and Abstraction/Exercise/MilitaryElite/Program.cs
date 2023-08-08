using System;
using System.Collections.Generic;
using System.Linq;

namespace MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<ISoldier> privateList = new List<ISoldier>();

            while (input != "End")
            {
                try
                {
                    string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    ISoldier soldier = default;

                    if (data[0] == "Private")
                    {
                        soldier = new Private(data[1], data[2], data[3], decimal.Parse(data[4]));
                        privateList.Add(soldier);
                    }
                    else if (data[0] == "LieutenantGeneral")
                    {
                        soldier = new LieutenantGeneral(data[1], data[2], data[3], decimal.Parse(data[4]));
                        
                        for (int i = 5; i < data.Length; i++)
                        {
                            ((LieutenantGeneral)soldier).SetOfPrivates.Add(privateList.First(x => x.Id == data[i]));
                        }
                    }
                    else if (data[0] == "Engineer")
                    {
                        string[] arr = new string[data.Length - 6];

                        for (int i = 0; i < arr.Length; i++)
                        {
                            arr[i] = data[i + 6];
                        }
                        soldier = new Engineer(data[1], data[2], data[3], decimal.Parse(data[4]), data[5], arr);
                    }
                    else if (data[0] == "Commando")
                    {
                        string[] arr = new string[data.Length - 6];

                        for (int i = 0; i < arr.Length; i++)
                        {
                            arr[i] = data[i + 6];
                        }
                        soldier = new Commando(data[1], data[2], data[3], decimal.Parse(data[4]), data[5], arr);
                    }
                    else if (data[0] == "Spy")
                    {
                        soldier = new Spy(data[1], data[2], data[3], int.Parse(data[4]));
                    }
                    Console.WriteLine(soldier);
                }
                catch
                {
                }
                input = Console.ReadLine();
            }
        }
    }
}

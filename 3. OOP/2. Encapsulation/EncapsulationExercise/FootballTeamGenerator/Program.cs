using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();
            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] data = input.Split(";", StringSplitOptions.RemoveEmptyEntries);

                if (data[0] == "Team")
                {
                    try
                    {
                        if (!teams.Any(x => x.Name == data[1]))
                        {
                            Team team = new Team(data[1]);
                            teams.Add(team);
                        }
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
                else if (data[0] == "Add")
                {
                    try
                    {
                        if (teams.Any(x => x.Name == data[1]))
                        {
                            Player player = new Player(data[2], int.Parse(data[3]), int.Parse(data[4]), int.Parse(data[5]), int.Parse(data[6]), int.Parse(data[7]));
                            teams.First(x => x.Name == data[1]).AddPlayer(player);
                        }
                        else
                        {
                            Console.WriteLine($"Team {data[1]} does not exist.");
                        }
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
                else if (data[0] == "Remove")
                {
                    if (teams.Any(x => x.Name == data[1]))
                    {
                        teams.First(x => x.Name == data[1]).RemovePlayer(data[2]);
                    }
                    else
                    {
                        Console.WriteLine($"Team {data[1]} does not exist.");
                    }
                }
                else if (data[0] == "Rating")
                {
                    if (teams.Any(x => x.Name == data[1]))
                    {
                        try
                        {
                            Console.WriteLine($"{teams.First(x => x.Name == data[1]).Name} - {teams.First(x => x.Name == data[1]).Rating}");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine($"{teams.First(x => x.Name == data[1]).Name} - 0");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Team {data[1]} does not exist.");
                    }
                }
                input = Console.ReadLine();
            }
        }
    }
}

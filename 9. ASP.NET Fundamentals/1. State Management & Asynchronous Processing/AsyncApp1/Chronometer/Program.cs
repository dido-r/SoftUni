namespace Chronometer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var timer = new Chronometer();

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "stop")
                {
                    timer.Stop();
                    Console.WriteLine(timer.GetTime);
                }
                else if (command == "start")
                {
                    var task = Task.Run(() =>
                    {
                        timer.Start();
                    });
                }
                else if (command == "reset")
                {
                    timer.Reset();
                }
                else if (command == "time")
                {
                    Console.WriteLine(timer.GetTime);
                }
                else if (command == "lap")
                {
                    Console.WriteLine(timer.Lap());
                }
                else if (command == "laps")
                {
                    var laps = timer.Laps();

                    if (laps.Count == 0)
                    {
                        Console.WriteLine("No laps recorded!");
                    }
                    else
                    {
                        for (int i = 0; i < laps.Count; i++)
                        {
                            Console.WriteLine($"{i}. {laps[i]}");
                        }
                    }
                }
                else if (command == "exit")
                {
                    return;
                }
            }
        }
    }
}
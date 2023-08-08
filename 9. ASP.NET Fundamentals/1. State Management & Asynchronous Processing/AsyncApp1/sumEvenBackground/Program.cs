namespace sumEvenBackground
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;

            var task = Task.Run(() =>
            {
                for (int i = 1; i <= 1000; i++)
                {
                    Thread.Sleep(100);
                    if (i % 2 == 0)
                    {
                        sum += i;
                    }
                }
            });

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "exit")
                {
                    return;
                }
                else if (command == "show")
                {
                    Console.WriteLine(sum);
                }
            }
        }
    }
}
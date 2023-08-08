namespace sumEvens
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var command = Console.ReadLine();

                if (command == "show")
                {
                    Console.WriteLine(SumEvens());
                }
            }
        }

        private static int SumEvens()
        {

            return Task.Run(() =>
            {
                int sum = 0;

                for (int i = 1; i <= 1000; i++)
                {
                    if (i % 2 == 0)
                    {
                        sum += i;
                    }
                }

                return sum;
            }).Result;
        }
    }
}
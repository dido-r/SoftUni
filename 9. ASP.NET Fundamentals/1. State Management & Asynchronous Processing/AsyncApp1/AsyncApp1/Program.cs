namespace AsyncApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(PrintEvenNumber(1, 9));
        }

        private static string PrintEvenNumber(int a, int b)
        {
            Thread thread = new Thread(() =>
            {
                for (int i = a; i < b; i++)
                {
                    if (i % 2 == 0)
                    {
                        Console.WriteLine(i);
                    }
                }
            });

            thread.Start();
            thread.Join();
            return "Thread finished work";
        }
    }
}
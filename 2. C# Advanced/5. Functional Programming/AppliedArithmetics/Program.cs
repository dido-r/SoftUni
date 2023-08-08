using System;
using System.Linq;

namespace AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string input = Console.ReadLine();

            while (input != "end")
            {
                Func<int, int> filter = Commands(input);
                Action<int[]> print = Print(input, nums);

                for (int i = 0; i < nums.Length; i++)
                {
                    nums[i] = filter(nums[i]);
                }

                input = Console.ReadLine();
            }
        }

        private static Action<int[]> Print(string input, int[] nums)
        {
            if (input == "print")
            {
                Console.WriteLine(string.Join(" ", nums));
            }
            return null;
        }

        private static Func<int, int> Commands(string input)
        {
            switch (input)
            {
                case "add":
                    return x => x + 1;
                case "multiply":
                    return x => x * 2;
                case "subtract":
                    return x => x - 1;
            }
            return x => x;
        }
    }
}

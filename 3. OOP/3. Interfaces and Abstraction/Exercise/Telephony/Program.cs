using System;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in numbers)
            {
                if (item.Length == 7)
                {
                    try
                    {
                        ICallable phone = new StationaryPhone(item);
                        Console.WriteLine(phone.Call());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    try
                    {
                        ICallable phone = new Smartphone();
                        phone.Number = item;
                        Console.WriteLine(phone.Call());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            string[] sites = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in sites)
            {
                try
                {
                    IBrowsable phone = new Smartphone();
                    phone.Site = item;
                    Console.WriteLine(phone.Browse());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
    }
}

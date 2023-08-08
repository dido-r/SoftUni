using CarDealer.Data;
using Methods;
using System;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //Console.WriteLine(MethodClass.MethodName(context));
        }
    }
}
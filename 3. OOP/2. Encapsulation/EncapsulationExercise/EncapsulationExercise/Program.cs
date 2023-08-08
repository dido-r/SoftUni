using System;

namespace ClassBoxData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            try
            {
                Box box = new Box(length, width, height);
                Console.WriteLine($"Surface Area - {box.SurfaceArea(box):f2}");
                Console.WriteLine($"Lateral Surface Area - {box.LateralSurfaceArea(box):f2}");
                Console.WriteLine($"Volume - {box.Volume(box):f2}");
            }
            catch (Exception exep)
            {
                Console.WriteLine(exep.Message);
                return;
            }
        }
    }
}

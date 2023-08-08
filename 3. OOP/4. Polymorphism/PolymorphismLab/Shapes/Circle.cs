using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public override double CalculateArea()
        {
            return Math.Pow(radius, 2) * Math.PI;
        }

        public override double CalculatePerimeter()
        {
            return 2 * radius * Math.PI;
        }
        public override string Draw()
        {
            return "Draw Circle";
        }
    }
}

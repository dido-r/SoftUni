using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public double Length
        {
            get { return length; }
            private set
            {
                if (value <= 0)
                {
                    throw new Exception("Length cannot be zero or negative.");
                }
                length = value;
            }
        }
        public double Width
        {
            get { return width; }
            private set
            {
                if (value <= 0)
                {
                    throw new Exception("Width cannot be zero or negative.");
                }
                width = value;
            }
        }
        public double Height
        {
            get { return height; }
            private set
            {
                if (value <= 0)
                {
                    throw new Exception("Height cannot be zero or negative.");
                }
                height = value;
            }
        }

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double SurfaceArea(Box box)
        {
            return 2 * box.Length * box.Width + 2 * box.Length * box.Height + 2 * box.Width * box.Height;
        }
        public double LateralSurfaceArea(Box box)
        {
            return 2 * box.Height * (box.Length + box.Width);
        }
        public double Volume(Box box)
        {
            return box.Height * box.Length * box.Width;
        }
    }
}

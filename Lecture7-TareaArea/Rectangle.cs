using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture7_TareaArea
{
    public class Rectangle : Shape
    {
        public double Length { get; set; }
        public double Width { get; set; }

        public Rectangle(double length, double width)
        {
            Length = length;
            Width = width;
        }

        public double GetArea()
        {
            return Length * Width;
        }
        public double GetArea(string unit)
        {
            double area = Length * Width;


            switch (unit.ToLower())
            {
                case "m":
                    return area / 10000.0;
                case "cm":
                    return area * 10000.0; 
                case "km":
                    return area / 1e6;
                case "ml":
                    return area * 1000000.0; 
                case "inch":
                    return area * 1550.0031; 
                default:
                    return area; 
            }
        }

    }
}

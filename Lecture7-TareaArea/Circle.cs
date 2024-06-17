using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture7_TareaArea
{
    public class Circle : Shape
    {
        public double radius { get; set; }
        public override double GetArea()
        {
            double area = Math.PI * Math.Pow(radius,radius);
            return area;
        }
    }
}

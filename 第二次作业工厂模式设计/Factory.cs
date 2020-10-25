using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns;

namespace 工厂
{
    class Factory
    {
        public static Shape ShapeSelection(string type)
        {
            Shape shape = null;
            Random rand = new Random();
            double a = rand.Next(1, 10);
            double b = rand.Next(1, 10);
            double c = rand.Next(1, 10);
            switch (type)
            {
                case "Triangle":shape = new Triangle(a, b, c);break;
                case "Rectangle":shape = new Rectangle(a, b);break;
                case "Square":shape = new Square(c);break;
                default:shape = null;break;
            }
            return shape;
        }
    }
}

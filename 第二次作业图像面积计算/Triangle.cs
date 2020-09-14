using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace 图像面积计算
{
    /// <summary>
    /// 三角形的面积计算
    /// </summary>
    class Triangle
    {
        private float a, b, c,s,area;
        public void Area1()
        {
            //a = 3; b = 4; c = 5;
            Console.WriteLine("\t\t请输入三角形三边的大小");

            Console.Write("a=");
            string x = Console.ReadLine();
            a = Convert.ToSingle(x);

            Console.Write("b=");
            string y = Console.ReadLine();
            b = Convert.ToSingle(x);

            Console.Write("c=");
            string z = Console.ReadLine();
            c = Convert.ToSingle(x);
            #region 构成三角形
            if (a + b > c && a + c > b && b + c > a)
            {
                s = (a + b + c) / 2;
                area = (float)Math.Sqrt(s * (s - a) * (s - b) * (s - c));
                Console.Write("\n三角形的面积是：");
                Console.WriteLine("{0}", area);
            }
            else
                Console.WriteLine("你输入的三边不能构成三角形。");
            // Console.Read();
            #endregion
        }
    }
}

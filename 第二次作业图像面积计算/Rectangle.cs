using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace 图像面积计算
{
    /// <summary>
    /// 长方形的面积计算
    /// </summary>
    class Rectangle
    {
       private float a, b, m;
       public void Area3()
       {
           Console.Write("请输入长方形的长：");
           string s7 = Console.ReadLine();

           a = Convert.ToSingle(s7);
           Console.Write("请输入长方形的宽：");
           string s8 = Console.ReadLine();

           b = Convert.ToSingle(s8);
           m = a * b;
           Console.WriteLine("长方形的面积是：{0}", m);
       }
    }
}

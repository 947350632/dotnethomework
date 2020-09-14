using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace 图像面积计算
{
    /// <summary>
    /// 正方形的面积计算
    /// </summary>
    class Square
    {
        private float a, s;
        public void Area2()
        {
            Console.Write("请输入正方形的边长：");
            string s6 = Console.ReadLine();
            a = Convert.ToSingle(s6);
            s = a * a;
            Console.WriteLine("正方形的面积是：{0}", s);
        }
    }
}

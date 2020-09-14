using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 图像面积计算
{
    class Program
    {
        static void Main(string[] args)
        {
            for (; ; )
            {
                Console.WriteLine("\n==========欢迎进入图像Shape－面积计算=========\n");
                Console.WriteLine("****************************************************");
                Console.WriteLine("请输选择并且输入你要所求图形面积的序号：");
                Console.WriteLine("         1、三角形的面积");
                Console.WriteLine("         2、正方形的面积");
                Console.WriteLine("         3、长方形的面积");
                Console.WriteLine("-----------输入Q或者q选择退出--------");
                Console.WriteLine("****************************************************");
                if (true)
                {
                    int i = Convert.ToInt32(Console.ReadLine());
                    switch (i)
                    {
                        case 1: Triangle a = new Triangle();
                            a.Area1();
                            break;
                        case 2: Square b = new Square();
                            b.Area2();
                            break;
                        case 3: Rectangle c = new Rectangle();
                            c.Area3();
                            break;
                        default: throw new Exception("输入数字越界异常！\n");


                    }
                }
                else
                {
                     string f = Console.ReadLine();
                    if (f == "Q" || f == "q")
                        break;
                }


            }
        }
    }
}

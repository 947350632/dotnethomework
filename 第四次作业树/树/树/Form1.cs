using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace 树
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        public static int th1;
        public static int th2;
        public static int n;
        public static int leng;
        public static int per1;
        public static int per2;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int th1;
            try
            {
                th1 = int.Parse(textBox1.Text);
            }
            catch
            {
                MessageBox.Show("格式错误！");
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int th2;
            try
            {
                th2 = int.Parse(textBox2.Text);
            }
            catch
            {
                MessageBox.Show("格式错误！");
            }
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int n;
            try
            {
                n = int.Parse(textBox2.Text);
            }
            catch
            {
                MessageBox.Show("格式错误！");
            }
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            int leng;
            try
            {
                leng = int.Parse(textBox2.Text);
            }
            catch
            {
                MessageBox.Show("格式错误！");
            }
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            int per1;
            try
            {
                per1 = int.Parse(textBox2.Text);
            }
            catch
            {
                MessageBox.Show("格式错误！");
            }
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            int per2;
            try
            {
                per2 = int.Parse(textBox2.Text);
            }
            catch
            {
                MessageBox.Show("格式错误！");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (graphics == null) graphics = this.CreateGraphics();
            drawCayleyTree(n, 200, 310,  leng, -Math.PI / 2);
        }
        private Graphics graphics;

        void drawCayleyTree(int n,
        double x0, double y0, double leng, double th)
        {

            if (n == 0) return;
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            drawLine(x0, y0, x1, y1);
            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2);
        }
        void drawLine(double x0, double y0, double x1, double y1)
        {
            graphics.DrawLine(
 Pens.Black,
 (int)x0, (int)y0, (int)x1, (int)y1);


        }

     

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}


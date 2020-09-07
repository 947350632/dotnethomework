using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JiSuan
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
      
        string  a= null;
        string  b=null ;
        double   c=0 ;
        string panduan;
        private void Form1_Load(object sender, EventArgs e)
        {
            this.button1.Click += new System.EventHandler(button1_Click);
            this.button2.Click += new System.EventHandler(button1_Click);
            this.button3.Click += new System.EventHandler(button1_Click);
           
            this.button5.Click += new System.EventHandler(button1_Click);
            this.button6.Click += new System.EventHandler(button1_Click);
            this.button7.Click += new System.EventHandler(button1_Click);
            
            this.button9.Click += new System.EventHandler(button1_Click);
            this.button10.Click += new System.EventHandler(button1_Click);
            this.button11.Click += new System.EventHandler(button1_Click);
           
            this.button13.Click += new System.EventHandler(button1_Click);
            this.button14.Click += new System.EventHandler(button1_Click);
            this.button15.Click += new System.EventHandler(button1_Click);
            
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            a += ((Button)sender).Text;
            
            textBox1.Text = a.ToString();
        }

        

        private void button4_Click(object sender, EventArgs e)
        {
            b = a;
            a = null;
            panduan = "+";
             
        }

        private void button8_Click(object sender, EventArgs e)
        {
            b = a;
            a = null;
            panduan = "-";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            b = a;
            a = null;
            panduan = "*";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            b = a;
            a = null;
            panduan = "/";
        }


        private void button17_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            a = null; 
        }

        private void button18_Click(object sender, EventArgs e)
        {
            switch(panduan)
            {
                case "+":
                    c = Convert.ToDouble(b) + Convert.ToDouble(a);
                    textBox1.Text = c.ToString();
                    break;
                case "-":
                    c = Convert.ToDouble(b) -Convert.ToDouble(a);
                    textBox1.Text = c.ToString();
                    break;
                case "*":
                    c = Convert.ToDouble(b)*Convert.ToDouble(a);
                    textBox1.Text = c.ToString();
                    break;
                case "/":
                    c = Convert.ToDouble(b) /Convert.ToDouble(a);
                    textBox1.Text = c.ToString();
                    break;
                default:
                    break;

            }
        }
    }
}

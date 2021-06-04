using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WaVeSsSss_USRS_1_AlgorytmEK
{
    public partial class Form1 : Form
    {
        double PI = Math.PI;
        double speed, angle;
        double Vx0, Vy0;
        int x, y, xn, yn;
        int xMax = 0;
        int xMaxn = 0;
        int yMax = 0;
        int yMaxn = 0;
        double dt = 0.03;
        double t, tn;
        double G = 9.81;
        double k = 0.001;
        double PoverY;
        double PoverX;

        private void timer2_Tick(object sender, EventArgs e)
        {
            tn += dt;
            xn = (int)(Vx0 * tn + 3);
            yn = (int)(pictureBox1.Height - 5 - (Vy0 * tn - G * tn * tn / 2));
            textBox4.Text = Convert.ToString(tn);
            if (yn >= pictureBox1.Height - 5)
            {
                timer2.Enabled = false;
            }
            if (yMaxn < pictureBox1.Height - yn)
            {
                yMaxn = pictureBox1.Height - yn;
            }
            if (xMaxn < xn)
            {
                xMaxn = xn;
            }
            textBox6.Text = Convert.ToString(xMaxn);
            textBox8.Text = Convert.ToString(yMaxn);
            Graphics g = pictureBox1.CreateGraphics();
            Pen pen = new Pen(Color.Red, 2);
            g.DrawEllipse(pen, xn, yn, 5, 5);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            t += dt;
            x = (int)(Vx0 * t + 3 - PoverX * t * t / 2);
            y = (int)(pictureBox1.Height - 5 - (Vy0 * t - (PoverY + G) * t * t / 2));
            textBox3.Text = Convert.ToString(t);
            if (y >= pictureBox1.Height - 5)
            {
                timer1.Enabled = false;
            }
            if (yMax < pictureBox1.Height - y)
            {
                yMax = pictureBox1.Height - y;
            }
            if (xMax < x)
            {
                xMax = x;
            }
            textBox5.Text = Convert.ToString(xMax);
            textBox7.Text = Convert.ToString(yMax);
            Graphics g = pictureBox1.CreateGraphics();
            Pen pen = new Pen(Color.Blue, 2);
            g.DrawEllipse(pen, x, y, 5, 5);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Converta();
            t = 0;
            tn = 0;
            xMax = 0;
            yMax = 0;
            xMaxn = 0;
            yMaxn = 0;
            Vx0 = speed * Math.Cos(angle * PI / 180);
            Vy0 = speed * Math.Sin(angle * PI / 180);
            PoverX = Vx0 * speed * k;
            PoverY = Vy0 * speed * k;
            timer1.Enabled = true;
            timer2.Enabled = true;
        }


        public Form1()
        {
            InitializeComponent();
           
        }


        private void Converta()
        {
            try
            {
                speed = Convert.ToDouble(textBox1.Text);
                angle = Convert.ToDouble(textBox2.Text);
            }
            catch
            {
            }
        }

      
    }
}

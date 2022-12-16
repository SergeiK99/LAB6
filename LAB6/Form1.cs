using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LAB6
{
    public partial class Form1 : Form
    {
        Equation eq;
        public Form1()
        {
            InitializeComponent();
        }
        internal class SeriesCreator //Создаёт множество точек, которые формируют график
        {
            static public Series Get(Equation equation, double x1, double x2, int quality = 100)
            {
                double CurPoint;
                Series Value = new Series();
                Value.ChartType = SeriesChartType.Line;
                double h = (x2 - x1) / quality;
                for (int i = 0; i < quality; i++)
                {
                    CurPoint = x1 + i * h;
                    Value.Points.AddXY(CurPoint, equation.GetValue(CurPoint));
                }
                return Value;
            }
        }
        void DrawFunction(double x1, double x2 , Equation equation, int N = 100)
        {
            chart1.Series.Add(SeriesCreator.Get(equation,x1,x2,N));
        }
        void Clear()
        {
            chart1.Series.Clear();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pb1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="" & textBox2.Text == "" & textBox3.Text == "")
            {
                MessageBox.Show("Вы не выбрали значение A,B,C!");
                return;
            }
            if (textBox1.Text == "" )
            {
                MessageBox.Show("Вы не выбрали значение A");
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("Вы не выбрали значение B");
                return;
            }
            if (textBox3.Text == "")
            {
                MessageBox.Show("Вы не выбрали значение C");
                return;
            }
            eq = new QuadEquation ( a: Convert.ToInt32(textBox1.Text), b: Convert.ToInt32(textBox2.Text), c: Convert.ToInt32(textBox3.Text));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (eq==null)
            {
                MessageBox.Show("Вы не выбрали тип уравнения!");
                return;
            }
            int N;
            int.TryParse(textBox4.Text, out N);
            DrawFunction(x1: Convert.ToInt32(textBox5.Text),x2: Convert.ToInt32(textBox6.Text),eq,N: Convert.ToInt32(textBox4.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Вы не выбрали значение A!");
                return;
            }
            eq = new SinEquation(a: Convert.ToInt32(textBox1.Text));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int N;

            if (!Int32.TryParse(textBox4.Text, out N))
            {
                MessageBox.Show("Некорректное значение количества разбиений");
                return;

            }
            RectagleIntegrator Intgr = new RectagleIntegrator();
            MessageBox.Show($"{Intgr.ToString()}: {Intgr.Integrate(eq, Convert.ToInt32(textBox5.Text), Convert.ToInt32(textBox6.Text), Convert.ToInt32(textBox4.Text))}");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int N;

            if (!Int32.TryParse(textBox4.Text, out N))
            {
                MessageBox.Show("Некорректное значение количества разбиений");
                return;

            }
            TRIntegrator Intgr = new TRIntegrator();       
            MessageBox.Show($"{Intgr.ToString()}: {Intgr.Integrate(eq, x1: Convert.ToInt32(textBox5.Text), x2: Convert.ToInt32(textBox6.Text), N: Convert.ToInt32(textBox4.Text))}");
        }
    }
}

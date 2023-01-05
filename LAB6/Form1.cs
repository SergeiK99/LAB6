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
        public class SeriesCreator //Создаёт множество точек, которые формируют график
        {
            static public void Get(Series series,Equation equation, double x1, double x2, int quality = 100)
            {
                double CurPoint;
                //Series Value = new Series();
                //Value.ChartType = SeriesChartType.Line;
                series.ChartType = SeriesChartType.Line;
                double h = (x2 - x1) / quality;
                for (int i = 0; i < quality; i++)
                {
                    CurPoint = x1 + i * h;
                    series.Points.AddXY(CurPoint, equation.GetValue(CurPoint));
                    //Value.Points.AddXY(CurPoint, equation.GetValue(CurPoint));
                }
                //return Value;
            }
        }
        void DrawFunction(double x1, double x2 , Equation equation, int N = 100)
        {
            //chart1.Series.Add(SeriesCreator.Get(equation,x1,x2,N));
            SeriesCreator.Get(chart1.Series[0], equation, x1, x2, N);
        }
        void Clear()
        {
            chart1.Series[0].Points.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex;
            if (index==0)
            {
                if (textBox1.Text == "" & textBox2.Text == "" & textBox3.Text == "")
                {
                    MessageBox.Show("Вы не выбрали значение A,B,C!");
                    return;
                }
                if (textBox1.Text == "")
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
                eq = new QuadEquation(a: Convert.ToInt32(textBox1.Text), b: Convert.ToInt32(textBox2.Text), c: Convert.ToInt32(textBox3.Text));
            }
            if (index==1)
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Вы не выбрали значение A!");
                    return;
                }
                eq = new SinEquation(a: Convert.ToInt32(textBox1.Text));
            }
            if (index==-1)
            {
                MessageBox.Show("Вы не выбрали тип уравнения!");
                return;
            }

            int N;
            int.TryParse(textBox4.Text, out N);
            if (!Int32.TryParse(textBox4.Text, out N))
            {
                MessageBox.Show("Некорректное значение количества разбиений");
                return;

            }
            Clear();
            DrawFunction(x1: Convert.ToInt32(textBox5.Text),x2: Convert.ToInt32(textBox6.Text),eq,N: Convert.ToInt32(textBox4.Text));
        }


        private void button6_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {

            int index = comboBox1.SelectedIndex;
            if (index == 0)
            {
                if (textBox1.Text == "" & textBox2.Text == "" & textBox3.Text == "")
                {
                    MessageBox.Show("Вы не выбрали значение A,B,C!");
                    return;
                }
                if (textBox1.Text == "")
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
                eq = new QuadEquation(a: Convert.ToInt32(textBox1.Text), b: Convert.ToInt32(textBox2.Text), c: Convert.ToInt32(textBox3.Text));
            }
            if (index == 1)
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Вы не выбрали значение A!");
                    return;
                }
                eq = new SinEquation(a: Convert.ToInt32(textBox1.Text));
            }
            if (index == -1)
            {
                MessageBox.Show("Вы не выбрали тип уравнения!");
                return;
            }

            int N;
            int index2 = comboBox2.SelectedIndex;
            if (!Int32.TryParse(textBox4.Text, out N))
            {
                MessageBox.Show("Некорректное значение количества разбиений");
                return;

            }
            if (index2==-1)
            {
                MessageBox.Show("Не выбран метод интегрирования!");

            }
            if (index2==0)
            {
                RectagleIntegrator Intgr = new RectagleIntegrator();
                MessageBox.Show($"{Intgr.ToString()}: {Intgr.Integrate(eq, Convert.ToInt32(textBox5.Text), Convert.ToInt32(textBox6.Text), Convert.ToInt32(textBox4.Text))}");
            }
            if (index2==1)
            {
                TRIntegrator Intgr = new TRIntegrator();
                MessageBox.Show($"{Intgr.ToString()}: {Intgr.Integrate(eq, x1: Convert.ToInt32(textBox5.Text), x2: Convert.ToInt32(textBox6.Text), N: Convert.ToInt32(textBox4.Text))}");
            }
        }
    }
}

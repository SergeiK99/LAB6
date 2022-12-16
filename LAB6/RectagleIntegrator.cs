using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB6
{
    public class RectagleIntegrator : Integrator
    {
        public RectagleIntegrator()
        {

        }
        public override double Integrate(Equation equation, double x1, double x2, int N = 100)
        {
            if (equation == null)
            {
                throw new ArgumentNullException();
            }
            if (x1 >= x2)
            {
                throw new ArgumentException("Правая граница должна быть больше левой!");
            }
            //Ширина интеграла
            double h = (x2 - x1) / N;
            double sum = 0; //"Накопитель" значений интеграла
            for (int i = 0; i < N; i++)
            {
                var res = equation.GetValue(x1 + i * h);
                if (Double.IsNaN(res))
                    continue;
                sum = sum + res * h;
            }
            return sum;

        }
        public override string ToString()
        {
            return "Интегратор методом прямоугольников:";
        }
    }
}

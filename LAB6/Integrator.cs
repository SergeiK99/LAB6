using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB6
{
    abstract public class Integrator
    {

        abstract public double Integrate(Equation eqn, double x1, double x2, int N);
        abstract override public string ToString();
    }
}

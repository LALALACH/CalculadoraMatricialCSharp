using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraMatricial
{
    internal class calcularSoloDetMatriz2x2
    {
        public double soloDet2x2(double a1, double a2,
            double b1, double b2)
        {
            double  detA = (a1 * b2) - (a2 * b1);
            return detA;
        }
    }
}

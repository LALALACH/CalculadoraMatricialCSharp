using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraMatricial
{
    internal class calcularSoloDet
    {
        public double soloDet3x3(double a1, double a2, double a3,
            double b1, double b2, double b3,
            double c1, double c2, double c3)
        {
            double detA = (a1* b2 * c3) +(a2 * b3 * c1)+(a3*b1*c2)-(a3*b2*c1)-(a1*b3*c2)-(a2*b1*c3);
            return detA;
        }

    }
}

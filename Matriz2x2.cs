using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraMatricial
{
    internal class Matriz2x2
    {
        public double DetX2x2(double a1, double a2,
            double b1, double b2)
        {
            double detX = (a1 * b2) - (a2 * b1);
            return detX;
        }
        public double DetY2x2(double a1, double a2,
            double b1, double b2)
        {
            double detY = (a1 * b2) - (a2 * b1);
            return detY;
        }
    }
}

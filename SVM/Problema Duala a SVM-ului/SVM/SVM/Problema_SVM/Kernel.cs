using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVM.Problema_SVM
{
    public class Kernel
    {
        public static double RBF(double[] x1, double[] x2, double gamma)
        {
            double suma = 0;
            for (int i = 0; i < x1.Length; i++)
            {
                suma += Math.Pow(x1[i] - x2[i], 2);
            }
            return Math.Exp(-gamma * suma);
        }
    }
}

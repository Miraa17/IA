using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVM.Problema_SVM
{
    public class Constrangeri
    {
        public static double[] AjustareConstrangeri(double[] alpha, int[] y, double C)
        {
            double s = alpha.Zip(y, (a, b) => a * b).Sum();

            while (Math.Abs(s) > 1e-5)
            {
                int[] indices = s > 0
                    ? y.Select((v, i) => new { v, i }).Where(p => p.v == 1).Select(p => p.i).ToArray()
                    : y.Select((v, i) => new { v, i }).Where(p => p.v == -1).Select(p => p.i).ToArray();

                Random rnd = new Random();
                int k = indices[rnd.Next(indices.Length)];

                if (Math.Abs(s) > alpha[k])
                {
                    s -= alpha[k] * y[k];
                    alpha[k] = 0;
                }
                else
                {
                    alpha[k] -= Math.Abs(s);
                    s = 0;
                }

                alpha[k] = Math.Min(alpha[k], C);
            }
            return alpha;
        }
    }
}

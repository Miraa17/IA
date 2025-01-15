using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVM.Problema_SVM
{
    public class Problema_Duala
    {

        private double[][] x;   
        private int[] y;       
        private double[] alpha; 
        private double C;       
        private double gamma;  
        private Random rnd = new Random();
        private double[,] kernelMatrix;


        public Problema_Duala(double[][] x, int[] y, double C, double gamma)
        {
            this.x = x;
            this.y = y;
            this.C = C;
            this.gamma = gamma;

            alpha = new double[x.Length];
           

 


            for (int i = 0; i < alpha.Length; i++)
            {
                alpha[i] = rnd.NextDouble() * C;  
            }
        }

        public double CalculeazaFitness(double[] alpha)
        {
            double sumAlpha = alpha.Sum();
            double sumKernel = 0;

            for (int i = 0; i < alpha.Length; i++)
            {
                for (int j = 0; j < alpha.Length; j++)
                {
                    double kernel = Kernel.RBF(x[i], x[j], gamma);
                    sumKernel += alpha[i] * alpha[j] * y[i] * y[j] * kernel;
                }
            }
            return sumAlpha - 0.5 * sumKernel;
        }


        public double[] RuleazaAlgoritmul(int generatii, int dimensiunePopulatie, Action<int, double> progres = null)
        {
            List<double[]> populatie = new List<double[]>();

            for (int i = 0; i < dimensiunePopulatie; i++)
            {
                double[] individ = new double[x.Length];
                for (int j = 0; j < individ.Length; j++)
                {
                    individ[j] = rnd.NextDouble() * C;
                }
                populatie.Add(individ);
            }

            for (int g = 0; g < generatii; g++)
            {
                double[] fitness = populatie.Select(individ => CalculeazaFitness(individ)).ToArray();

                List<double[]> selectie = Selectie(populatie, fitness, dimensiunePopulatie / 2);

                while (selectie.Count < dimensiunePopulatie)
                {
                    int parinte1 = rnd.Next(selectie.Count);
                    int parinte2 = rnd.Next(selectie.Count);
                    double[] copil = Crossover(selectie[parinte1], selectie[parinte2]);
                    Mutatie(copil);
                    selectie.Add(copil);
                }

                foreach (var individ in selectie)
                {
                    Constrangeri.AjustareConstrangeri(individ, y,C);
                }

                populatie = selectie;

                
                progres?.Invoke(g, fitness.Max());
            }

            return populatie.OrderByDescending(individ => CalculeazaFitness(individ)).First();
        }

        private List<double[]> Selectie(List<double[]> populatie, double[] fitness, int nrSelectie)
        {
            return populatie
                .Select((ind, index) => new { Indiv = ind, Fitness = fitness[index] })
                .OrderByDescending(x => x.Fitness)
                .Take(nrSelectie)
                .Select(x => x.Indiv)
                .ToList();
        }

   
        private double[] Crossover(double[] parinte1, double[] parinte2)
        {
            double[] copil = new double[parinte1.Length];
            double alfa = rnd.NextDouble();

            for (int i = 0; i < copil.Length; i++)
            {
                copil[i] = alfa * parinte1[i] + (1 - alfa) * parinte2[i];
            }
            return copil;
        }

       
        private void Mutatie(double[] individ)
        {
            int index = rnd.Next(individ.Length);
            individ[index] += rnd.NextDouble() * 0.1 - 0.05;

            if (individ[index] < 0) individ[index] = 0;
            if (individ[index] > C) individ[index] = C;
        }


        public int Predict(double[] xNou)
        {
            if (xNou.Length != x[0].Length)
            {
                throw new ArgumentException("Dimensiunea instantei nu corespunde");
            }

            double sum = 0;
            for (int i = 0; i < alpha.Length; i++)
            {
                double kernel = Kernel.RBF(x[i], xNou, gamma);
                sum += alpha[i] * y[i] * kernel;
            }
            return sum >= 0 ? 1 : -1;
        }

        public double EvalueazaModel(double[][] testX, int[] testY)
        {
            int corecte = 0;
            for (int i = 0; i < testX.Length; i++)
            {
                if (Predict(testX[i]) == testY[i])
                    corecte++;
            }
            return (double)corecte / testX.Length;
        }

        public double CalculeazaAcuratete(List<double[]> testCaracteristici, List<int> testEtichete)
        {
            int corect = 0;

            for (int i = 0; i < testCaracteristici.Count; i++)
            {
                int predictie = Predict(testCaracteristici[i]);
                if (predictie == testEtichete[i])
                {
                    corect++;
                }
            }

            return (double)corect / testEtichete.Count * 100;
        }

        public double[] Alpha
        {
            get { return alpha; }
        }

    }
}

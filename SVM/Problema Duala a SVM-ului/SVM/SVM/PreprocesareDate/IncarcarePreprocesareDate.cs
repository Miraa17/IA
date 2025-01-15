using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using System.Reflection.Emit;

namespace SVM.PreprocesareDate
{
    public class IncarcarePreprocesareDate
    {
        public List<double[]> Caracteristici { get; private set; }
        public List<int> Etichete { get; private set; }
        public List<double[]> Antrenare_Caracteristici { get; private set; }
        public List<double[]> Test_Caracteristici { get; private set; }
        public List<int> Antrenare_Etichete { get; private set; }
        public List<int> Test_Etichete { get; private set; }



        public IncarcarePreprocesareDate(string filePath)
        {
            Caracteristici = new List<double[]>();
            Etichete = new List<int>();

            LoadData(filePath);

            NormalizareData();

            Impartire_Date(0.8);
        }

        private void LoadData(string filePath)
        {
            try
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    var values = line.Split(',');


                    int label = values[1] == "M" ? 1 : -1;
                    Etichete.Add(label);


                    double[] caracteristici = values.Skip(2).Select(v => double.Parse(v)).ToArray();
                    Caracteristici.Add(caracteristici);
                }

                Console.WriteLine("Incarcare date reusita");
                Console.WriteLine($"Numar Instante: {Caracteristici.Count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Eroare la incarcare: {ex.Message}");
            }
        }

        private void NormalizareData()
        {
            int n = Caracteristici[0].Length;

            for (int j = 0; j < n; j++)
            {
                double min = Caracteristici.Min(x => x[j]);
                double max = Caracteristici.Max(x => x[j]);


                foreach (var caracteristica in Caracteristici)
                {
                    caracteristica[j] = (caracteristica[j] - min) / (max - min);
                }
            }
            Console.WriteLine("Normalizare efectuata");
        }


        private void Impartire_Date(double procent_antrenare)
        {
            int nr_instante_antrenare = (int)(Caracteristici.Count * procent_antrenare);

            Antrenare_Caracteristici = Caracteristici.Take(nr_instante_antrenare).ToList();
            Test_Caracteristici = Caracteristici.Skip(nr_instante_antrenare).ToList();

            Antrenare_Etichete = Etichete.Take(nr_instante_antrenare).ToList();
            Test_Etichete = Etichete.Skip(nr_instante_antrenare).ToList();

            Console.WriteLine($"Date : {nr_instante_antrenare} pentru antrenament {Caracteristici.Count - nr_instante_antrenare} pentru test");
        }
    }
}

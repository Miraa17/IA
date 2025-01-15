using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SVM.PreprocesareDate;
using SVM.Problema_SVM;
using SVM;

namespace SVM
{
    public partial class rtbTestOutput : Form
    {

        private IncarcarePreprocesareDate loader;
        private Problema_Duala svm;
        public rtbTestOutput()
        {
            InitializeComponent();


        }

        private void Form1_Load(object sender, EventArgs e)
        {


            lblTitlu.TextAlign = ContentAlignment.MiddleCenter;

            gbIncarcare.BackColor = Color.Transparent;
            txtOutput.BackColor = Color.White;


            gbIncarcare.ForeColor = Color.Black;
            txtOutput.BorderStyle = BorderStyle.Fixed3D;


            chart1.Legends.Clear();
            chart1.Legends.Add("Legenda1");
            chart1.Series["Fitness"].Legend = "Legenda1";
            chart1.Series["Fitness"].LegendText = "Evoluția Fitness-ului";

            chart1.ChartAreas[0].AxisX.Title = "Generații";
            chart1.ChartAreas[0].AxisY.Title = "Fitness";
            chart1.Series["Fitness"].BorderWidth = 2;
            chart1.Series["Fitness"].Color = Color.Blue;

            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
        }


        private void btnIncarcareDate_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Data Files|*.data|All Files|*.*";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    loader = new IncarcarePreprocesareDate(dialog.FileName);

                    int sampleSize = 300;
                    var sampleCaracteristici = loader.Antrenare_Caracteristici.Take(sampleSize).ToList();
                    var sampleEtichete = loader.Antrenare_Etichete.Take(sampleSize).ToList();


                    txtOutput.Multiline = true;
                    txtOutput.Text = "Incarcare date reusita!" + Environment.NewLine + Environment.NewLine;
                    txtOutput.AppendText("Numar instante: " + loader.Caracteristici.Count + Environment.NewLine + Environment.NewLine);
                    txtOutput.AppendText("Normalizare efectuata" + Environment.NewLine + Environment.NewLine);
                    txtOutput.AppendText("Date: " + loader.Antrenare_Caracteristici.Count +
                                         " pentru antrenament, " +
                                         loader.Test_Caracteristici.Count + " pentru test" + Environment.NewLine + Environment.NewLine);


                    MessageBox.Show("Incarcare cu succes");
                }
                catch (Exception ex)
                {
                    txtOutput.Text = $"Eroare: {ex.Message}\n";
                }
            }
        }
        private async void btnAntrenare_Click_1(object sender, EventArgs e)
        {
            if (loader == null)
            {
                MessageBox.Show("Datele trebuiesc incarcate");
                return;
            }

            btnAntrenare.Enabled = false;
            btnTestare.Enabled = false;

            chart1.Series["Fitness"].Points.Clear();



            txtOutput.AppendText("\n\nSe realizeaza antrenarea modelului\n" + Environment.NewLine + Environment.NewLine);

            svm = new Problema_Duala(loader.Antrenare_Caracteristici.ToArray(),
            loader.Antrenare_Etichete.ToArray(), 1.0, 0.5);

          

            try
            {
                int generatii = 10;
                int dimPopulatie = 30;

                double[] alpha = await Task.Run(() =>
                {
                    return svm.RuleazaAlgoritmul(generatii, dimPopulatie, (generatie, fitness) =>
                    {

                        this.Invoke((MethodInvoker)delegate
                        {

                            txtOutput.AppendText($"--------------------------------\n");
                            txtOutput.AppendText($"Generatia {generatie}: Cel mai bun fitness = {fitness}\n");
                            chart1.Series["Fitness"].Points.AddXY(generatie + 1, fitness);

                        });
                    });
                });

                double acuratete = svm.EvalueazaModel(loader.Test_Caracteristici.ToArray(), loader.Test_Etichete.ToArray());

                txtOutput.AppendText(Environment.NewLine + Environment.NewLine + $"Antrenare finalizata!\nAcuratetea: {acuratete * 100:F2}%\n" + Environment.NewLine + Environment.NewLine);
            }
            catch (Exception ex)
            {
                txtOutput.AppendText($"Eroare la antrenare: {ex.Message}\n");
            }
            finally
            {
                btnAntrenare.Enabled = true;
                btnTestare.Enabled = true;
            }
        }


        private async void btnTestare_Click(object sender, EventArgs e)
        {
            if (svm == null || loader == null)
            {
                MessageBox.Show("Antrenati modelul");
                return;
            }

            btnTestare.Enabled = false;
            richTextBox1.Clear();
            richTextBox1.AppendText("Se incepe testarea" + Environment.NewLine + Environment.NewLine);

            await Task.Run(() =>
            {
                int corecte = 0;
                for (int i = 0; i < loader.Test_Caracteristici.Count; i++)
                {
                    double[] instanta = loader.Test_Caracteristici[i];
                    int predictie = svm.Predict(instanta);
                    int etichetaReala = loader.Test_Etichete[i];

                    string rezultat = $"Instanta {i + 1}: Predictie = {(predictie == 1 ? "Maligna" : "Benigna")}, " +
                                      $"Eticheta reala = {(etichetaReala == 1 ? "Maligna" : "Benigna")}" + Environment.NewLine;


                    this.Invoke((MethodInvoker)delegate
                    {
                        richTextBox1.SelectionColor = Color.Black;
                        richTextBox1.AppendText(rezultat);
                    });

                    if (predictie == etichetaReala)
                    {
                        corecte++;
                    }
                    else
                    {

                        this.Invoke((MethodInvoker)delegate
                        {
                            richTextBox1.SelectionColor = Color.Red;
                            richTextBox1.AppendText($"Predictie incorecta la instanta {i + 1}" + Environment.NewLine);
                            richTextBox1.SelectionColor = Color.Black;
                        });
                    }
                }


                double acuratete = (double)corecte / loader.Test_Caracteristici.Count * 100;
                this.Invoke((MethodInvoker)delegate
                {
                    richTextBox1.SelectionColor = Color.Blue;
                    richTextBox1.AppendText(Environment.NewLine + $"Acuratetea: {acuratete:F2}%" + Environment.NewLine);
                    richTextBox1.SelectionColor = Color.Black;
                });
            });

            btnTestare.Enabled = true;
        }




        private void txtInstantaNoua_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblTitlu_Click(object sender, EventArgs e)
        {

        }

        private void btnAlfa_Click(object sender, EventArgs e)
        {
            if (svm == null)
            {
                MessageBox.Show("Modelul nu a fost antrenat încă.");
                return;
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Vectori Suport (α > 0):\n");

            for (int i = 0; i < svm.Alpha.Length; i++)
            {
                if (svm.Alpha[i] > 1e-5)  
                {
                    sb.AppendLine($"α[{i + 1}] = {svm.Alpha[i]:F4}");
                }
            }

            Form vectoriForm = new Form();
            vectoriForm.Text = "Vectorii Suport";
            vectoriForm.Size = new Size(400, 500);  

            TextBox txtVectoriSuport = new TextBox();
            txtVectoriSuport.Multiline = true;
            txtVectoriSuport.ScrollBars = ScrollBars.Vertical;
            txtVectoriSuport.Dock = DockStyle.Fill;
            txtVectoriSuport.ReadOnly = true;
            txtVectoriSuport.Text = sb.ToString();

           
            vectoriForm.Controls.Add(txtVectoriSuport);
            vectoriForm.ShowDialog();
        }
    }
}

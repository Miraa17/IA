namespace SVM
{
    partial class rtbTestOutput
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rtbTestOutput));
            this.btnIncarcareDate = new System.Windows.Forms.Button();
            this.btnAntrenare = new System.Windows.Forms.Button();
            this.btnTestare = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.gbIncarcare = new System.Windows.Forms.GroupBox();
            this.lblTitlu = new System.Windows.Forms.Label();
            this.btnAlfa = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.gbIncarcare.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnIncarcareDate
            // 
            this.btnIncarcareDate.Location = new System.Drawing.Point(89, 21);
            this.btnIncarcareDate.Name = "btnIncarcareDate";
            this.btnIncarcareDate.Size = new System.Drawing.Size(140, 56);
            this.btnIncarcareDate.TabIndex = 0;
            this.btnIncarcareDate.Text = "Incarca Date";
            this.btnIncarcareDate.UseVisualStyleBackColor = true;
            this.btnIncarcareDate.Click += new System.EventHandler(this.btnIncarcareDate_Click_1);
            // 
            // btnAntrenare
            // 
            this.btnAntrenare.Location = new System.Drawing.Point(307, 21);
            this.btnAntrenare.Name = "btnAntrenare";
            this.btnAntrenare.Size = new System.Drawing.Size(185, 56);
            this.btnAntrenare.TabIndex = 1;
            this.btnAntrenare.Text = "Antrenare";
            this.btnAntrenare.UseVisualStyleBackColor = true;
            this.btnAntrenare.Click += new System.EventHandler(this.btnAntrenare_Click_1);
            // 
            // btnTestare
            // 
            this.btnTestare.Location = new System.Drawing.Point(563, 15);
            this.btnTestare.Name = "btnTestare";
            this.btnTestare.Size = new System.Drawing.Size(162, 68);
            this.btnTestare.TabIndex = 2;
            this.btnTestare.Text = "Testare Instanta";
            this.btnTestare.UseVisualStyleBackColor = true;
            this.btnTestare.Click += new System.EventHandler(this.btnTestare_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(20, 132);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.Size = new System.Drawing.Size(1012, 322);
            this.txtOutput.TabIndex = 5;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(1059, 6);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox1.Size = new System.Drawing.Size(623, 756);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.Text = "";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(89, 490);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Fitness";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(765, 251);
            this.chart1.TabIndex = 8;
            this.chart1.Text = "chart1";
            // 
            // gbIncarcare
            // 
            this.gbIncarcare.Controls.Add(this.btnAlfa);
            this.gbIncarcare.Controls.Add(this.chart1);
            this.gbIncarcare.Controls.Add(this.richTextBox1);
            this.gbIncarcare.Controls.Add(this.btnIncarcareDate);
            this.gbIncarcare.Controls.Add(this.txtOutput);
            this.gbIncarcare.Controls.Add(this.btnAntrenare);
            this.gbIncarcare.Controls.Add(this.btnTestare);
            this.gbIncarcare.Location = new System.Drawing.Point(168, 130);
            this.gbIncarcare.Name = "gbIncarcare";
            this.gbIncarcare.Size = new System.Drawing.Size(1650, 768);
            this.gbIncarcare.TabIndex = 9;
            this.gbIncarcare.TabStop = false;
            // 
            // lblTitlu
            // 
            this.lblTitlu.AutoSize = true;
            this.lblTitlu.Font = new System.Drawing.Font("Arial Narrow", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitlu.ForeColor = System.Drawing.Color.IndianRed;
            this.lblTitlu.Location = new System.Drawing.Point(658, 18);
            this.lblTitlu.Name = "lblTitlu";
            this.lblTitlu.Size = new System.Drawing.Size(542, 46);
            this.lblTitlu.TabIndex = 10;
            this.lblTitlu.Text = "Rezolvarea  Problemei Duale - SVM";
            this.lblTitlu.Click += new System.EventHandler(this.lblTitlu_Click);
            // 
            // btnAlfa
            // 
            this.btnAlfa.Location = new System.Drawing.Point(809, 15);
            this.btnAlfa.Name = "btnAlfa";
            this.btnAlfa.Size = new System.Drawing.Size(155, 68);
            this.btnAlfa.TabIndex = 9;
            this.btnAlfa.Text = "Vectori Suport";
            this.btnAlfa.UseVisualStyleBackColor = true;
            this.btnAlfa.Click += new System.EventHandler(this.btnAlfa_Click);
            // 
            // rtbTestOutput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1815, 886);
            this.Controls.Add(this.lblTitlu);
            this.Controls.Add(this.gbIncarcare);
            this.Name = "rtbTestOutput";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.gbIncarcare.ResumeLayout(false);
            this.gbIncarcare.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIncarcareDate;
        private System.Windows.Forms.Button btnAntrenare;
        private System.Windows.Forms.Button btnTestare;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.GroupBox gbIncarcare;
        private System.Windows.Forms.Label lblTitlu;
        private System.Windows.Forms.Button btnAlfa;
    }
}


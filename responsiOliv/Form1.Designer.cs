namespace responsiOliv
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pbLogo = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            namaDev = new TextBox();
            cbPilihProyek = new ComboBox();
            cbStatusKontrak = new ComboBox();
            label7 = new Label();
            label8 = new Label();
            tbFiturSelesai = new TextBox();
            tbJumlahBug = new TextBox();
            label9 = new Label();
            label10 = new Label();
            btnInsert = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            label11 = new Label();
            dataGridView1 = new DataGridView();
            label12 = new Label();
            label13 = new Label();
            lblGaji = new Label();
            lblSkor = new Label();
            lblGajiLabel = new Label();
            lblSkorLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // pbLogo
            // 
            pbLogo.Image = (Image)resources.GetObject("pbLogo.Image");
            pbLogo.Location = new Point(36, 44);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(50, 50);
            pbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pbLogo.TabIndex = 0;
            pbLogo.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(211, 54);
            label1.Name = "label1";
            label1.Size = new Size(187, 15);
            label1.TabIndex = 1;
            label1.Text = "PROJECT MANAGEMENT CENTER";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(202, 69);
            label2.Name = "label2";
            label2.Size = new Size(204, 15);
            label2.TabIndex = 2;
            label2.Text = "Developer Team Performance Tracker";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(36, 116);
            label3.Name = "label3";
            label3.Size = new Size(101, 15);
            label3.TabIndex = 3;
            label3.Text = "DATA DEVELOPER";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(36, 142);
            label4.Name = "label4";
            label4.Size = new Size(104, 15);
            label4.TabIndex = 4;
            label4.Text = "Nama Developer : ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(36, 171);
            label5.Name = "label5";
            label5.Size = new Size(75, 15);
            label5.TabIndex = 5;
            label5.Text = "Pilih proyek :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(36, 200);
            label6.Name = "label6";
            label6.Size = new Size(89, 15);
            label6.TabIndex = 6;
            label6.Text = "Status Kontrak :";
            // 
            // namaDev
            // 
            namaDev.Location = new Point(177, 134);
            namaDev.Name = "namaDev";
            namaDev.Size = new Size(379, 23);
            namaDev.TabIndex = 7;
            // 
            // cbPilihProyek
            // 
            cbPilihProyek.FormattingEnabled = true;
            cbPilihProyek.Location = new Point(177, 163);
            cbPilihProyek.Name = "cbPilihProyek";
            cbPilihProyek.Size = new Size(379, 23);
            cbPilihProyek.TabIndex = 8;
            // 
            // cbStatusKontrak
            // 
            cbStatusKontrak.FormattingEnabled = true;
            cbStatusKontrak.Location = new Point(177, 192);
            cbStatusKontrak.Name = "cbStatusKontrak";
            cbStatusKontrak.Size = new Size(379, 23);
            cbStatusKontrak.TabIndex = 9;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(36, 242);
            label7.Name = "label7";
            label7.Size = new Size(83, 15);
            label7.TabIndex = 10;
            label7.Text = "DATA KINERJA";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(36, 269);
            label8.Name = "label8";
            label8.Size = new Size(75, 15);
            label8.TabIndex = 11;
            label8.Text = "Fitur Selesai :";
            // 
            // tbFiturSelesai
            // 
            tbFiturSelesai.Location = new Point(177, 261);
            tbFiturSelesai.Name = "tbFiturSelesai";
            tbFiturSelesai.Size = new Size(66, 23);
            tbFiturSelesai.TabIndex = 12;
            // 
            // tbJumlahBug
            // 
            tbJumlahBug.Location = new Point(177, 290);
            tbJumlahBug.Name = "tbJumlahBug";
            tbJumlahBug.Size = new Size(66, 23);
            tbJumlahBug.TabIndex = 13;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(44, 277);
            label9.Name = "label9";
            label9.Size = new Size(0, 15);
            label9.TabIndex = 14;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(36, 298);
            label10.Name = "label10";
            label10.Size = new Size(75, 15);
            label10.TabIndex = 15;
            label10.Text = "Jumlah Bug :";
            // 
            // btnInsert
            // 
            btnInsert.BackColor = Color.MediumSpringGreen;
            btnInsert.Location = new Point(36, 349);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(104, 23);
            btnInsert.TabIndex = 16;
            btnInsert.Text = "INSERT";
            btnInsert.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.Turquoise;
            btnUpdate.Location = new Point(240, 349);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(104, 23);
            btnUpdate.TabIndex = 17;
            btnUpdate.Text = "UPDATE";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Salmon;
            btnDelete.Location = new Point(452, 349);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(104, 23);
            btnDelete.TabIndex = 18;
            btnDelete.Text = "DELETE";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(36, 392);
            label11.Name = "label11";
            label11.Size = new Size(138, 15);
            label11.TabIndex = 19;
            label11.Text = "DAFTAR PERFORMA TIM";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(36, 410);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(520, 107);
            dataGridView1.TabIndex = 20;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(262, 269);
            label12.Name = "label12";
            label12.Size = new Size(164, 15);
            label12.TabIndex = 21;
            label12.Text = "(Jumlah fitur yang dikerjakan)";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(262, 298);
            label13.Name = "label13";
            label13.Size = new Size(166, 15);
            label13.TabIndex = 22;
            label13.Text = "(Jumlah bug yang ditemukan)";
            // 
            // lblGaji
            // 
            lblGaji.AutoSize = true;
            lblGaji.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblGaji.ForeColor = Color.DarkGreen;
            lblGaji.Location = new Point(177, 343);
            lblGaji.Name = "lblGaji";
            lblGaji.Size = new Size(0, 15);
            lblGaji.TabIndex = 26;
            // 
            // lblSkor
            // 
            lblSkor.AutoSize = true;
            lblSkor.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSkor.Location = new Point(177, 323);
            lblSkor.Name = "lblSkor";
            lblSkor.Size = new Size(0, 15);
            lblSkor.TabIndex = 24;
            // 
            // lblGajiLabel
            // 
            lblGajiLabel.AutoSize = true;
            lblGajiLabel.Location = new Point(36, 343);
            lblGajiLabel.Name = "lblGajiLabel";
            lblGajiLabel.Size = new Size(0, 15);
            lblGajiLabel.TabIndex = 25;
            // 
            // lblSkorLabel
            // 
            lblSkorLabel.AutoSize = true;
            lblSkorLabel.Location = new Point(36, 323);
            lblSkorLabel.Name = "lblSkorLabel";
            lblSkorLabel.Size = new Size(0, 15);
            lblSkorLabel.TabIndex = 23;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(602, 560);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(dataGridView1);
            Controls.Add(label11);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnInsert);
            Controls.Add(lblGaji);
            Controls.Add(lblGajiLabel);
            Controls.Add(lblSkor);
            Controls.Add(lblSkorLabel);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(tbJumlahBug);
            Controls.Add(tbFiturSelesai);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(cbStatusKontrak);
            Controls.Add(cbPilihProyek);
            Controls.Add(namaDev);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pbLogo);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbLogo;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox namaDev;
        private ComboBox cbPilihProyek;
        private ComboBox cbStatusKontrak;
        private Label label7;
        private Label label8;
        private TextBox tbFiturSelesai;
        private TextBox tbJumlahBug;
        private Label label9;
        private Label label10;
        private Button btnInsert;
        private Button btnUpdate;
        private Button btnDelete;
        private Label label11;
        private DataGridView dataGridView1;
        private Label label12;
        private Label label13;
        private Label lblGaji;
        private Label lblSkor;
        private Label lblGajiLabel;
        private Label lblSkorLabel;
    }
}

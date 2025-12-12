using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace responsiOliv
{
    public partial class Form1 : Form
    {
        private DBManager dbManager;
        private List<DeveloperBase> allDevelopers;

        public Form1()
        {
            InitializeComponent();
            dbManager = new DBManager();
            InitializeForm();
            LoadData();

            // Mengaitkan Event Handler ke tombol (penting karena tidak ada di Designer.cs)
            btnInsert.Click += BtnInsert_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
        }

        private void InitializeForm()
        {
            // Set up ComboBox Status Kontrak
            cbStatusKontrak.Items.Add("Tetap");
            cbStatusKontrak.Items.Add("Freelancer");
            cbStatusKontrak.SelectedIndex = 0; // Default

            // Set up DataGridView - disable auto-generate and create columns in desired order
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.CellClick += DataGridView1_CellClick;

            CreateGridColumns();

            // Hide skor/gaji labels (if still present in UI)
            if (lblSkor != null) lblSkor.Visible = false;
            if (lblGaji != null) lblGaji.Visible = false;
        }

        private void CreateGridColumns()
        {
            dataGridView1.Columns.Clear();

            // order: nama, proyek, status, fitur, bug, skor, total gaji
            AddTextColumn("NamaDev", "Nama", 180);
            AddTextColumn("NamaProyek", "Proyek", 180);
            AddTextColumn("StatusKontrak", "Status", 100);
            AddTextColumn("FiturSelesai", "Fitur", 60);
            AddTextColumn("JumlahBug", "Bug", 60);
            AddTextColumn("Skor", "Skor", 60);
            AddTextColumn("GajiTotal", "Gaji (Rp)", 120, format: "N0", alignRight: true);
        }

        private void AddTextColumn(string dataPropertyName, string headerText, int width = 100, string format = null, bool alignRight = false)
        {
            var col = new DataGridViewTextBoxColumn
            {
                DataPropertyName = dataPropertyName,
                Name = dataPropertyName,
                HeaderText = headerText,
                Width = width,
                ReadOnly = true,
                // Make this column autosize to its content
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            if (!string.IsNullOrEmpty(format))
                col.DefaultCellStyle.Format = format;

            if (alignRight)
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dataGridView1.Columns.Add(col);
        }

        private void LoadData()
        {
            try
            {
                // 1. Muat Proyek ke ComboBox (cbPilihProyek)
                var proyekList = dbManager.GetProyek();
                cbPilihProyek.DataSource = proyekList;
                cbPilihProyek.DisplayMember = "NamaProyek";
                cbPilihProyek.ValueMember = "IdProyek";

                // 2. Muat Developer ke DataGridView (dataGridView1)
                allDevelopers = dbManager.GetAllDevelopers();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = allDevelopers;

                // Ensure columns resize to fit content after data is bound
                dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                // If you still want to hide any internal IDs (they won't be auto-generated now)
                if (dataGridView1.Columns.Contains("IdDev"))
                    dataGridView1.Columns["IdDev"].Visible = false;
                if (dataGridView1.Columns.Contains("IdProyek"))
                    dataGridView1.Columns["IdProyek"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memuat data: {ex.Message}\nPastikan koneksi PostgreSQL sudah benar!", "Error Koneksi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- Event Handler DataGrid ---

        // Klik pada DataGridView untuk memuat data ke Form
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Ambil objek developer dari baris yang diklik
                // Menggunakan DataBoundItem untuk mendapatkan objek PBO
                var selectedDev = dataGridView1.Rows[e.RowIndex].DataBoundItem as DeveloperBase;

                if (selectedDev != null)
                {
                    // Hitung Skor dan Gaji (polymorphism)
                    selectedDev.HitungSkor();
                    decimal totalGaji = selectedDev.HitungTotalGaji();

                    // Tampilkan data ke controls
                    namaDev.Text = selectedDev.NamaDev;
                    cbPilihProyek.SelectedValue = selectedDev.IdProyek;
                    cbStatusKontrak.SelectedItem = selectedDev.StatusKontrak;
                    tbFiturSelesai.Text = selectedDev.FiturSelesai.ToString();
                    tbJumlahBug.Text = selectedDev.JumlahBug.ToString();

                    // Simpan ID Dev di Tag Form untuk keperluan Update/Delete
                    this.Tag = selectedDev.IdDev;
                }
            }
        }

        // --- CRUD Operations ---

        // 1. INSERT (Mencatat data developer)
        private void BtnInsert_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            string status = cbStatusKontrak.SelectedItem.ToString();
            DeveloperBase newDev;

            // Polymorphism: Membuat instance kelas anak yang sesuai
            if (status.Equals("Tetap"))
                newDev = new DeveloperTetap();
            else // Freelancer
                newDev = new DeveloperFreelancer();

            // Isi properti
            newDev.NamaDev = namaDev.Text;
            newDev.IdProyek = cbPilihProyek.SelectedValue.ToString();
            newDev.StatusKontrak = status;
            newDev.FiturSelesai = int.Parse(tbFiturSelesai.Text);
            newDev.JumlahBug = int.Parse(tbJumlahBug.Text);
            newDev.IdDev = "D" + (allDevelopers.Count + 1).ToString("D3");

            try
            {
                dbManager.InsertDeveloper(newDev);
                MessageBox.Show("Data developer berhasil disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal menyimpan data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 2. UPDATE (Mengedit data developer)
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                MessageBox.Show("Pilih developer dari daftar performa terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidateInputs()) return;

            string idDev = this.Tag?.ToString() ?? string.Empty;
            if (string.IsNullOrEmpty(idDev))
            {
                MessageBox.Show("ID Developer tidak valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int fitur = int.Parse(tbFiturSelesai.Text);
            int bug = int.Parse(tbJumlahBug.Text);

            try
            {
                dbManager.UpdateDeveloper(idDev, fitur, bug);

                var local = allDevelopers?.FirstOrDefault(d => d.IdDev == idDev);
                if (local != null)
                {
                    local.FiturSelesai = fitur;
                    local.JumlahBug = bug;
                    local.HitungSkor();
                }

                MessageBox.Show("Data developer berhasil diperbarui!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memperbarui data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 3. DELETE (Menghapus data developer)
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                MessageBox.Show("Pilih developer dari daftar performa terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string idDev = this.Tag?.ToString() ?? string.Empty;
            if (string.IsNullOrEmpty(idDev))
            {
                MessageBox.Show("ID Developer tidak valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var result = MessageBox.Show($"Yakin ingin menghapus developer {namaDev.Text}?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    dbManager.DeleteDeveloper(idDev);
                    MessageBox.Show("Developer berhasil dihapus.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Gagal menghapus developer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // --- Utility Functions ---

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(namaDev.Text) || cbPilihProyek.SelectedValue == null)
            {
                MessageBox.Show("Nama Developer dan Proyek harus diisi.", "Peringatan");
                return false;
            }
            if (!int.TryParse(tbFiturSelesai.Text, out _) || !int.TryParse(tbJumlahBug.Text, out _))
            {
                MessageBox.Show("Fitur Selesai dan Jumlah Bug harus berupa angka.", "Peringatan");
                return false;
            }
            return true;
        }

        private void ClearInputs()
        {
            namaDev.Clear();
            // Reset ComboBoxes
            if (cbPilihProyek.Items.Count > 0) cbPilihProyek.SelectedIndex = 0;
            if (cbStatusKontrak.Items.Count > 0) cbStatusKontrak.SelectedIndex = 0;

            tbFiturSelesai.Clear();
            tbJumlahBug.Clear();
            this.Tag = null; // Clear selected ID
        }

        // Tambahkan deklarasi method yang dipanggil di designer jika belum ada
        // private void InitializeComponent() { ... }
        // private void Dispose(bool disposing) { ... }
    }
}
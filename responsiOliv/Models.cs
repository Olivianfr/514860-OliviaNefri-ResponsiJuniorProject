namespace responsiOliv
{
    // --- KELAS INDUK (BASE CLASS) ---
    public abstract class DeveloperBase
    {
        // Encapsulation: Menggunakan Property dengan accessors
        public string IdDev { get; set; } = string.Empty;
        public string NamaDev { get; set; } = string.Empty;
        public string IdProyek { get; set; } = string.Empty;
        public string StatusKontrak { get; set; } = string.Empty;
        public int FiturSelesai { get; set; }
        public int JumlahBug { get; set; }
        public int Skor { get; protected set; }
        public string NamaProyek { get; set; } = string.Empty;

        // Properti computed untuk gaji total (dipanggil dari UI)
        public decimal GajiTotal
        {
            get
            {
                HitungSkor();
                return HitungTotalGaji();
            }
        }

        // Metode Abstrak: Harus diimplementasikan oleh kelas anak (Polymorphism)
        public abstract void HitungSkor();
        public abstract decimal HitungTotalGaji();
    }

    // --- KELAS ANAK 1 (INHERITANCE) - FULLTIME ---
    public class DeveloperTetap : DeveloperBase
    {
        // Properti spesifik untuk Developer Tetap
        public decimal GajiPokokBulanan { get; set; } = 5000000;

        public override void HitungSkor()
        {
            // Skor untuk Developer Tetap: Skor = 10 × Fitur − 5 × Bug
            Skor = (FiturSelesai * 10) - (JumlahBug * 5);
        }

        public override decimal HitungTotalGaji()
        {
            // Total Gaji = Gaji Pokok + Skor × Rp20.000,00
            return GajiPokokBulanan + (Skor * 20000);
        }
    }

    // --- KELAS ANAK 2 (INHERITANCE) - FREELANCER ---
    public class DeveloperFreelancer : DeveloperBase
    {
        public override void HitungSkor()
        {
            // Skor untuk Freelancer: Skor = 100 × (1 − 2×Bug / 3×Fitur)
            // Jika Fitur = 0, Skor = 0 (untuk menghindari pembagian dengan 0)
            if (FiturSelesai == 0)
            {
                Skor = 0;
            }
            else
            {
                // Hitung dengan rumus: 100 * (1 - (2 * Bug) / (3 * Fitur))
                decimal calculation = 100 * (1 - (decimal)(2 * JumlahBug) / (3 * FiturSelesai));
                // Skor tidak boleh kurang dari 0
                Skor = (int)Math.Max(0, calculation);
            }
        }

        public override decimal HitungTotalGaji()
        {
            // Total Gaji berdasarkan Skor:
            // Skor ≥ 80: Rp500.000,00 × Fitur
            // 50 ≤ Skor < 80: Rp400.000,00 × Fitur
            // Skor < 50: Rp250.000,00 × Fitur

            decimal biayaPerFitur;

            if (Skor >= 80)
                biayaPerFitur = 500000;
            else if (Skor >= 50)
                biayaPerFitur = 400000;
            else
                biayaPerFitur = 250000;

            return FiturSelesai * biayaPerFitur;
        }
    }

    // --- KELAS DATA PROYEK (Untuk data grid) ---
    public class Proyek
    {
        public string IdProyek { get; set; } = string.Empty;
        public string NamaProyek { get; set; } = string.Empty;
        public string Client { get; set; } = string.Empty;
        public decimal Budget { get; set; }
    }
}
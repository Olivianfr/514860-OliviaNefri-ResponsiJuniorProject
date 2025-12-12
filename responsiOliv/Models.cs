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

        // Metode Umum
        public decimal HitungBonusKinerja()
        {
            // Contoh logika: Bonus berdasarkan fitur selesai dikurangi penalty bug
            return (FiturSelesai * 500000) - (JumlahBug * 100000);
        }
    }

    // --- KELAS ANAK 1 (INHERITANCE) ---
    public class DeveloperTetap : DeveloperBase
    {
        // Properti spesifik untuk Developer Tetap
        public decimal GajiPokokBulanan { get; set; } = 8000000;

        public override void HitungSkor()
        {
            // Skor untuk Developer Tetap: Fitur * 10 - Bug * 5
            Skor = (FiturSelesai * 10) - (JumlahBug * 5);
        }

        public override decimal HitungTotalGaji()
        {
            // Gaji Tetap = Gaji Pokok + Bonus Kinerja
            return GajiPokokBulanan + HitungBonusKinerja();
        }
    }

    // --- KELAS ANAK 2 (INHERITANCE) ---
    public class DeveloperFreelancer : DeveloperBase
    {
        // Properti spesifik untuk Freelancer
        public decimal BiayaPerFitur { get; set; } = 1500000;

        public override void HitungSkor()
        {
            // Skor untuk Freelancer: Fitur * 15 - Bug * 3
            Skor = (FiturSelesai * 15) - (JumlahBug * 3);
        }

        public override decimal HitungTotalGaji()
        {
            // Gaji Freelancer = (Fitur Selesai * Biaya Per Fitur) + Bonus Kinerja
            return (FiturSelesai * BiayaPerFitur) + HitungBonusKinerja();
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
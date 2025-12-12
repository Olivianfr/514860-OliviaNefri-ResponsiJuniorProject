## 👨‍💻 Author & Credits

**Nama**: Olivia Nefri  
**NIM**: 23/514860/TK/56532  
**Mata Kuliah**: Junior Project Semester 5 - Responsi  
**Institusi**: Universitas Gadjah Mada - Departemen Teknik Elektro dan Teknologi Informasi  
**Tahun**: 2025

## Responsi Junpro 2025 - Developer Performance Management System
Aplikasi desktop berbasis C# (Windows Forms) untuk mengelola data kinerja developer, proyek, dan perhitungan kompensasi otomatis menggunakan database PostgreSQL.

## ✨ Fitur Utama
1. CRUD Developer: Tambah, Edit, Hapus data developer.
2. Manajemen Proyek: Relasi developer dengan proyek dan klien.
3. Dual Contract System: Mendukung perhitungan berbeda untuk Karyawan Tetap dan Freelancer.
4. Kalkulasi Otomatis: Skor kinerja dan total gaji dihitung otomatis oleh sistem.

## 🧠 Logika Perhitungan (Business Logic)
Sistem menggunakan konsep Polymorphism untuk aturan bisnis yang berbeda antar kontrak:
1. Perhitungan Skor Performa

| Tipe Kontrak  | Rumus Skor   | Ketentuan |
| ------------- |------------- |:-------------:|
| Fulltime | (10 × Fitur) - (5 × Bug) | - |
| Freelance | $100 \times \left(1 - \frac{2 \times Bug}{3 \times Fitur}\right)$ | Minimal skor = 0 (tidak bisa negatif) |

2. Perhitungan Total Gaji

| Tipe Kontrak  | Rumus Gaji    |
| ------------- |-------------|
| Fulltime | Rp 5.000.000 (Gaji Pokok) + (Skor × Rp 20.000) |
| Freelance | Dihitung berdasarkan Tier Skor: |
| |  • Skor ≥ 80: Rp 500.000 × Fitur |
| |  • 50 ≤ Skor < 80: Rp 400.000 × Fitur |
| |  • Skor < 50: Rp 250.000 × Fitur |

## 🎓 Implementasi Konsep OOP
Sistem ini dibangun di atas 4 pilar utama Object-Oriented Programming (OOP) untuk memastikan kode yang bersih, modular, dan mudah dikembangkan. 
- Abstraction: Menyembunyikan kompleksitas perhitungan gaji dan skor dengan menyediakan blueprint umum. Keuntungan: Menciptakan standar interface yang konsisten tanpa perlu memikirkan detail implementasi di awal.
  ``` c#
  public abstract class DeveloperBase 
  { 
      // Method abstract memaksa kelas turunan untuk memiliki implementasi sendiri
      public abstract void HitungSkor(); 
      public abstract decimal HitungTotalGaji(); 
  }
  ```
- Inheritance: Menghindari duplikasi kode dengan mewariskan properti umum (seperti Id, Nama, JumlahBug) dari kelas induk ke kelas anak. Keuntungan: Efisiensi kode (reusable) dan struktur hierarki yang logis.
  ``` c#
  // DeveloperTetap mewarisi semua sifat DeveloperBase
  public class DeveloperTetap : DeveloperBase { ... } 

  // DeveloperFreelancer juga mewarisi DeveloperBase
  public class DeveloperFreelancer : DeveloperBase { ... }
  ```
- Polymorphism: Kemampuan objek untuk berubah bentuk dan perilaku pada saat runtime. Sistem menentukan perhitungan mana yang dipakai berdasarkan tipe kontrak yang dipilih user. Keuntungan: Fleksibilitas tinggi; kode utama tidak perlu diubah meski ada penambahan tipe developer baru.
  ``` c#
  // Variabel bertipe 'DeveloperBase' bisa berisi 'Tetap' atau 'Freelancer'
  DeveloperBase dev = statusKontrak == "Tetap" 
    ? new DeveloperTetap() 
    : new DeveloperFreelancer();

  dev.HitungSkor();              
  decimal gaji = dev.HitungTotalGaji();
  ```
- Encapsulation: Melindungi data sensitif agar tidak bisa diubah sembarangan dari luar kelas. Keuntungan: Keamanan data terjaga dan mencegah manipulasi nilai yang tidak valid (misal: mengubah skor tanpa menghitung ulang bug).
  ``` c#
  public int Skor { get; protected set; }
  public decimal GajiTotal 
  { 
      get 
      { 
          HitungSkor();
          return HitungTotalGaji(); 
      } 
  }
  ```

## 📊 Database Schema (PostgreSQL Stored Functions)
Sesuai instruksi soal untuk tidak menaruh raw query di C#, gunakan script ini di Query Tool pgAdmin:
1. Tabel: proyek. Menyimpan data induk proyek dan budget.
   ``` sql
   CREATE TABLE proyek (
        id_proyek VARCHAR(10) PRIMARY KEY,
        nama_proyek VARCHAR(100) NOT NULL,
        client VARCHAR(100) NOT NULL,
        budget DECIMAL(15, 2) DEFAULT 0
    );
   ```
2. Tabel: developer. Menyimpan data developer dan relasinya ke proyek.
   ``` sql
   CREATE TABLE developer (
        id_dev VARCHAR(10) PRIMARY KEY,         
        nama_dev VARCHAR(100) NOT NULL,
        id_proyek VARCHAR(10) NOT NULL,
        status_kontrak VARCHAR(20) NOT NULL,
        fitur_selesai INT DEFAULT 0 CHECK (fitur_selesai >= 0),
        jumlah_bug INT DEFAULT 0 CHECK (jumlah_bug >= 0),
        
        -- Constraint Relasi
        CONSTRAINT fk_proyek 
            FOREIGN KEY (id_proyek) 
            REFERENCES proyek(id_proyek) 
            ON DELETE RESTRICT
    );
   ```

## 📝 Additional Notes:
README ini ditambahkan tanpa mempengaruhi isi kode dari project responsi yang telah disubmit pada waktu yang telah ditentukan. Isi README ini hanya untuk menjelaskan beberapa bagian yang diperlukan. Terima kasih!

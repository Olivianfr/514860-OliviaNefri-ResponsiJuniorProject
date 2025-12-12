public abstract class DeveloperBase
{
    public string IdDev { get; set; }
    public string NamaDev { get; set; }
    public string IdProyek { get; set; }
    public string StatusKontrak { get; set; }
    public int FiturSelesai { get; set; }
    public int JumlahBug { get; set; }
    public int Skor { get; protected set; }
    public string NamaProyek { get; set; } // <-- Add this property
    public abstract void HitungSkor();
    public abstract decimal HitungTotalGaji();
}
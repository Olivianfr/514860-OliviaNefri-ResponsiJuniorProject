using System;
using System.Collections.Generic;
using System.Linq;
using Npgsql;

namespace responsiOliv
{
    public class DBManager
    {
        private readonly string _connectionString =
            "Host=localhost;Username=postgres;Password=informatika;Database=responsiOliv";

        public NpgsqlConnection GetConnection() => new NpgsqlConnection(_connectionString);

        // --- Metode untuk mendapatkan semua Developer dengan Nama Proyek ---
        public List<DeveloperBase> GetAllDevelopers()
        {
            var developers = new List<DeveloperBase>();
            var projects = GetAllProyek() ?? new List<Proyek>();
            
            string query = "SELECT * FROM developer";

            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string status = reader["status_kontrak"].ToString();
                        DeveloperBase dev = status == "Tetap" ? new DeveloperTetap() : new DeveloperFreelancer();

                        dev.IdDev = reader["id_dev"].ToString();
                        dev.IdProyek = reader["id_proyek"].ToString();
                        dev.NamaDev = reader["nama_dev"].ToString();
                        dev.StatusKontrak = status;
                        dev.FiturSelesai = Convert.ToInt32(reader["fitur_selesai"]);
                        dev.JumlahBug = Convert.ToInt32(reader["jumlah_bug"]);

                        // Cari nama proyek dari list projects yang sudah diambil
                        var proyek = projects.FirstOrDefault(p => p.IdProyek == dev.IdProyek);
                        dev.NamaProyek = proyek?.NamaProyek ?? dev.IdProyek ?? "-";

                        developers.Add(dev);
                    }
                }
            }
            return developers;
        }

        // Compatibility helper used by the form (Form1 calls GetProyek)
        public List<Proyek> GetProyek() => GetAllProyek();

        // --- Metode untuk mendapatkan semua Proyek ---
        public List<Proyek> GetAllProyek()
        {
            var projects = new List<Proyek>();
            string query = "SELECT * FROM proyek";

            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        projects.Add(new Proyek
                        {
                            IdProyek = reader["id_proyek"].ToString(),
                            NamaProyek = reader["nama_proyek"].ToString(),
                            Client = reader["client"].ToString(),
                            Budget = reader["budget"] is DBNull ? 0 : Convert.ToDecimal(reader["budget"])
                        });
                    }
                }
            }
            return projects;
        }

        // --- Metode untuk INSERT Developer ---
        public void InsertDeveloper(DeveloperBase dev)
        {
            string query = @"INSERT INTO developer (id_dev, id_proyek, nama_dev, status_kontrak, fitur_selesai, jumlah_bug)
                             VALUES (@id, @idproyek, @nama, @status, @fitur, @bug)";

            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("id", dev.IdDev);
                    cmd.Parameters.AddWithValue("idproyek", dev.IdProyek ?? string.Empty);
                    cmd.Parameters.AddWithValue("nama", dev.NamaDev ?? string.Empty);
                    cmd.Parameters.AddWithValue("status", dev.StatusKontrak ?? string.Empty);
                    cmd.Parameters.AddWithValue("fitur", dev.FiturSelesai);
                    cmd.Parameters.AddWithValue("bug", dev.JumlahBug);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // --- Metode untuk UPDATE Developer ---
        public void UpdateDeveloper(string idDev, int fiturSelesai, int jumlahBug)
        {
            string query = "UPDATE developer SET fitur_selesai = @fitur, jumlah_bug = @bug WHERE id_dev = @id";

            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("fitur", fiturSelesai);
                    cmd.Parameters.AddWithValue("bug", jumlahBug);
                    cmd.Parameters.AddWithValue("id", idDev);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // --- Metode untuk DELETE Developer ---
        public void DeleteDeveloper(string idDev)
        {
            string query = "DELETE FROM developer WHERE id_dev = @id";

            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("id", idDev);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciOtomasyonu.DerslerBilgi
{
    public class DersKod
    {
        SqlConnection _connection = new SqlConnection(@"Data Source =(localdb)\MSSQLLocalDB; initial catalog=OgrenciIsleriOtomasyonu;integrated security=true");
        private void ConnectionControl()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }
        public void Delete(int id)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Delete from Dersler where Id=@Id", _connection);

            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();
            _connection.Close();

        }

        public void Add(Ders ders)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("insert into Dersler values(@DersKodu,@Kredi,@Bolum,@OgretimUyesi,@Derslik,@BolumId,@DersAdi)", _connection);
            command.Parameters.AddWithValue("@DersKodu", ders.DersKodu);
            command.Parameters.AddWithValue("@Kredi", ders.Kredi);
            command.Parameters.AddWithValue("@Bolum", ders.Bolum);
            command.Parameters.AddWithValue("@OgretimUyesi", ders.OgretimUyesi);
            command.Parameters.AddWithValue("@Derslik", ders.Derslik);
            command.Parameters.AddWithValue("@BolumId", ders.BolumId);
            command.Parameters.AddWithValue("@DersAdi", ders.DersAdi);

            command.ExecuteNonQuery();

            _connection.Close();

        }
        public void Update(Ders ders)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Update Dersler set DersKodu=@DersKodu, Kredi=@Kredi, Bolum=@Bolum, OgretimUyesi=@OgretimUyesi, Derslik=@Derslik, BolumId=@BolumId, DersAdi=@DersAdi where Id=@Id", _connection);
            command.Parameters.AddWithValue("@DersKodu", ders.DersKodu);
            command.Parameters.AddWithValue("@Kredi", ders.Kredi);
            command.Parameters.AddWithValue("@Bolum", ders.Bolum);
            command.Parameters.AddWithValue("@OgretimUyesi", ders.OgretimUyesi);
            command.Parameters.AddWithValue("@Derslik", ders.Derslik);
            command.Parameters.AddWithValue("@BolumId", ders.BolumId);
            command.Parameters.AddWithValue("@Id", ders.Id);
            command.Parameters.AddWithValue("@DersAdi", ders.DersAdi);
            command.ExecuteNonQuery();

            _connection.Close();

        }

        public List<Ders> GetAll()
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Select * from Dersler", _connection);

            SqlDataReader reader = command.ExecuteReader();
            List<Ders> alinandDers = new List<Ders>();
            while (reader.Read())
            {
                Ders ogrenci = new Ders
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    DersKodu = reader["DersKodu"].ToString(),
                    Kredi = Convert.ToInt32(reader["Kredi"]),
                    Bolum = reader["Bolum"].ToString(),
                    OgretimUyesi = reader["OgretimUyesi"].ToString(),
                    Derslik = reader["Derslik"].ToString(),
                    BolumId = Convert.ToInt32( reader["BolumId"]),
                    DersAdi = reader["DersAdi"].ToString(),
                };
                alinandDers.Add(ogrenci);
            }
            reader.Close();
            _connection.Close();
            return alinandDers;
        }
        public List<Ders> BolumlerinDersiniGetir(int key)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Select * from Dersler  where BolumId='"+key+"'", _connection);
            SqlDataReader reader = command.ExecuteReader();
            List<Ders> alinandDers = new List<Ders>();
            while (reader.Read()) 
            {
                Ders ders = new Ders
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    DersKodu = reader["DersKodu"].ToString(),
                    Kredi = Convert.ToInt32(reader["Kredi"].ToString()),
                    Bolum = reader["Bolum"].ToString(),
                    OgretimUyesi = reader["OgretimUyesi"].ToString(),
                    Derslik = reader["Derslik"].ToString(),
                    BolumId = Convert.ToInt32(reader["BolumId"].ToString()),
                    DersAdi = reader["DersAdi"].ToString(),
                };
                alinandDers.Add(ders);
            }
            reader.Close();
            _connection.Close();
            return alinandDers;
        }

        public List<Ders> Search(string key)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Select * from Dersler where DersAdi like '%" + key + "%'", _connection);


            SqlDataReader reader = command.ExecuteReader();
            List<Ders> alinandDers = new List<Ders>();
            while (reader.Read())
            {
                Ders ogrenci = new Ders
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    DersKodu = reader["DersKodu"].ToString(),
                    Kredi = Convert.ToInt32(reader["Kredi"]),
                    Bolum = reader["Bolum"].ToString(),
                    OgretimUyesi = reader["OgretimUyesi"].ToString(),
                    Derslik = reader["Derslik"].ToString(),
                    BolumId = Convert.ToInt32(reader["BolumId"]),
                    DersAdi = reader["DersAdi"].ToString(),
                };
                alinandDers.Add(ogrenci);
            }
            reader.Close();
            _connection.Close();
            return alinandDers;
        }

    }
}

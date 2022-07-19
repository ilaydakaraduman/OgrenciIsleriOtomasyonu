using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciOtomasyonu.Yonetim
{
    public class YonetimKod
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
            SqlCommand command = new SqlCommand("Delete from Calisanlar where CalisanId=@CalisanId", _connection);

            command.Parameters.AddWithValue("@BolumId", id);
            command.ExecuteNonQuery();

            _connection.Close();

        }

        public void Add(Calisan calisan)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("insert into Calisanlar values(@CalisanAd,@CalisanSoyad,@CalisanTc,@CalisanSifre)", _connection);
            command.Parameters.AddWithValue("@CalisanAd", calisan.CalisanAd);
            command.Parameters.AddWithValue("@CalisanSoyad", calisan.CalisanSoyad);
            command.Parameters.AddWithValue("@CalisanTc", calisan.CalisanTc);
            command.Parameters.AddWithValue("@CalisanSifre", calisan.CalisanSifre);



            command.ExecuteNonQuery();

            _connection.Close();

        }
        public void Update(Calisan calisan)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Update Calisanlar set CalisanAd=@CalisanAd, CalisanSoyad=@CalisanSoyad, CalisanTc=@CalisanTc, CalisanSifre=@CalisanSifre where CalisanId=@CalisanId", _connection);
            command.Parameters.AddWithValue("@CalisanAd", calisan.CalisanAd);
            command.Parameters.AddWithValue("@CalisanSoyad", calisan.CalisanSoyad);
            command.Parameters.AddWithValue("@CalisanTc", calisan.CalisanTc);
            command.Parameters.AddWithValue("@CalisanSifre", calisan.CalisanSifre);
            command.ExecuteNonQuery();

            _connection.Close();

        }

        public List<Calisan> GetAll()
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Select * from Calisanlar", _connection);

            SqlDataReader reader = command.ExecuteReader();
            List<Calisan> calisanlar = new List<Calisan>();
            while (reader.Read())
            {
                Calisan calisan = new Calisan
                {
                    CalisanAd = reader["CalisanAd"].ToString(),
                    CalisanSoyad = reader["CalisanSoyad"].ToString(),
                    CalisanTc = reader["CalisanTc"].ToString(),
                    CalisanSifre = reader["CalisanSifre"].ToString(),
                    CalisanId = Convert.ToInt32(reader["CalisanId"].ToString()),

                };
                calisanlar.Add(calisan);
            }
            reader.Close();
            _connection.Close();
            return calisanlar;
        }
    }
}

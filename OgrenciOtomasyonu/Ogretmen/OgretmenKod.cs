using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciOtomasyonu.Ogretmen
{
    public class OgretmenKod
    {
        SqlConnection _connection = new SqlConnection(@"Data Source =(localdb)\MSSQLLocalDB; initial catalog=OgrenciIsleriOtomasyonu;integrated security=true");
        private void ConnectionControl()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }
        public List<Ogretmen> GetAll()
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Select * from Ogretmen", _connection);

            SqlDataReader reader = command.ExecuteReader();
            List<Ogretmen> ogretmenler = new List<Ogretmen>();
            while (reader.Read())
            {
                Ogretmen ogretmen = new Ogretmen
                {
                    OgrId = Convert.ToInt32(reader["OgrId"]),
                    OgrTc = reader["OgrTc"].ToString(),
                    OgrAd = reader["OgrAd"].ToString(),
                    OgrSoyad = reader["OgrSoyad"].ToString(),
                    OgrSicilNo = Convert.ToInt32(reader["OgrSicilNo"]),
                    OgrVerdigiBolum = reader["OgrVerdigiBolum"].ToString(),
                    OgrVerdigiDersler = reader["OgrVerdigiDersler"].ToString(),
                    Sifre = reader["Sifre"].ToString(),
                    BolumId = Convert.ToInt32(reader["BolumId"]),
                };
                ogretmenler.Add(ogretmen);
            }
            reader.Close();
            _connection.Close();
            return ogretmenler;
        }
        public List<Ogretmen> Search(string key)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Select * from Ogretmen where OgrAd like '%" + key + "%'", _connection);

            SqlDataReader reader = command.ExecuteReader();
            List<Ogretmen> ogretmenler = new List<Ogretmen>();
            while (reader.Read())
            {
                Ogretmen ogretmen = new Ogretmen
                {
                    OgrId = Convert.ToInt32(reader["OgrId"]),
                    OgrTc = reader["OgrTc"].ToString(),
                    OgrAd = reader["OgrAd"].ToString(),
                    OgrSoyad = reader["OgrSoyad"].ToString(),
                    OgrSicilNo = Convert.ToInt32(reader["OgrSicilNo"]),
                    OgrVerdigiBolum = reader["OgrVerdigiBolum"].ToString(),
                    OgrVerdigiDersler = reader["OgrVerdigiDersler"].ToString(),
                    Sifre = reader["Sifre"].ToString(),
                    BolumId = Convert.ToInt32(reader["BolumId"]),
                };
                ogretmenler.Add(ogretmen);
            }
            reader.Close();
            _connection.Close();
            return ogretmenler;
        }
        public List<Ogretmen> BolumlerinOgretmenleriGetir(int key)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Select * from Ogretmen  where BolumId='" + key + "'", _connection);
            SqlDataReader reader = command.ExecuteReader();
            List<Ogretmen> ogretmenler = new List<Ogretmen>();
            while (reader.Read())
            {
                Ogretmen ogretmen = new Ogretmen
                {
                    OgrId = Convert.ToInt32(reader["OgrId"]),
                    OgrTc = reader["OgrTc"].ToString(),
                    OgrAd = reader["OgrAd"].ToString(),
                    OgrSoyad = reader["OgrSoyad"].ToString(),
                    OgrSicilNo = Convert.ToInt32(reader["OgrSicilNo"]),
                    OgrVerdigiBolum = reader["OgrVerdigiBolum"].ToString(),
                    OgrVerdigiDersler = reader["OgrVerdigiDersler"].ToString(),
                    Sifre = reader["Sifre"].ToString(),
                    BolumId = Convert.ToInt32(reader["BolumId"]),
                };
                ogretmenler.Add(ogretmen);
            }
            reader.Close();
            _connection.Close();
            return ogretmenler;
        }
        public void Add(Ogretmen ogretmen)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("insert into Ogretmen values(@OgrTc,@OgrAd,@OgrSoyad,@OgrSicilNo , @OgrVerdigiBolum , @OgrVerdigiDersler ,@Sifre, @BolumId)", _connection);
            command.Parameters.AddWithValue("@OgrTc", ogretmen.OgrTc);
            command.Parameters.AddWithValue("@OgrAd", ogretmen.OgrAd);
            command.Parameters.AddWithValue("@OgrSoyad", ogretmen.OgrSoyad);
            command.Parameters.AddWithValue("@OgrSicilNo", ogretmen.OgrSicilNo);
            command.Parameters.AddWithValue("@OgrVerdigiBolum", ogretmen.OgrVerdigiBolum);
            command.Parameters.AddWithValue("@OgrVerdigiDersler", ogretmen.OgrVerdigiDersler);
            command.Parameters.AddWithValue("@Sifre", ogretmen.Sifre);
            command.Parameters.AddWithValue("@BolumId", ogretmen.BolumId);

            command.ExecuteNonQuery();

            _connection.Close();

        }
        public void Update(Ogretmen ogretmen)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Update Ogretmen set OgrTc=@OgrTc, OgrAd=@OgrAd, OgrSoyad=@OgrSoyad, OgrSicilNo=@OgrSicilNo, OgrVerdigiBolum=@OgrVerdigiBolum, OgrVerdigiDersler=@OgrVerdigiDersler , Sifre= @Sifre, BolumId=@BolumId where OgrId =@OgrId", _connection);
            command.Parameters.AddWithValue("@OgrTc", ogretmen.OgrTc);
            command.Parameters.AddWithValue("@OgrAd", ogretmen.OgrAd);
            command.Parameters.AddWithValue("@OgrSoyad", ogretmen.OgrSoyad);
            command.Parameters.AddWithValue("@OgrSicilNo", ogretmen.OgrSicilNo);
            command.Parameters.AddWithValue("@OgrVerdigiBolum", ogretmen.OgrVerdigiBolum);
            command.Parameters.AddWithValue("@OgrVerdigiDersler", ogretmen.OgrVerdigiDersler);
            command.Parameters.AddWithValue("@Sifre", ogretmen.Sifre);
            command.Parameters.AddWithValue("@OgrId", ogretmen.OgrId);
            command.Parameters.AddWithValue("@BolumId", ogretmen.BolumId);
            command.ExecuteNonQuery();

            _connection.Close();

        }
        public void Delete(int id)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Delete from Ogretmen where OgrId=@OgrId", _connection);

            command.Parameters.AddWithValue("@OgrId", id);
            command.ExecuteNonQuery();

            _connection.Close();

        }
    }
}

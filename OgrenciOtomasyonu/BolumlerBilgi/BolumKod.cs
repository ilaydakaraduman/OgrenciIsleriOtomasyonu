using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciOtomasyonu.BolumlerBilgi
{
    public class BolumKod
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
            SqlCommand command = new SqlCommand("Delete from Bolum where BolumId=@BolumId", _connection);

            command.Parameters.AddWithValue("@BolumId", id);
            command.ExecuteNonQuery();

            _connection.Close();

        }

        public void Add(Bolum bolum)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("insert into Bolum values(@BolumAd,@BolumKodu,@AlinanDersler)", _connection);
            command.Parameters.AddWithValue("@BolumAd", bolum.BolumAd);
            command.Parameters.AddWithValue("@BolumKodu", bolum.BolumKodu);
            command.Parameters.AddWithValue("@AlinanDersler", bolum.AlinanDersler);
            


            command.ExecuteNonQuery();

            _connection.Close();

        }
        public void Update(Bolum bolum)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Update Bolum set BolumAd=@BolumAd, BolumKodu=@BolumKodu, AlinanDersler=@AlinanDersler where BolumId=@BolumId", _connection);
            command.Parameters.AddWithValue("@BolumAd", bolum.BolumAd);
            command.Parameters.AddWithValue("@BolumKodu", bolum.BolumKodu);
            command.Parameters.AddWithValue("@AlinanDersler", bolum.AlinanDersler);
            command.Parameters.AddWithValue("@BolumId", bolum.BolumId);
            command.ExecuteNonQuery();

            _connection.Close();

        }

        public List<Bolum> GetAll()
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Select * from Bolum", _connection);

            SqlDataReader reader = command.ExecuteReader();
            List<Bolum> bolumler = new List<Bolum>();
            while (reader.Read())
            {
                Bolum bolum = new Bolum
                {
                    BolumAd = reader["BolumAd"].ToString(),
                    BolumKodu = reader["BolumKodu"].ToString(),
                    AlinanDersler = reader["AlinanDersler"].ToString(),
                    BolumId = Convert.ToInt32(reader["BolumId"].ToString()),

                };
                bolumler.Add(bolum);
            }
            reader.Close();
            _connection.Close();
            return bolumler;
        }
    }
}

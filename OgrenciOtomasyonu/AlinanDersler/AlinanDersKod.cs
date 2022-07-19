using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciOtomasyonu.AlinanDersler
{
    public class AlinanDersKod
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
            SqlCommand command = new SqlCommand("Delete from AlinanDersler where Id=@Id", _connection);

            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();

            _connection.Close();

        }

        public void Add(AlinanDers alinanDers)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("insert into AlinanDersler values(@OgrenciNo,@DersId,@Vize,@Final,@Ortalama,@DersAdi,@DersKredi)", _connection);
            command.Parameters.AddWithValue("@OgrenciNo", alinanDers.OgrenciNo);
            command.Parameters.AddWithValue("@DersId", alinanDers.DersId);
            command.Parameters.AddWithValue("@Vize", alinanDers.Vize);
            command.Parameters.AddWithValue("@Final", alinanDers.Final);
            command.Parameters.AddWithValue("@Ortalama", alinanDers.Ortalama);
            command.Parameters.AddWithValue("@DersAdi", alinanDers.DersAdi);
            command.Parameters.AddWithValue("@DersKredi", alinanDers.DersKredi);



            command.ExecuteNonQuery();

            _connection.Close();

        }
        public void Update(AlinanDers alinanDers)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Update AlinanDersler set OgrenciNo=@OgrenciNo, DersId=@DersId, Vize=@Vize, Final=@Final, Ortalama=@Ortalama,DersAdi=@DersAdi,DersKredi=@DersKredi where Id=@Id", _connection);
            command.Parameters.AddWithValue("@OgrenciNo", alinanDers.OgrenciNo);
            command.Parameters.AddWithValue("@DersId", alinanDers.DersId);
            command.Parameters.AddWithValue("@Vize", alinanDers.Vize);
            command.Parameters.AddWithValue("@Final", alinanDers.Final);
            command.Parameters.AddWithValue("@Ortalama", alinanDers.Ortalama);
            command.Parameters.AddWithValue("@Id", alinanDers.Id);
            command.Parameters.AddWithValue("@DersAdi", alinanDers.DersAdi);
            command.Parameters.AddWithValue("@DersKredi", alinanDers.DersKredi);
            command.ExecuteNonQuery();

            _connection.Close();

        }

        public List<AlinanDers> GetAll()
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Select * from AlinanDersler", _connection);

            SqlDataReader reader = command.ExecuteReader();
            List<AlinanDers> alinanDersler = new List<AlinanDers>();
            while (reader.Read())
            {
                AlinanDers alinanDers = new AlinanDers
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    OgrenciNo = reader["OgrenciNo"].ToString(),
                    DersId = Convert.ToInt32(reader["DersId"].ToString()),
                    Vize = Convert.ToDecimal( reader["Vize"].ToString()),
                    Final = Convert.ToDecimal(reader["Final"].ToString()),
                    Ortalama = Convert.ToDecimal( reader["Ortalama"].ToString()),
                    DersAdi = reader["DersAdi"].ToString(),
                    DersKredi = Convert.ToInt32(reader["DersKredi"].ToString()),
                };
                alinanDersler.Add(alinanDers);
            }
            reader.Close();
            _connection.Close();
            return alinanDersler;
        }

        public List<AlinanDers> OgrenciDersGetirFiltreli(string key)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Select * from AlinanDersler where OgrenciNo ='" + key + "'", _connection);

            SqlDataReader reader = command.ExecuteReader();
            List<AlinanDers> alinanDersler = new List<AlinanDers>();
            while (reader.Read())
            {
                AlinanDers alinanDers = new AlinanDers
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    OgrenciNo = reader["OgrenciNo"].ToString(),
                    DersId = Convert.ToInt32(reader["DersId"].ToString()),
                    Vize = Convert.ToDecimal(reader["Vize"].ToString()),
                    Final = Convert.ToDecimal(reader["Final"].ToString()),
                    Ortalama = Convert.ToDecimal(reader["Ortalama"].ToString()),
                    DersAdi = reader["DersAdi"].ToString(),
                    DersKredi = Convert.ToInt32(reader["DersKredi"].ToString()),
                };
                alinanDersler.Add(alinanDers);
            }
            reader.Close();
            _connection.Close();
            return alinanDersler;
        }
    }
   
}

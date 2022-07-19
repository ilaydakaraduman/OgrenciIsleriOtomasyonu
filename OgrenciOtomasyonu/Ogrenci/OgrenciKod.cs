using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciOtomasyonu.Ogrenci
{
    public class OgrenciKod
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
            SqlCommand command = new SqlCommand("Delete from Ogrenci where OgrenciId=@OgrenciId", _connection);

            command.Parameters.AddWithValue("@OgrenciId", id);
            command.ExecuteNonQuery();

            _connection.Close();

        }
        
        public void Add(Ogrenci ogrenci)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("insert into Ogrenci values(@OgrenciNo,@OgrenciTc,@OgrenciIsim,@OgrenciSoyisim,@BulunduguBolum,@Telefon,@IsCap,@AldigiDersler,@Ortalamasi,@BolumId,@Sifre)", _connection);
            command.Parameters.AddWithValue("@OgrenciNo", ogrenci.OgrenciNo);
            command.Parameters.AddWithValue("@OgrenciTc", ogrenci.OgrenciTc);
            command.Parameters.AddWithValue("@OgrenciIsim", ogrenci.OgrenciIsim);
            command.Parameters.AddWithValue("@OgrenciSoyisim", ogrenci.OgrenciSoyisim);
            command.Parameters.AddWithValue("@BulunduguBolum", ogrenci.BulunduguBolum);
            command.Parameters.AddWithValue("@Telefon", ogrenci.Telefon);
            command.Parameters.AddWithValue("@IsCap", ogrenci.IsCap);
            command.Parameters.AddWithValue("@AldigiDersler", ogrenci.AldigiDersler);
            command.Parameters.AddWithValue("@Ortalamasi", ogrenci.Ortalamasi);
            command.Parameters.AddWithValue("@BolumId", ogrenci.BolumId);
            command.Parameters.AddWithValue("@Sifre", ogrenci.Sifre);

            command.ExecuteNonQuery();

            _connection.Close();

        }
        public void Update(Ogrenci ogrenci)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Update Ogrenci set OgrenciNo=@OgrenciNo, OgrenciTc=@OgrenciTc, OgrenciIsim=@OgrenciIsim, OgrenciSoyisim=@OgrenciSoyisim, BulunduguBolum=@BulunduguBolum, Telefon=@Telefon ,IsCap=@IsCap ,AldigiDersler=@AldigiDersler ,Ortalamasi=@Ortalamasi ,BolumId=@BolumId, Sifre=@Sifre where OgrenciId=@OgrenciId", _connection);
            command.Parameters.AddWithValue("@OgrenciNo", ogrenci.OgrenciNo);
            command.Parameters.AddWithValue("@OgrenciTc", ogrenci.OgrenciTc);
            command.Parameters.AddWithValue("@OgrenciIsim", ogrenci.OgrenciIsim);
            command.Parameters.AddWithValue("@OgrenciSoyisim", ogrenci.OgrenciSoyisim);
            command.Parameters.AddWithValue("@BulunduguBolum", ogrenci.BulunduguBolum);
            command.Parameters.AddWithValue("@Telefon", ogrenci.Telefon);
            command.Parameters.AddWithValue("@IsCap", ogrenci.IsCap);
            command.Parameters.AddWithValue("@AldigiDersler", ogrenci.AldigiDersler);
            command.Parameters.AddWithValue("@Ortalamasi", Convert.ToDecimal(ogrenci.Ortalamasi));
            command.Parameters.AddWithValue("@BolumId", ogrenci.BolumId);
            command.Parameters.AddWithValue("@OgrenciId", ogrenci.OgrenciId);
            command.Parameters.AddWithValue("@Sifre", ogrenci.Sifre);
            command.ExecuteNonQuery();

            _connection.Close();

        }

        public List<Ogrenci> GetAll()
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Select * from Ogrenci", _connection);

            SqlDataReader reader = command.ExecuteReader();
            List<Ogrenci> ogrenciler = new List<Ogrenci>();
            while (reader.Read())
            {
                Ogrenci ogrenci = new Ogrenci
                {
                    OgrenciId = Convert.ToInt32(reader["OgrenciId"]),
                    OgrenciNo = reader["OgrenciNo"].ToString(),
                    OgrenciTc = reader["OgrenciTc"].ToString(),
                    OgrenciIsim = reader["OgrenciIsim"].ToString(),
                    OgrenciSoyisim = reader["OgrenciSoyisim"].ToString(),
                    BulunduguBolum = reader["BulunduguBolum"].ToString(),
                    Telefon = reader["Telefon"].ToString(),
                    IsCap = reader["IsCap"].ToString(),
                    AldigiDersler = reader["AldigiDersler"].ToString(),
                    Ortalamasi = Convert.ToDouble( reader["Ortalamasi"].ToString()),
                    BolumId = Convert.ToInt32( reader["BolumId"].ToString()),
                    Sifre = reader["Sifre"].ToString(),
                };
                ogrenciler.Add(ogrenci);
            }
            reader.Close();
            _connection.Close();
            return ogrenciler;
        }
        public List<Ogrenci> BolumFiltreliOgrenci(int key)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Select * from Ogrenci where BolumId ='"+key+"'", _connection);
            SqlDataReader reader = command.ExecuteReader();
            List<Ogrenci> ogrenciler = new List<Ogrenci>();
            while (reader.Read())
            {
                Ogrenci ogrenci = new Ogrenci
                {
                    OgrenciId = Convert.ToInt32(reader["OgrenciId"]),
                    OgrenciNo = reader["OgrenciNo"].ToString(),
                    OgrenciTc = reader["OgrenciTc"].ToString(),
                    OgrenciIsim = reader["OgrenciIsim"].ToString(),
                    OgrenciSoyisim = reader["OgrenciSoyisim"].ToString(),
                    BulunduguBolum = reader["BulunduguBolum"].ToString(),
                    Telefon = reader["Telefon"].ToString(),
                    IsCap = reader["IsCap"].ToString(),
                    AldigiDersler = reader["AldigiDersler"].ToString(),
                    Ortalamasi = Convert.ToDouble(reader["Ortalamasi"].ToString()),
                    BolumId =Convert.ToInt32( reader["BolumId"].ToString()),
                    Sifre = reader["Sifre"].ToString(),
                };
                ogrenciler.Add(ogrenci);
            }
            reader.Close();
            _connection.Close();
            return ogrenciler;
        }
        public List<Ogrenci> OgrenciNoFiltreliOgrenci(string key)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Select * from Ogrenci where OgrenciNo like '%" + key + "%'", _connection);
            SqlDataReader reader = command.ExecuteReader();
            List<Ogrenci> ogrenciler = new List<Ogrenci>();
            while (reader.Read())
            {
                Ogrenci ogrenci = new Ogrenci
                {
                    OgrenciId = Convert.ToInt32(reader["OgrenciId"]),
                    OgrenciNo = reader["OgrenciNo"].ToString(),
                    OgrenciTc = reader["OgrenciTc"].ToString(),
                    OgrenciIsim = reader["OgrenciIsim"].ToString(),
                    OgrenciSoyisim = reader["OgrenciSoyisim"].ToString(),
                    BulunduguBolum = reader["BulunduguBolum"].ToString(),
                    Telefon = reader["Telefon"].ToString(),
                    IsCap = reader["IsCap"].ToString(),
                    AldigiDersler = reader["AldigiDersler"].ToString(),
                    Ortalamasi = Convert.ToDouble(reader["Ortalamasi"].ToString()),
                    BolumId = Convert.ToInt32(reader["BolumId"].ToString()),
                    Sifre = reader["Sifre"].ToString(),
                };
                ogrenciler.Add(ogrenci);
            }
            reader.Close();
            _connection.Close();
            return ogrenciler;
        }
        //public bool OgrenciNoKontrol(string key)
        //{
        //   // SELECT<columnName> FROM<yourTable> WHERE CONTAINS (< columnName >, '<yourSubstring>');
        //    ConnectionControl();
        //    SqlCommand command = new SqlCommand("SELECT OgrenciNo FROM Ogrenci WHERE CONTAINS (OgrenciNo,'456')", _connection);
        //    SqlDataReader reader = command.ExecuteReader();
        //    List<Ogrenci> ogrenciler = new List<Ogrenci>();
        //    while (reader.Read())
        //    {
        //        Ogrenci ogrenci = new Ogrenci
        //        {
        //            OgrenciId = Convert.ToInt32(reader["OgrenciId"]),
        //            OgrenciNo = reader["OgrenciNo"].ToString(),
        //            OgrenciTc = reader["OgrenciTc"].ToString(),
        //            OgrenciIsim = reader["OgrenciIsim"].ToString(),
        //            OgrenciSoyisim = reader["OgrenciSoyisim"].ToString(),
        //            BulunduguBolum = reader["BulunduguBolum"].ToString(),
        //            Telefon = reader["Telefon"].ToString(),
        //            IsCap = reader["IsCap"].ToString(),
        //            AldigiDersler = reader["AldigiDersler"].ToString(),
        //            Ortalamasi = Convert.ToDouble(reader["Ortalamasi"].ToString()),
        //            BolumId = Convert.ToInt32(reader["BolumId"].ToString()),
        //            Sifre = reader["Sifre"].ToString(),
        //        };
                
        //        ogrenciler.Add(ogrenci);
        //    }
        //    reader.Close();
        //    _connection.Close();
        //    if(ogrenciler.Count > 0)
        //    {
        //        return true;

        //    }
        //    return false;
        //}
        //SELECT* FROM table WHERE CONTAINS(Column, 'test');
    }
}

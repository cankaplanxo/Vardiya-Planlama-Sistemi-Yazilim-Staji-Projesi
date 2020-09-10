using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using VardiyaDLL;

namespace VARDIYA_PLANI
{
    public class AdminGiris 
    {   
        #region AdminGirişKontrol
        public static string KullaniciAdi, Sifre;

        public VardiyaDLL.Admin AdminKontrol(string KullaniciAdi, string Sifre)
        {
            VardiyaDLL.Admin adminuser = null;
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("SELECT *FROM kullanicilar WHERE KullaniciAdi='" + KullaniciAdi + "'and Sifre='" + Sifre + "'")
                {
                    Connection = connection
                };
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        adminuser = new VardiyaDLL.Admin
                        {
                            KullaniciID = reader.GetInt32(0),
                            KullaniciAdi = reader.GetString(1),
                            Sifre = reader.GetString(2),
                            
                        };
                    }
                }
                connection.Close();
            }
            return adminuser;
        }
        #endregion

        #region AdminKayitKontrol
        private bool AdminVarsa(VardiyaDLL.Admin adminuser)
        {
            bool result = false;
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("SELECT *FROM kullanicilar WHERE KullaniciAdi='" + adminuser.KullaniciAdi + "'")
                {
                    Connection = connection
                };
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result = true;
                    }
                }
                connection.Close();
            }
            return result;
        }
        #endregion

        #region AdminKayıtYapma
        public bool AdminInsert(VardiyaDLL.Admin adminuser)
        {
            bool result = false;
            if (!AdminVarsa(adminuser))
            {
                using (var connection =Database.GetConnection())
                {
                    var command = new SqlCommand("INSERT INTO kullanicilar(KullaniciAdi,Sifre,AdiSoyadi,Durumu,KayitTarihi,sistemegiris,Bolum) VALUES('" + adminuser.KullaniciAdi + "','" + adminuser.Sifre + "','" + adminuser.AdiSoyadi + "','" + adminuser.Durumu + adminuser.KayitTarihi + "','" +adminuser.SistemGiris + "','" + adminuser.Bolum + "')")
                    {
                        Connection = connection
                    };
                    connection.Open();
                    if (command.ExecuteNonQuery() != -1)
                    {
                        result = true;
                    }
                    connection.Close();
                }
            }
            return result;
        }
        #endregion

    }
}
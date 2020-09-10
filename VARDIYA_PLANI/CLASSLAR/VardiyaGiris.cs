using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace VARDIYA_PLANI
{
    public class VardiyaGiris
    {

        #region VardiyaAmiriGirişKontrol
        public static string KullaniciAdi, Sifre;

        public VardiyaDLL.VardiyaAmiri AmirKontrol(string KullaniciAdi, string Sifre)
        {
            VardiyaDLL.VardiyaAmiri VardiyaAmirUser = null;
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

                        VardiyaAmirUser = new VardiyaDLL.VardiyaAmiri
                        {
                            KullaniciID = reader.GetInt32(0),
                            KullaniciAdi = reader.GetString(1),
                            Sifre = reader.GetString(2),

                        };

                    }
                }
                connection.Close();
            }
            return VardiyaAmirUser;
        }
        #endregion

        #region AdminKayitKontrol
        private bool AmirVarsa(VardiyaDLL.VardiyaAmiri VardiyaAmirUser)
        {
            bool result = false;
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("SELECT *FROM kullanicilar WHERE KullaniciAdi='" + VardiyaAmirUser.KullaniciAdi + "'")
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
        public bool AmirInsert(VardiyaDLL.VardiyaAmiri VardiyaAmirUser)
        {
            bool result = false;
            if (!AmirVarsa(VardiyaAmirUser))
            {
                using (var connection = Database.GetConnection())
                {
                    var command = new SqlCommand("INSERT INTO kullanicilar(KullaniciAdi,Sifre,AdiSoyadi,Durumu,KayitTarihi,sistemegiris,Bolum) VALUES('" + VardiyaAmirUser.KullaniciAdi + "','" + VardiyaAmirUser.Sifre + "','" + VardiyaAmirUser.AdiSoyadi + "','" + VardiyaAmirUser.Durumu + VardiyaAmirUser.KayitTarihi + "','" + VardiyaAmirUser.SistemGiris + "','" + VardiyaAmirUser.Bolum + "')")
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


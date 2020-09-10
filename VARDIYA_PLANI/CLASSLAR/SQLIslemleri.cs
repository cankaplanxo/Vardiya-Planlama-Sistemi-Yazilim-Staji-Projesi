using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using VardiyaDLL;

namespace VARDIYA_PLANI
{
   
    public class SQLIslemleri
    {
        public static int Bolum;
        public int UrunSilme(VardiyaDLL.VardiyaAmiri degisken)
        {
           
           // bool result = false;
            using (var baglanti = Database.GetConnection())
            {
                baglanti.Open();
                string secmeSorgusu = "SELECT * from kullanicilar where KullaniciAdi=@KAD";
                SqlCommand secmeKomutu = new SqlCommand(secmeSorgusu, baglanti);
                secmeKomutu.Parameters.AddWithValue("@KAD", degisken.KullaniciAdi);
                SqlDataAdapter da = new SqlDataAdapter(secmeKomutu);
                SqlDataReader dr = secmeKomutu.ExecuteReader();
                if (dr.Read())
                {
                     Bolum = Convert.ToInt32(dr["Bolum"]);

                    dr.Close();       
                    baglanti.Close();

                }


                return Bolum;
            }
        }


        #region Değişkenler
        public static string PSid, PSadi, PSkodu, PSoperasyonid;
        #endregion

        //Haftalık Vardiya İşlemleri
        #region VardiyaVarmiKontrolü
        private bool VardiyaVarsa(VardiyaDLL.Personel degisken)
        {
            bool result = false;
            using (var baglanti = Database.GetConnection())
            {
                baglanti.Open();
                string secmeSorgusu = "exec SP_VardiyaKontrol @SNO";
                SqlCommand secmeKomutu = new SqlCommand(secmeSorgusu, baglanti);
                secmeKomutu.Parameters.AddWithValue("@SNO", degisken.SicilNo);
                SqlDataAdapter da = new SqlDataAdapter(secmeKomutu);
                SqlDataReader dr = secmeKomutu.ExecuteReader();
                if (dr.Read())
                {
                    result = true;
                    baglanti.Close();
                }
                return result;

            }

        }
        #endregion

        #region VARDİYAEKLEME
        public bool VardiyaEkleme(VardiyaDLL.Personel degisken)
        {

            bool result = false;
            if (!VardiyaVarsa(degisken))
            {
                using (var baglanti = Database.GetConnection())
                {
                    try
                    {


                        string kayit = "insert into AnaVardiyaListesi(SicilNO,VardiyaSaat,VardiyaTarihi) values (@SNO,@VSaat,@VTarih)";
                        SqlCommand komut = new SqlCommand(kayit, baglanti);
                        komut.Parameters.AddWithValue("@SNO", degisken.SicilNo);
                        komut.Parameters.AddWithValue("@VSaat", degisken.VardiyaSaati);
                        komut.Parameters.AddWithValue("@VTarih", DateTime.Now);
                        //komut.Parameters.AddWithValue("@VTarih", degisken.VardiyaTarihi);
                        baglanti.Open();
                        if (komut.ExecuteNonQuery() != -1)
                        {
                            result = true;
                        }
                        baglanti.Close();

                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show("İşlem Sırasında Hata Oluştu. \n\n\n\n" + hata.Message);
                    }

                    return result;
                }
            }
            return result;
        }
        #endregion

        #region VardiyaGuncelleme
        public bool VardiyaGuncelleme(VardiyaDLL.Personel degisken)
        {
            bool result = false;
            using (var baglanti = Database.GetConnection())
            {
                baglanti.Open();
                string secmeSorgusu = "exec SP_VardiyaUpdateKontrol @SNO";
                SqlCommand secmeKomutu = new SqlCommand(secmeSorgusu, baglanti);
                secmeKomutu.Parameters.AddWithValue("@SNO", degisken.SicilNo);
                SqlDataAdapter da = new SqlDataAdapter(secmeKomutu);
                SqlDataReader dr = secmeKomutu.ExecuteReader();
                if (dr.Read())
                {
                    string id = dr["SicilNO"].ToString();
                    string urunadkod = dr["SicilNO"].ToString() + " " + dr["SicilNO"].ToString();

                    dr.Close();


                      
                        string kayit = "exec SP_VardiyaUpdate @VardiyaSaati,@SicilNO";
                        SqlCommand komut = new SqlCommand(kayit, baglanti);
                        komut.Parameters.AddWithValue("@VardiyaSaati", degisken.VardiyaSaati);
                        komut.Parameters.AddWithValue("@SicilNO", degisken.SicilNo);
                        komut.ExecuteNonQuery();

                       

                    

                    baglanti.Close();


                }
                else
                {
                    MessageBox.Show("Böyle bir kişi yok.");
                }

                return result;
            }
        }
        #endregion


 

        //Gunluk Mesai 
        #region VardiyaVarmiKontrolu
        private bool GunlukVardiyaVarsa(VardiyaDLL.Personel degisken)
        {
            bool result = false;
            using (var baglanti = Database.GetConnection())
            {
                baglanti.Open();
                string secmeSorgusu = "exec GunlukVardiyaKontrol @SNO";
                SqlCommand secmeKomutu = new SqlCommand(secmeSorgusu, baglanti);
                secmeKomutu.Parameters.AddWithValue("@SNO", degisken.SicilNo);
                SqlDataAdapter da = new SqlDataAdapter(secmeKomutu);
                SqlDataReader dr = secmeKomutu.ExecuteReader();
                if (dr.Read())
                {
                    result = true;
                    baglanti.Close();
                }
                return result;

            }

        }
        #endregion

        #region VARDİYAEKLEME
        public bool GunlukVardiyaEkleme(VardiyaDLL.Personel degisken)
        {

            bool result = false;
            if (!GunlukVardiyaVarsa(degisken))
            {
                using (var baglanti = Database.GetConnection())
                {
                    try
                    {


                        string kayit = "insert into GunlukAnaVardiyaListesi(SicilNO,VardiyaSaat,VardiyaTarihi) values (@SNO,@VSaat,@VTarih)";
                        SqlCommand komut = new SqlCommand(kayit, baglanti);
                        komut.Parameters.AddWithValue("@SNO", degisken.SicilNo);
                        komut.Parameters.AddWithValue("@VSaat", degisken.VardiyaSaati);
                        komut.Parameters.AddWithValue("@VTarih", DateTime.Now);
                        //komut.Parameters.AddWithValue("@VTarih", degisken.VardiyaTarihi);
                        baglanti.Open();
                        if (komut.ExecuteNonQuery() != -1)
                        {
                            result = true;
                        }
                        baglanti.Close();

                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show("İşlem Sırasında Hata Oluştu. \n\n\n\n" + hata.Message);
                    }

                    return result;
                }
            }
            return result;
        }
        #endregion

        #region VardiyaGuncelleme
        public bool GunlukVardiyaGuncelleme(VardiyaDLL.Personel degisken)
        {
            bool result = false;
            using (var baglanti = Database.GetConnection())
            {
                baglanti.Open();
                string secmeSorgusu = "exec GunlukVardiyaUpdateKontrol @SNO";
                SqlCommand secmeKomutu = new SqlCommand(secmeSorgusu, baglanti);
                secmeKomutu.Parameters.AddWithValue("@SNO", degisken.SicilNo);
                SqlDataAdapter da = new SqlDataAdapter(secmeKomutu);
                SqlDataReader dr = secmeKomutu.ExecuteReader();
                if (dr.Read())
                {
                    string id = dr["SicilNO"].ToString();
                    string urunadkod = dr["SicilNO"].ToString() + " " + dr["SicilNO"].ToString();

                    dr.Close();


                    
                    string kayit = "exec GunlukVardiyaUpdate @VardiyaSaati,@SicilNO";
                    SqlCommand komut = new SqlCommand(kayit, baglanti);
                    komut.Parameters.AddWithValue("@VardiyaSaati", degisken.VardiyaSaati);
                    komut.Parameters.AddWithValue("@SicilNO", degisken.SicilNo);
                    komut.ExecuteNonQuery();

                   



                    baglanti.Close();


                }
                else
                {
                    MessageBox.Show("Böyle bir kişi yok.");
                }

                return result;
            }
        }
        #endregion

       
    }
}

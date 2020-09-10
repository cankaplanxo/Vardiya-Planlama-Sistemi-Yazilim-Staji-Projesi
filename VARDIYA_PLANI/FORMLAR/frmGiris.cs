using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace VARDIYA_PLANI.FORMLAR
{
    public partial class frmGiris : Form
    {
        public frmGiris()
        {
            InitializeComponent();
        }

        private void frmGiris_Load(object sender, EventArgs e)
        {
            {
                cmbDoldur();

            }
        }

    SqlConnection conn = new SqlConnection("Data Source=DESKTOP-J2TDLUS;Initial Catalog=Pimtas_Vardiya;Integrated Security=True");

        void cmbDoldur()
        {
            conn.Open();

            SqlCommand doldur = new SqlCommand("SELECT KullaniciAdi FROM kullanicilar", conn);
            SqlDataReader dr = doldur.ExecuteReader();
            while (dr.Read())
            {
                cmbKullaniciAdi.Items.Add(dr[0]);
            }


            conn.Close();
        }


        public static string KullaniciAdi, Sifre;
        public static string TempIsBolumu;
        byte Bolumu;

        public VardiyaDLL.Admin adminkullanicisi;
        public AdminGiris islem;

        public VardiyaDLL.VardiyaAmiri VardiyaAmiri;
        public VardiyaGiris islem2;

        private void btnGiris_Click_1(object sender, EventArgs e)
        {
            KullaniciAdi = cmbKullaniciAdi.Text;



            SqlConnection baglanti = new SqlConnection();
            baglanti.ConnectionString = "Data Source=DESKTOP-J2TDLUS;Initial Catalog=Pimtas_Vardiya;Integrated Security=True";
            SqlCommand komut = new SqlCommand();

            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;



            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("SELECT *FROM kullanicilar WHERE KullaniciAdi='" + KullaniciAdi + "'")
                {
                    Connection = connection
                };
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        Bolumu = reader.GetByte(5);

                    }
                }
                connection.Close();
            }


            switch (Bolumu)
            {
                case 0:
                    {
                        try
                        {
                            if (cmbKullaniciAdi.Text == "" && txtsifre.Text == "")
                            {
                                MessageBox.Show("Lütfen boş kısım bırakmayınız.");
                            }
                            else
                            {
                                islem = new AdminGiris();
                                adminkullanicisi = islem.AdminKontrol(cmbKullaniciAdi.Text, txtsifre.Text);
                                if (adminkullanicisi != null)
                                {
                                    frmAdminSecim a = new frmAdminSecim();
                                    MessageBox.Show("Başarıyla giriş yaptınız.");

                                    frmVardiyaPlanlamaEkrani.TempKullaniciAdi = cmbKullaniciAdi.Text;
                                    frmVardiyaPlanlamaEkrani.Bolumu = Bolumu;
                                    frmMesaiPlanlamaEkrani.TempKullaniciAdi = cmbKullaniciAdi.Text;
                                    frmMesaiPlanlamaEkrani.Bolumu = Bolumu;

                                    a.StartPosition = FormStartPosition.CenterScreen;
                                    a.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    MessageBox.Show("Kullanıcı adı veya şifre yanlıştır. Lütfen tekrar deneyiniz.");
                                }
                            }

                        }
                        catch (Exception hata)
                        {
                            MessageBox.Show("Bir hata oluştu. \n");
                            MessageBox.Show(hata.Message);
                        }
                        break;
                    }

                case 1:
                    {
                        try
                        {
                            if (cmbKullaniciAdi.Text == "" && txtsifre.Text == "")
                            {
                                MessageBox.Show("Lütfen boş kısım bırakmayınız.");
                            }
                            else
                            {
                                islem2 = new VardiyaGiris();
                                VardiyaAmiri = islem2.AmirKontrol(cmbKullaniciAdi.Text, txtsifre.Text);
                                if (VardiyaAmiri != null)
                                {
                                    frmKullaniciSecim a = new frmKullaniciSecim();
                                    MessageBox.Show("Başarıyla giriş yaptınız.");
                                    frmKullaniciSecim.TempKullaniciAdi = cmbKullaniciAdi.Text;

                                    frmVardiyaPlanlamaEkrani.TempKullaniciAdi = cmbKullaniciAdi.Text;
                                    frmVardiyaPlanlamaEkrani.Bolumu = Bolumu;
                                    frmMesaiPlanlamaEkrani.TempKullaniciAdi = cmbKullaniciAdi.Text;
                                    frmMesaiPlanlamaEkrani.Bolumu = Bolumu;

                                    a.StartPosition = FormStartPosition.CenterScreen;
                                    a.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    MessageBox.Show("Kullanıcı adı veya şifre yanlıştır. Lütfen tekrar deneyiniz.");
                                }
                            }

                        }
                        catch (Exception hata)
                        {
                            MessageBox.Show("Bir hata oluştu. \n");
                            MessageBox.Show(hata.Message);
                        }
                        break;
                    }

                default:
                    {
                        MessageBox.Show("Sistemde kayıtlı değilsiniz.");
                        Application.Exit();
                        break;
                    }
            }


        }
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VARDIYA_PLANI.FORMLAR;


namespace VARDIYA_PLANI.FORMLAR
{
    public partial class frmKullaniciSecim : Form
    {
        public frmKullaniciSecim()
        {
            InitializeComponent();
        }

        public static string TempKullaniciAdi;
        public static string TempIsBolumu;
        public static byte Bolumu; 



        private void btnVardiya_Click(object sender, EventArgs e)
        {
            frmVardiyaPlanlamaEkrani a = new frmVardiyaPlanlamaEkrani();
            a.Show();
            this.Hide();
        }

        private void btnMesai_Click(object sender, EventArgs e)
        {
            frmMesaiPlanlamaEkrani n = new frmMesaiPlanlamaEkrani();
            n.Show();
            this.Hide();
        }

        private void frmKullaniciSecim_Load(object sender, EventArgs e)
        {

            SqlConnection baglanti = new SqlConnection();
            baglanti.ConnectionString = "Data Source=DESKTOP-J2TDLUS;Initial Catalog=Pimtas_Vardiya;Integrated Security=True";
            SqlCommand komut = new SqlCommand();

            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;
            SqlDataReader dr;

            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("SELECT *FROM kullanicilar WHERE KullaniciAdi='" + TempKullaniciAdi + "'")
                {
                    Connection = connection
                };
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        TempIsBolumu = reader.GetString(8);
                        Bolumu = reader.GetByte(5);


                    }
                }
                connection.Close();

                frmVardiyaPlanlamaEkrani.TempKullaniciAdi = TempKullaniciAdi;
                frmVardiyaPlanlamaEkrani.Bolumu = Bolumu;
                frmMesaiPlanlamaEkrani.TempKullaniciAdi = TempKullaniciAdi;
                frmMesaiPlanlamaEkrani.Bolumu = Bolumu;
            }
        }
    }
}

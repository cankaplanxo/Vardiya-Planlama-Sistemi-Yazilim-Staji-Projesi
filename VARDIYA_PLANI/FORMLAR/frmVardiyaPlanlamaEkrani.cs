using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.AccessControl;
using System.Security.Authentication.ExtendedProtection;
using System.Windows.Forms;
using VARDIYA_PLANI.FORMLAR;

namespace VARDIYA_PLANI
{
    public partial class frmVardiyaPlanlamaEkrani : Form
    {


        public frmVardiyaPlanlamaEkrani()
        {
            InitializeComponent();

        }

       // string sql = "Data Source=DESKTOP-J2TDLUS;Initial Catalog=Pimtas_Vardiya;Integrated Security=True";
        public static string TempKullaniciAdi;
        public static string TempIsBolumu;
        public static byte Bolumu;


        private void frmVardiyaPlanlamaEkrani_Load(object sender, EventArgs e)


        {

 
            this.tabloPersonel.AllowUserToAddRows = false;
           // this.BindDataGridView();

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
            }


            if(Bolumu == 0)
            {
                

                komut.CommandText = "SELECT DISTINCT Bolum FROM personel";
                komut.Connection = baglanti;
                komut.CommandType = CommandType.Text;
                baglanti.Open();
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    cmbBolum.Items.Add(dr["Bolum"]);
                    
                }
                baglanti.Close();

                cmbBolum.Enabled = true;
            }
            else if(Bolumu == 1)
            {
                string Sql = "SELECT DISTINCT Bolum FROM personel";
                SqlConnection conn = new SqlConnection(baglanti.ConnectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand(Sql, conn);
                SqlDataReader DR = cmd.ExecuteReader();

                while (DR.Read())
                {
                    cmbBolum.Items.Add(DR[0]);

                }

                cmbBolum.Enabled = false;
                cmbBolum.SelectedIndex = cmbBolum.FindStringExact(TempIsBolumu);
            }
            else
            {
                Application.Exit();
            }

         
          //  cmbBolum.SelectedText = TempIsBolumu;

            komut.CommandText = "SELECT DISTINCT vardiyaZamani FROM vardiya";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;
            baglanti.Open();
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                //cmbVardiya.Items.Add(dr["vardiyaZamani"]);

            }
            baglanti.Close();

            foreach (DataGridViewColumn column in tabloPersonel.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

        }




        private void cmbDirektorluk_SelectedIndexChanged(object sender, EventArgs e)
        {
           



        }

        private void btnListele_Click(object sender, EventArgs e)
        {


        }

        
        #region DataGridDoldurma
        private void cmbBolum_SelectedIndexChanged(object sender, EventArgs e)
        {


            SqlConnection baglanti = new SqlConnection();
            baglanti.ConnectionString = "Data Source=DESKTOP-J2TDLUS;Initial Catalog=Pimtas_Vardiya;Integrated Security=True";
            SqlCommand komut = new SqlCommand();

            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;
            SqlDataReader dr;
            //  tabloPersonel.Rows.Clear();
            //   tabloPersonel.Columns.Clear();
            tabloPersonel.DataSource = null;
            tabloPersonel.Columns.Clear();


            try
            {
                using (var connection = Database.GetConnection())
                {
                    connection.Open();



                    SqlCommand cmd = new SqlCommand("exec SP_AnaVardiyaListesiAyarlama @Bolum", baglanti);
                    cmd.Parameters.AddWithValue("@Bolum", cmbBolum.Text);
                    //  cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter ad = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    ad.Fill(ds);
                    tabloPersonel.DataSource = ds.Tables[0];
             

                    tabloPersonel.RowHeadersVisible = false;
                    tabloPersonel.Columns[0].HeaderCell.Value = "Sicil NO";
                    tabloPersonel.Columns[1].HeaderCell.Value = "Adı Soyadı";
                    tabloPersonel.Columns[2].HeaderCell.Value = "Bölüm";



                    tabloPersonel.Columns[0].ReadOnly = true;
                    tabloPersonel.Columns[1].ReadOnly = true;
                    tabloPersonel.Columns[2].ReadOnly = true;
                    tabloPersonel.Columns[3].ReadOnly = true;
                    tabloPersonel.Columns[4].ReadOnly = true;
                    tabloPersonel.Columns[5].ReadOnly = true;
                    tabloPersonel.Columns[5].ReadOnly = false;




                    this.tabloPersonel.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    //tabloPersonel.Columns[0].Width = 50;
                    //tabloPersonel.Columns[1].Width = 200;
                    //tabloPersonel.Columns[2].Width = 150;
                    //tabloPersonel.Columns[3].Width = 350;
                    //tabloPersonel.Columns[5].Width = 200;

                    // dataGridView1.Columns[0].Width = 300;





                    DataGridViewComboBoxColumn cbk = new DataGridViewComboBoxColumn();
                    tabloPersonel.Columns.Add(cbk);
                    cbk.HeaderText = "Vardiya Saati";
                    cbk.Name = "cbk";

                  



                    komut.CommandText = "SELECT DISTINCT vardiyaZamani FROM vardiya";
                    komut.Connection = baglanti;
                    komut.CommandType = CommandType.Text;
                    baglanti.Open();
                    dr = komut.ExecuteReader();

                    while (dr.Read())
                    {
                        cbk.Items.Add(dr["vardiyaZamani"]);


                    }

                   // string Temp;

                    //string Sql = "SELECT VardiyaSaat FROM AnaVardiyaListesi";
                    //SqlConnection conn = new SqlConnection(baglanti.ConnectionString);
                    //conn.Open();
                    //SqlCommand cmd2 = new SqlCommand(Sql, conn);
                    //SqlDataReader DR = cmd2.ExecuteReader();

                    //while (DR.Read())
                    //{


                    //    for (int i = 0; i < tabloPersonel.RowCount; i++)
                    //    {
                    //        tabloPersonel.Rows[1].Cells[6].Value = dr["VardiyaSaat"];

                    //    }
                    //}
                    //  tabloPersonel.Rows[1].Cells[6].Value = "wqcoıueycowqyıewqec";
                    


                    baglanti.Close();


                    //DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                    //tabloPersonel.Columns.Add(chk);
                    //chk.HeaderText = "Check Data";
                    //chk.Name = "chk";

                    //tabloPersonel.Columns[3].ReadOnly = false;


                }

                foreach (DataGridViewColumn column in tabloPersonel.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

        }
            catch (Exception msg)
            {
                MessageBox.Show("Veritabanı bağlantınız kurulamadı veya sistemde teknik bir hata oluştu. Lütfen programı kapatıp açınız." + "\n" + msg);
            }

    //GECIS
    //SqlConnection conn = new SqlConnection(sql);
    //if (conn.State == ConnectionState.Closed)
    //    conn.Open();
    //var sorgu = "select  *from personel where Bolum = '" + cmbBolum.Text + "'";

    //SqlDataAdapter adp = new SqlDataAdapter(sorgu, conn);

    //DataSet ds = new DataSet();
    //adp.Fill(ds);
    //dataGridView1.DataSource = ds.Tables[0];
}
        #endregion

        
   

 

        private void btnGonder_Click(object sender, EventArgs e)
        {
            int Temp;
            Temp = tabloPersonel.ColumnCount - 1;

            for (int i=0; i < tabloPersonel.RowCount; i++)
            {
               
                    if(tabloPersonel.Rows[i].Cells[Temp].Value == null)
                    {
                        MessageBox.Show("Lütfen vardiya saatini doldurunuz.");
                    }
                    else
                    {

                                SQLIslemleri islem = new SQLIslemleri();
                                VardiyaDLL.Personel giris = new VardiyaDLL.Personel
                                {
                                   VardiyaSaati = tabloPersonel.Rows[i].Cells[Temp].Value.ToString(),
                                   SicilNo = tabloPersonel.Rows[i].Cells[0].Value.ToString()

                                };


                                if (islem.VardiyaEkleme(giris))
                                {
 
                                }
                                else
                                {
                                    SQLIslemleri islem2 = new SQLIslemleri();
                                    VardiyaDLL.Personel giris2 = new VardiyaDLL.Personel
                                    {
                                        VardiyaSaati = tabloPersonel.Rows[i].Cells[Temp].Value.ToString(),
                                        SicilNo = tabloPersonel.Rows[i].Cells[0].Value.ToString()
                                    };

                                    if (islem.VardiyaGuncelleme(giris))
                                    {

                                    }



                                }

                    }      
                
            }

            MessageBox.Show("Vardiya saati ayarlama tamamlandı.");
          
          
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            if(Bolumu == 0)
            {
                frmAdminSecim frm = new frmAdminSecim();
                frm.Show();
                this.Hide();
                
            }
            else if (Bolumu == 1)
            {
                frmKullaniciSecim a = new frmKullaniciSecim();
                a.Show();
                this.Hide();
            }
           
        }



        #region DatagrigView içindeki combobox'daki verilerin tek tıklamada getirilmesini sağlayan kodlar
        private void tabloPersonel_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            {
                bool validClick = (e.RowIndex != -1 && e.ColumnIndex != -1); //Make sure the clicked row/column is valid.
                var dataGridView = sender as DataGridView;

                // Check to make sure the cell clicked is the cell containing the combobox 
                if (tabloPersonel.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn && validClick)
                {
                    tabloPersonel.BeginEdit(true);
                    ((ComboBox)tabloPersonel.EditingControl).DroppedDown = true;
                }
            }

        }

        private void tabloPersonel_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            tabloPersonel.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }


        #endregion

        private void tabloPersonel_SelectionChanged(object sender, EventArgs e)
        {
            tabloPersonel.ClearSelection();
        }

        private void tabloPersonel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
            




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
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;

namespace VARDIYA_PLANI.FORMLAR
{
    public partial class frmGunlukMesaiExcel : Form
    {
        public frmGunlukMesaiExcel()
        {
            InitializeComponent();
        }

        private void frmGunlukeMesaiExcel_Load(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection();
            baglanti.ConnectionString = "Data Source=DESKTOP-J2TDLUS;Initial Catalog=Pimtas_Vardiya;Integrated Security=True";
            SqlCommand komut = new SqlCommand();

            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;
            SqlDataReader dr;
            //  tabloPersonel.Rows.Clear();
            //   tabloPersonel.Columns.Clear();
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();

            using (var connection = Database.GetConnection())
            {
                connection.Open();


                SqlCommand cmd = new SqlCommand("exec GunlukVardiyaSaatleriAyarlama", baglanti);
                //cmd.Parameters.AddWithValue("@Bolum", cmbBolum.Text);
                //  cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];



                dataGridView1.RowHeadersVisible = false;
                dataGridView1.Columns[0].HeaderCell.Value = "Sicil NO";
                dataGridView1.Columns[1].HeaderCell.Value = "Adı Soyadı";
                dataGridView1.Columns[2].HeaderCell.Value = "Bölüm";



                dataGridView1.Columns[0].ReadOnly = true;
                dataGridView1.Columns[1].ReadOnly = true;



                this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                //dataGridView1.Columns[0].Width = 150;
                //dataGridView1.Columns[1].Width = 150;


                // dataGridView1.Columns[0].Width = 300;



                //DataGridViewComboBoxColumn cbk = new DataGridViewComboBoxColumn();
                //tabloPersonel.Columns.Add(cbk);
                //cbk.HeaderText = "Vardiya Saati";
                //cbk.Name = "cbk";

                //komut.CommandText = "SELECT DISTINCT vardiyaZamani FROM vardiya";
                //komut.Connection = baglanti;
                //komut.CommandType = CommandType.Text;
                //baglanti.Open();
                //dr = komut.ExecuteReader();
                //while (dr.Read())
                //{
                //    cbk.Items.Add(dr["vardiyaZamani"]);


                //}



                baglanti.Close();


                //DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                //tabloPersonel.Columns.Add(chk);
                //chk.HeaderText = "Check Data";
                //chk.Name = "chk";

                //tabloPersonel.Columns[3].ReadOnly = false;
            }


        }
        private void copyAlltoClipboard()
        {
            dataGridView1.SelectAll();
            DataObject dataObj = dataGridView1.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);

        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            frmAdminSecim frm = new frmAdminSecim();
            this.Hide();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dataGridView1.MultiSelect = true;
            dataGridView1.SelectAll();

            copyAlltoClipboard();
            Microsoft.Office.Interop.Excel.Application xlexcel;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlexcel = new Excel.Application();
            xlexcel.Visible = true;
            xlWorkBook = xlexcel.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            Excel.Range CR = (Excel.Range)xlWorkSheet.Cells[1, 1];
            CR.Select();
            xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
        }
    }
}

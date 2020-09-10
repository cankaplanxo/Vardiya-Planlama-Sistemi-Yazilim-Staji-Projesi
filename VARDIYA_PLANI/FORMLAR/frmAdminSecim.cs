using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VARDIYA_PLANI.FORMLAR;

namespace VARDIYA_PLANI
{
    public partial class frmAdminSecim : Form
    {
        public frmAdminSecim()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmAnaVardiyaExcel a = new frmAnaVardiyaExcel();
            a.Show();
            this.Hide();
    
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmVardiyaPlanlamaEkrani a = new frmVardiyaPlanlamaEkrani();
            a.Show();
            this.Hide();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmMesaiPlanlamaEkrani a = new frmMesaiPlanlamaEkrani();
            a.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmGunlukMesaiExcel a = new frmGunlukMesaiExcel();
            a.Show();
            this.Hide();
        }

        private void frmAdminSecim_Load(object sender, EventArgs e)
        {

        }
    }
}

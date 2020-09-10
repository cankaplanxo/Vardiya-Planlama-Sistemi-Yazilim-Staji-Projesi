namespace VARDIYA_PLANI.FORMLAR
{
    partial class frmMesaiPlanlamaEkrani
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbBolum = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabloPersonel = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGeri = new System.Windows.Forms.Button();
            this.btnGonder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tabloPersonel)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbBolum
            // 
            this.cmbBolum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBolum.FormattingEnabled = true;
            this.cmbBolum.Location = new System.Drawing.Point(68, 39);
            this.cmbBolum.Name = "cmbBolum";
            this.cmbBolum.Size = new System.Drawing.Size(247, 21);
            this.cmbBolum.TabIndex = 21;
            this.cmbBolum.SelectedIndexChanged += new System.EventHandler(this.cmbBolum_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.3F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(9, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 15);
            this.label2.TabIndex = 20;
            this.label2.Text = "Bölüm :";
            // 
            // tabloPersonel
            // 
            this.tabloPersonel.AllowUserToAddRows = false;
            this.tabloPersonel.AllowUserToDeleteRows = false;
            this.tabloPersonel.AllowUserToResizeColumns = false;
            this.tabloPersonel.AllowUserToResizeRows = false;
            this.tabloPersonel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabloPersonel.Location = new System.Drawing.Point(12, 84);
            this.tabloPersonel.Name = "tabloPersonel";
            this.tabloPersonel.Size = new System.Drawing.Size(1288, 474);
            this.tabloPersonel.TabIndex = 28;
            this.tabloPersonel.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabloPersonel_CellEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(334, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(637, 54);
            this.label1.TabIndex = 30;
            this.label1.Text = "GÜNLÜK MESAİ PLANLAMA";
            // 
            // btnGeri
            // 
            this.btnGeri.BackgroundImage = global::VARDIYA_PLANI.Properties.Resources.BackIcon;
            this.btnGeri.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGeri.Location = new System.Drawing.Point(1078, 579);
            this.btnGeri.Name = "btnGeri";
            this.btnGeri.Size = new System.Drawing.Size(84, 59);
            this.btnGeri.TabIndex = 29;
            this.btnGeri.UseVisualStyleBackColor = true;
            this.btnGeri.Click += new System.EventHandler(this.btnGeri_Click);
            // 
            // btnGonder
            // 
            this.btnGonder.BackColor = System.Drawing.SystemColors.Control;
            this.btnGonder.BackgroundImage = global::VARDIYA_PLANI.Properties.Resources.Ok_256256;
            this.btnGonder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGonder.Location = new System.Drawing.Point(1209, 579);
            this.btnGonder.Name = "btnGonder";
            this.btnGonder.Size = new System.Drawing.Size(91, 59);
            this.btnGonder.TabIndex = 27;
            this.btnGonder.UseVisualStyleBackColor = false;
            this.btnGonder.Click += new System.EventHandler(this.btnGonder_Click);
            // 
            // frmMesaiPlanlamaEkrani
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1359, 650);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGeri);
            this.Controls.Add(this.tabloPersonel);
            this.Controls.Add(this.btnGonder);
            this.Controls.Add(this.cmbBolum);
            this.Controls.Add(this.label2);
            this.Name = "frmMesaiPlanlamaEkrani";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMesaiPlanlamaEkrani";
            this.Load += new System.EventHandler(this.frmMesaiPlanlamaEkrani_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabloPersonel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbBolum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGeri;
        public System.Windows.Forms.DataGridView tabloPersonel;
        private System.Windows.Forms.Button btnGonder;
        private System.Windows.Forms.Label label1;
    }
}
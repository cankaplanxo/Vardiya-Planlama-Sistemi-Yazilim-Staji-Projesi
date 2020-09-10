namespace VARDIYA_PLANI.FORMLAR
{
    partial class frmKullaniciSecim
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
            this.btnMesai = new System.Windows.Forms.Button();
            this.btnVardiya = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMesai
            // 
            this.btnMesai.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.3F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnMesai.Location = new System.Drawing.Point(34, 121);
            this.btnMesai.Name = "btnMesai";
            this.btnMesai.Size = new System.Drawing.Size(263, 119);
            this.btnMesai.TabIndex = 0;
            this.btnMesai.Text = "GÜNLÜK MESAİ PLANLAMA";
            this.btnMesai.UseVisualStyleBackColor = true;
            this.btnMesai.Click += new System.EventHandler(this.btnMesai_Click);
            // 
            // btnVardiya
            // 
            this.btnVardiya.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.3F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnVardiya.Location = new System.Drawing.Point(404, 121);
            this.btnVardiya.Name = "btnVardiya";
            this.btnVardiya.Size = new System.Drawing.Size(256, 119);
            this.btnVardiya.TabIndex = 1;
            this.btnVardiya.Text = "HAFTALIK VARDİYA PLANLAMA";
            this.btnVardiya.UseVisualStyleBackColor = true;
            this.btnVardiya.Click += new System.EventHandler(this.btnVardiya_Click);
            // 
            // frmKullaniciSecim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 357);
            this.Controls.Add(this.btnVardiya);
            this.Controls.Add(this.btnMesai);
            this.Name = "frmKullaniciSecim";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmKullaniciSecim";
            this.Load += new System.EventHandler(this.frmKullaniciSecim_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMesai;
        private System.Windows.Forms.Button btnVardiya;
    }
}
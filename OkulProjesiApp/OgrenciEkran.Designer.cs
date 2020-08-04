namespace OkulProjesiApp
{
    partial class OgrenciEkran
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OgrenciEkran));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dtOgrenciBilgileri = new System.Windows.Forms.DataGridView();
            this.OkulNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sifre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glnid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DersAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sozlu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Final = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ortalama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lblGelenSifreId = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtYeniSifreTekrar = new UtilityLib.MyTextBox();
            this.txtYeniSifre = new UtilityLib.MyTextBox();
            this.btnYenile = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnDuzenle = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblHoslgeldiniz = new System.Windows.Forms.Label();
            this.lblHosgor = new System.Windows.Forms.Label();
            this.lblAd = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtOgrenciBilgileri)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 59);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1198, 589);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dtOgrenciBilgileri);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1190, 563);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Notlar";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dtOgrenciBilgileri
            // 
            this.dtOgrenciBilgileri.AllowUserToAddRows = false;
            this.dtOgrenciBilgileri.AllowUserToDeleteRows = false;
            this.dtOgrenciBilgileri.AllowUserToOrderColumns = true;
            this.dtOgrenciBilgileri.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtOgrenciBilgileri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtOgrenciBilgileri.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OkulNo,
            this.ad,
            this.sifre,
            this.glnid,
            this.DersAdi,
            this.Vize,
            this.Sozlu,
            this.Final,
            this.Ortalama});
            this.dtOgrenciBilgileri.Location = new System.Drawing.Point(18, 20);
            this.dtOgrenciBilgileri.Name = "dtOgrenciBilgileri";
            this.dtOgrenciBilgileri.ReadOnly = true;
            this.dtOgrenciBilgileri.Size = new System.Drawing.Size(1117, 494);
            this.dtOgrenciBilgileri.TabIndex = 1;
            this.dtOgrenciBilgileri.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtOgrenciBilgileri_CellClick);
            // 
            // OkulNo
            // 
            this.OkulNo.DataPropertyName = "OkulNo";
            this.OkulNo.HeaderText = "OkulNo";
            this.OkulNo.Name = "OkulNo";
            this.OkulNo.ReadOnly = true;
            // 
            // ad
            // 
            this.ad.DataPropertyName = "Ad";
            this.ad.HeaderText = "ad";
            this.ad.Name = "ad";
            this.ad.ReadOnly = true;
            this.ad.Visible = false;
            // 
            // sifre
            // 
            this.sifre.DataPropertyName = "Sifre";
            this.sifre.HeaderText = "sifre";
            this.sifre.Name = "sifre";
            this.sifre.ReadOnly = true;
            this.sifre.Visible = false;
            // 
            // glnid
            // 
            this.glnid.DataPropertyName = "OgrenciId";
            this.glnid.HeaderText = "glnid";
            this.glnid.Name = "glnid";
            this.glnid.ReadOnly = true;
            this.glnid.Visible = false;
            // 
            // DersAdi
            // 
            this.DersAdi.DataPropertyName = "DersAdi";
            this.DersAdi.HeaderText = "Ders";
            this.DersAdi.Name = "DersAdi";
            this.DersAdi.ReadOnly = true;
            // 
            // Vize
            // 
            this.Vize.DataPropertyName = "Vize";
            this.Vize.HeaderText = "Vize";
            this.Vize.Name = "Vize";
            this.Vize.ReadOnly = true;
            // 
            // Sozlu
            // 
            this.Sozlu.DataPropertyName = "Sozlu";
            this.Sozlu.HeaderText = "Sözlu";
            this.Sozlu.Name = "Sozlu";
            this.Sozlu.ReadOnly = true;
            // 
            // Final
            // 
            this.Final.DataPropertyName = "Final";
            this.Final.HeaderText = "Final";
            this.Final.Name = "Final";
            this.Final.ReadOnly = true;
            // 
            // Ortalama
            // 
            this.Ortalama.DataPropertyName = "Ortalama";
            this.Ortalama.HeaderText = "Ortalama";
            this.Ortalama.Name = "Ortalama";
            this.Ortalama.ReadOnly = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lblGelenSifreId);
            this.tabPage3.Controls.Add(this.groupBox4);
            this.tabPage3.Controls.Add(this.pictureBox2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1190, 563);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Güvenlik";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lblGelenSifreId
            // 
            this.lblGelenSifreId.AutoSize = true;
            this.lblGelenSifreId.Location = new System.Drawing.Point(897, 534);
            this.lblGelenSifreId.Name = "lblGelenSifreId";
            this.lblGelenSifreId.Size = new System.Drawing.Size(37, 13);
            this.lblGelenSifreId.TabIndex = 23;
            this.lblGelenSifreId.Text = "SifreId";
            this.lblGelenSifreId.Visible = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtYeniSifreTekrar);
            this.groupBox4.Controls.Add(this.txtYeniSifre);
            this.groupBox4.Controls.Add(this.btnYenile);
            this.groupBox4.Controls.Add(this.label23);
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Location = new System.Drawing.Point(367, 148);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(467, 292);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            // 
            // txtYeniSifreTekrar
            // 
            this.txtYeniSifreTekrar.Calismamodu = UtilityLib.MyTextBox.CalismaMod.Normal;
            this.txtYeniSifreTekrar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtYeniSifreTekrar.Location = new System.Drawing.Point(199, 136);
            this.txtYeniSifreTekrar.MaxLength = 50;
            this.txtYeniSifreTekrar.Multiline = true;
            this.txtYeniSifreTekrar.Name = "txtYeniSifreTekrar";
            this.txtYeniSifreTekrar.PasswordChar = '*';
            this.txtYeniSifreTekrar.Size = new System.Drawing.Size(218, 25);
            this.txtYeniSifreTekrar.TabIndex = 27;
            // 
            // txtYeniSifre
            // 
            this.txtYeniSifre.Calismamodu = UtilityLib.MyTextBox.CalismaMod.Normal;
            this.txtYeniSifre.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtYeniSifre.Location = new System.Drawing.Point(199, 82);
            this.txtYeniSifre.MaxLength = 50;
            this.txtYeniSifre.Multiline = true;
            this.txtYeniSifre.Name = "txtYeniSifre";
            this.txtYeniSifre.PasswordChar = '*';
            this.txtYeniSifre.Size = new System.Drawing.Size(218, 25);
            this.txtYeniSifre.TabIndex = 26;
            // 
            // btnYenile
            // 
            this.btnYenile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYenile.Image = ((System.Drawing.Image)(resources.GetObject("btnYenile.Image")));
            this.btnYenile.Location = new System.Drawing.Point(378, 176);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(39, 42);
            this.btnYenile.TabIndex = 24;
            this.btnYenile.UseVisualStyleBackColor = true;
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label23.Location = new System.Drawing.Point(50, 138);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(143, 23);
            this.label23.TabIndex = 17;
            this.label23.Text = "Yeni Şifre Tekrar :";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label22.Location = new System.Drawing.Point(103, 84);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(90, 23);
            this.label22.TabIndex = 16;
            this.label22.Text = "Yeni Şifre :";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(37, 30);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(225, 225);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 16;
            this.pictureBox2.TabStop = false;
            // 
            // btnDuzenle
            // 
            this.btnDuzenle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDuzenle.Image = ((System.Drawing.Image)(resources.GetObject("btnDuzenle.Image")));
            this.btnDuzenle.Location = new System.Drawing.Point(1390, 22);
            this.btnDuzenle.Name = "btnDuzenle";
            this.btnDuzenle.Size = new System.Drawing.Size(66, 66);
            this.btnDuzenle.TabIndex = 18;
            this.btnDuzenle.UseVisualStyleBackColor = true;
            this.btnDuzenle.Click += new System.EventHandler(this.BtnDuzenle_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(1407, 796);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Version  1:0   i-zek";
            // 
            // lblHoslgeldiniz
            // 
            this.lblHoslgeldiniz.AutoSize = true;
            this.lblHoslgeldiniz.Location = new System.Drawing.Point(13, 9);
            this.lblHoslgeldiniz.Name = "lblHoslgeldiniz";
            this.lblHoslgeldiniz.Size = new System.Drawing.Size(35, 13);
            this.lblHoslgeldiniz.TabIndex = 20;
            this.lblHoslgeldiniz.Text = "label2";
            this.lblHoslgeldiniz.Visible = false;
            // 
            // lblHosgor
            // 
            this.lblHosgor.AutoSize = true;
            this.lblHosgor.Location = new System.Drawing.Point(13, 33);
            this.lblHosgor.Name = "lblHosgor";
            this.lblHosgor.Size = new System.Drawing.Size(57, 13);
            this.lblHosgor.TabIndex = 21;
            this.lblHosgor.Text = "Hoşgeldin ";
            // 
            // lblAd
            // 
            this.lblAd.AutoSize = true;
            this.lblAd.Location = new System.Drawing.Point(76, 33);
            this.lblAd.Name = "lblAd";
            this.lblAd.Size = new System.Drawing.Size(0, 13);
            this.lblAd.TabIndex = 22;
            // 
            // OgrenciEkran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1507, 818);
            this.Controls.Add(this.lblAd);
            this.Controls.Add(this.lblHosgor);
            this.Controls.Add(this.lblHoslgeldiniz);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDuzenle);
            this.Controls.Add(this.tabControl1);
            this.Name = "OgrenciEkran";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ogrenci";
            this.Load += new System.EventHandler(this.OgrenciEkran_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtOgrenciBilgileri)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnDuzenle;
        private System.Windows.Forms.DataGridView dtOgrenciBilgileri;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnYenile;
        private UtilityLib.MyTextBox txtYeniSifre;
        private UtilityLib.MyTextBox txtYeniSifreTekrar;
        private System.Windows.Forms.Label lblHosgor;
        public System.Windows.Forms.Label lblHoslgeldiniz;
        public System.Windows.Forms.Label lblAd;
        public System.Windows.Forms.Label lblGelenSifreId;
        private System.Windows.Forms.DataGridViewTextBoxColumn OkulNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ad;
        private System.Windows.Forms.DataGridViewTextBoxColumn sifre;
        private System.Windows.Forms.DataGridViewTextBoxColumn glnid;
        private System.Windows.Forms.DataGridViewTextBoxColumn DersAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vize;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sozlu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Final;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ortalama;
    }
}
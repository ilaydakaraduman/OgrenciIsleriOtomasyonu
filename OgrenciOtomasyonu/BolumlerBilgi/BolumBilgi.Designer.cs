namespace OgrenciOtomasyonu.BolumlerBilgi
{
    partial class BolumBilgi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BolumBilgi));
            this.tbxBolumAd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxBolumKod = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxDersler = new System.Windows.Forms.ComboBox();
            this.btnEkle = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnDersEkle = new System.Windows.Forms.Button();
            this.dgwBolumler = new System.Windows.Forms.DataGridView();
            this.btnSıfırla = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgwBolumler)).BeginInit();
            this.SuspendLayout();
            // 
            // tbxBolumAd
            // 
            this.tbxBolumAd.Location = new System.Drawing.Point(90, 239);
            this.tbxBolumAd.Margin = new System.Windows.Forms.Padding(2);
            this.tbxBolumAd.Name = "tbxBolumAd";
            this.tbxBolumAd.Size = new System.Drawing.Size(141, 20);
            this.tbxBolumAd.TabIndex = 0;
            this.tbxBolumAd.TextChanged += new System.EventHandler(this.tbxBolumAd_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(10, 239);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bölüm Adı:";
            // 
            // tbxBolumKod
            // 
            this.tbxBolumKod.Enabled = false;
            this.tbxBolumKod.Location = new System.Drawing.Point(90, 280);
            this.tbxBolumKod.Margin = new System.Windows.Forms.Padding(2);
            this.tbxBolumKod.Name = "tbxBolumKod";
            this.tbxBolumKod.Size = new System.Drawing.Size(141, 20);
            this.tbxBolumKod.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(10, 280);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Bölüm Kodu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(10, 318);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Dersler:";
            // 
            // cbxDersler
            // 
            this.cbxDersler.FormattingEnabled = true;
            this.cbxDersler.Location = new System.Drawing.Point(90, 319);
            this.cbxDersler.Margin = new System.Windows.Forms.Padding(2);
            this.cbxDersler.Name = "cbxDersler";
            this.cbxDersler.Size = new System.Drawing.Size(141, 21);
            this.cbxDersler.TabIndex = 5;
            // 
            // btnEkle
            // 
            this.btnEkle.Font = new System.Drawing.Font("Rockwell", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEkle.Location = new System.Drawing.Point(440, 308);
            this.btnEkle.Margin = new System.Windows.Forms.Padding(2);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(64, 30);
            this.btnEkle.TabIndex = 6;
            this.btnEkle.Text = "EKLE";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Font = new System.Drawing.Font("Rockwell", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuncelle.Location = new System.Drawing.Point(352, 308);
            this.btnGuncelle.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(84, 31);
            this.btnGuncelle.TabIndex = 7;
            this.btnGuncelle.Text = "GÜNCELLE";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnSil
            // 
            this.btnSil.Font = new System.Drawing.Font("Rockwell", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSil.Location = new System.Drawing.Point(512, 308);
            this.btnSil.Margin = new System.Windows.Forms.Padding(2);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(66, 30);
            this.btnSil.TabIndex = 8;
            this.btnSil.Text = "SİL";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnDersEkle
            // 
            this.btnDersEkle.Font = new System.Drawing.Font("Rockwell", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDersEkle.Location = new System.Drawing.Point(235, 319);
            this.btnDersEkle.Margin = new System.Windows.Forms.Padding(2);
            this.btnDersEkle.Name = "btnDersEkle";
            this.btnDersEkle.Size = new System.Drawing.Size(56, 19);
            this.btnDersEkle.TabIndex = 9;
            this.btnDersEkle.Text = "EKLE";
            this.btnDersEkle.UseVisualStyleBackColor = true;
            this.btnDersEkle.Click += new System.EventHandler(this.btnDersEkle_Click);
            // 
            // dgwBolumler
            // 
            this.dgwBolumler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwBolumler.Location = new System.Drawing.Point(80, 10);
            this.dgwBolumler.Margin = new System.Windows.Forms.Padding(2);
            this.dgwBolumler.Name = "dgwBolumler";
            this.dgwBolumler.RowTemplate.Height = 24;
            this.dgwBolumler.Size = new System.Drawing.Size(443, 197);
            this.dgwBolumler.TabIndex = 10;
            this.dgwBolumler.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwBolumler_CellClick);
            // 
            // btnSıfırla
            // 
            this.btnSıfırla.Font = new System.Drawing.Font("Rockwell", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSıfırla.Location = new System.Drawing.Point(527, 181);
            this.btnSıfırla.Margin = new System.Windows.Forms.Padding(2);
            this.btnSıfırla.Name = "btnSıfırla";
            this.btnSıfırla.Size = new System.Drawing.Size(70, 25);
            this.btnSıfırla.TabIndex = 11;
            this.btnSıfırla.Text = "SIFIRLA";
            this.btnSıfırla.UseVisualStyleBackColor = true;
            this.btnSıfırla.Click += new System.EventHandler(this.btnSıfırla_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBack.BackgroundImage = global::OgrenciOtomasyonu.Properties.Resources.back;
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBack.Location = new System.Drawing.Point(9, 10);
            this.btnBack.Margin = new System.Windows.Forms.Padding(2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(58, 54);
            this.btnBack.TabIndex = 14;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // BolumBilgi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.BackgroundImage = global::OgrenciOtomasyonu.Properties.Resources.Bir_başlık_ekleyin;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnSıfırla);
            this.Controls.Add(this.dgwBolumler);
            this.Controls.Add(this.btnDersEkle);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.cbxDersler);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxBolumKod);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxBolumAd);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "BolumBilgi";
            this.Text = "BolumBilgi";
            this.Load += new System.EventHandler(this.BolumBilgi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwBolumler)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxBolumAd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxBolumKod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxDersler;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnDersEkle;
        private System.Windows.Forms.DataGridView dgwBolumler;
        private System.Windows.Forms.Button btnSıfırla;
        private System.Windows.Forms.Button btnBack;
    }
}
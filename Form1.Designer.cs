namespace BenimKutuphanem
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            Kutuphane = new TabPage();
            panelFiltre = new Panel();
            FiltreDurum = new ComboBox();
            labelDurum = new Label();
            Kitaplar = new DataGridView();
            Ara = new TextBox();
            label2 = new Label();
            Ekle = new TabPage();
            groupBox2 = new GroupBox();
            YazarEkle = new Button();
            YeniYazar = new TextBox();
            groupBox1 = new GroupBox();
            KategoriEkle = new Button();
            YeniKategori = new TextBox();
            Iptal = new Button();
            Sil = new Button();
            Kaydet = new Button();
            Kategoriler = new CheckedListBox();
            label12 = new Label();
            Cilt = new NumericUpDown();
            label11 = new Label();
            Bitis = new DateTimePicker();
            label10 = new Label();
            Baslangic = new DateTimePicker();
            label9 = new Label();
            Durum = new ComboBox();
            label8 = new Label();
            Puan = new NumericUpDown();
            label7 = new Label();
            OkunanSayfa = new NumericUpDown();
            label6 = new Label();
            ToplamSayfa = new NumericUpDown();
            label5 = new Label();
            Yazar = new ComboBox();
            label4 = new Label();
            KitapAdi = new TextBox();
            label3 = new Label();
            Baslik = new Label();
            Istatistikler = new TabPage();
            label21 = new Label();
            label20 = new Label();
            label19 = new Label();
            label18 = new Label();
            label17 = new Label();
            label16 = new Label();
            label15 = new Label();
            label14 = new Label();
            tabControl1.SuspendLayout();
            Kutuphane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Kitaplar).BeginInit();
            Ekle.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Cilt).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Puan).BeginInit();
            ((System.ComponentModel.ISupportInitialize)OkunanSayfa).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ToplamSayfa).BeginInit();
            Istatistikler.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(Kutuphane);
            tabControl1.Controls.Add(Ekle);
            tabControl1.Controls.Add(Istatistikler);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1400, 703);
            tabControl1.TabIndex = 0;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // Kutuphane
            // 
            Kutuphane.Controls.Add(panelFiltre);
            Kutuphane.Controls.Add(FiltreDurum);
            Kutuphane.Controls.Add(labelDurum);
            Kutuphane.Controls.Add(Kitaplar);
            Kutuphane.Controls.Add(Ara);
            Kutuphane.Controls.Add(label2);
            Kutuphane.Location = new Point(4, 29);
            Kutuphane.Name = "Kutuphane";
            Kutuphane.Padding = new Padding(3);
            Kutuphane.Size = new Size(1392, 670);
            Kutuphane.TabIndex = 0;
            Kutuphane.Text = "Kütüphanem";
            // 
            // panelFiltre
            // 
            panelFiltre.AutoScroll = true;
            panelFiltre.BorderStyle = BorderStyle.FixedSingle;
            panelFiltre.Location = new Point(1115, 40);
            panelFiltre.Name = "panelFiltre";
            panelFiltre.Size = new Size(269, 624);
            panelFiltre.TabIndex = 5;
            // 
            // FiltreDurum
            // 
            FiltreDurum.DropDownStyle = ComboBoxStyle.DropDownList;
            FiltreDurum.FormattingEnabled = true;
            FiltreDurum.Items.AddRange(new object[] { "Hepsi", "Okunacak", "Okunuyor", "Okundu" });
            FiltreDurum.Location = new Point(66, 6);
            FiltreDurum.Name = "FiltreDurum";
            FiltreDurum.Size = new Size(130, 28);
            FiltreDurum.TabIndex = 6;
            FiltreDurum.SelectedIndexChanged += FiltreDurum_SelectedIndexChanged;
            // 
            // labelDurum
            // 
            labelDurum.AutoSize = true;
            labelDurum.Location = new Point(3, 9);
            labelDurum.Name = "labelDurum";
            labelDurum.Size = new Size(57, 20);
            labelDurum.TabIndex = 7;
            labelDurum.Text = "Durum:";
            // 
            // Kitaplar
            // 
            Kitaplar.AllowUserToAddRows = false;
            Kitaplar.AllowUserToDeleteRows = false;
            Kitaplar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Kitaplar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Kitaplar.Location = new Point(3, 40);
            Kitaplar.Name = "Kitaplar";
            Kitaplar.ReadOnly = true;
            Kitaplar.RowHeadersVisible = false;
            Kitaplar.RowHeadersWidth = 51;
            Kitaplar.SelectionMode = DataGridViewSelectionMode.CellSelect;
            Kitaplar.Size = new Size(1106, 624);
            Kitaplar.TabIndex = 4;
            Kitaplar.CellDoubleClick += Kitaplar_CellDoubleClick;
            // 
            // Ara
            // 
            Ara.Location = new Point(264, 6);
            Ara.Name = "Ara";
            Ara.Size = new Size(825, 27);
            Ara.TabIndex = 3;
            Ara.TextChanged += Ara_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(223, 9);
            label2.Name = "label2";
            label2.Size = new Size(35, 20);
            label2.TabIndex = 2;
            label2.Text = "Ara:";
            // 
            // Ekle
            // 
            Ekle.Controls.Add(groupBox2);
            Ekle.Controls.Add(groupBox1);
            Ekle.Controls.Add(Iptal);
            Ekle.Controls.Add(Sil);
            Ekle.Controls.Add(Kaydet);
            Ekle.Controls.Add(Kategoriler);
            Ekle.Controls.Add(label12);
            Ekle.Controls.Add(Cilt);
            Ekle.Controls.Add(label11);
            Ekle.Controls.Add(Bitis);
            Ekle.Controls.Add(label10);
            Ekle.Controls.Add(Baslangic);
            Ekle.Controls.Add(label9);
            Ekle.Controls.Add(Durum);
            Ekle.Controls.Add(label8);
            Ekle.Controls.Add(Puan);
            Ekle.Controls.Add(label7);
            Ekle.Controls.Add(OkunanSayfa);
            Ekle.Controls.Add(label6);
            Ekle.Controls.Add(ToplamSayfa);
            Ekle.Controls.Add(label5);
            Ekle.Controls.Add(Yazar);
            Ekle.Controls.Add(label4);
            Ekle.Controls.Add(KitapAdi);
            Ekle.Controls.Add(label3);
            Ekle.Controls.Add(Baslik);
            Ekle.Location = new Point(4, 29);
            Ekle.Name = "Ekle";
            Ekle.Padding = new Padding(3);
            Ekle.Size = new Size(1392, 670);
            Ekle.TabIndex = 2;
            Ekle.Text = "Ekle";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(YazarEkle);
            groupBox2.Controls.Add(YeniYazar);
            groupBox2.Location = new Point(650, 107);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(420, 80);
            groupBox2.TabIndex = 38;
            groupBox2.TabStop = false;
            groupBox2.Text = "Yeni Yazar Ekle";
            // 
            // YazarEkle
            // 
            YazarEkle.Location = new Point(330, 30);
            YazarEkle.Name = "YazarEkle";
            YazarEkle.Size = new Size(80, 30);
            YazarEkle.TabIndex = 1;
            YazarEkle.Text = "Ekle";
            YazarEkle.UseVisualStyleBackColor = true;
            YazarEkle.Click += YazarEkle_Click;
            // 
            // YeniYazar
            // 
            YeniYazar.Location = new Point(10, 32);
            YeniYazar.Name = "YeniYazar";
            YeniYazar.Size = new Size(310, 27);
            YeniYazar.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(KategoriEkle);
            groupBox1.Controls.Add(YeniKategori);
            groupBox1.Location = new Point(650, 20);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(420, 80);
            groupBox1.TabIndex = 37;
            groupBox1.TabStop = false;
            groupBox1.Text = "Yeni Kategori Ekle";
            // 
            // KategoriEkle
            // 
            KategoriEkle.Location = new Point(330, 30);
            KategoriEkle.Name = "KategoriEkle";
            KategoriEkle.Size = new Size(80, 30);
            KategoriEkle.TabIndex = 1;
            KategoriEkle.Text = "Ekle";
            KategoriEkle.UseVisualStyleBackColor = true;
            KategoriEkle.Click += KategoriEkle_Click;
            // 
            // YeniKategori
            // 
            YeniKategori.Location = new Point(10, 32);
            YeniKategori.Name = "YeniKategori";
            YeniKategori.Size = new Size(310, 27);
            YeniKategori.TabIndex = 0;
            // 
            // Iptal
            // 
            Iptal.Location = new Point(350, 430);
            Iptal.Name = "Iptal";
            Iptal.Size = new Size(150, 40);
            Iptal.TabIndex = 36;
            Iptal.Text = "İptal";
            Iptal.UseVisualStyleBackColor = true;
            Iptal.Click += Iptal_Click;
            // 
            // Sil
            // 
            Sil.Location = new Point(190, 430);
            Sil.Name = "Sil";
            Sil.Size = new Size(150, 40);
            Sil.TabIndex = 35;
            Sil.Text = "Sil";
            Sil.UseVisualStyleBackColor = true;
            Sil.Visible = false;
            Sil.Click += Sil_Click;
            // 
            // Kaydet
            // 
            Kaydet.Location = new Point(30, 430);
            Kaydet.Name = "Kaydet";
            Kaydet.Size = new Size(150, 40);
            Kaydet.TabIndex = 34;
            Kaydet.Text = "Ekle";
            Kaydet.UseVisualStyleBackColor = true;
            Kaydet.Click += Kaydet_Click;
            // 
            // Kategoriler
            // 
            Kategoriler.FormattingEnabled = true;
            Kategoriler.Location = new Point(650, 220);
            Kategoriler.Name = "Kategoriler";
            Kategoriler.Size = new Size(420, 246);
            Kategoriler.TabIndex = 33;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(650, 195);
            label12.Name = "label12";
            label12.Size = new Size(86, 20);
            label12.TabIndex = 32;
            label12.Text = "Kategoriler:";
            // 
            // Cilt
            // 
            Cilt.Location = new Point(30, 360);
            Cilt.Name = "Cilt";
            Cilt.Size = new Size(80, 27);
            Cilt.TabIndex = 29;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(30, 337);
            label11.Name = "label11";
            label11.Size = new Size(75, 20);
            label11.TabIndex = 28;
            label11.Text = "Cilt Sayısı:";
            // 
            // Bitis
            // 
            Bitis.Checked = false;
            Bitis.Location = new Point(390, 290);
            Bitis.Name = "Bitis";
            Bitis.ShowCheckBox = true;
            Bitis.Size = new Size(200, 27);
            Bitis.TabIndex = 27;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(390, 267);
            label10.Name = "label10";
            label10.Size = new Size(79, 20);
            label10.TabIndex = 26;
            label10.Text = "Bitiş Tarihi:";
            // 
            // Baslangic
            // 
            Baslangic.Checked = false;
            Baslangic.Location = new Point(180, 290);
            Baslangic.Name = "Baslangic";
            Baslangic.ShowCheckBox = true;
            Baslangic.Size = new Size(200, 27);
            Baslangic.TabIndex = 25;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(180, 267);
            label9.Name = "label9";
            label9.Size = new Size(114, 20);
            label9.TabIndex = 24;
            label9.Text = "Başlangıç Tarihi:";
            // 
            // Durum
            // 
            Durum.DropDownStyle = ComboBoxStyle.DropDownList;
            Durum.FormattingEnabled = true;
            Durum.Items.AddRange(new object[] { "Okunacak", "Okunuyor", "Okundu" });
            Durum.Location = new Point(30, 290);
            Durum.Name = "Durum";
            Durum.Size = new Size(130, 28);
            Durum.TabIndex = 23;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(30, 267);
            label8.Name = "label8";
            label8.Size = new Size(57, 20);
            label8.TabIndex = 22;
            label8.Text = "Durum:";
            // 
            // Puan
            // 
            Puan.DecimalPlaces = 1;
            Puan.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            Puan.Location = new Point(320, 220);
            Puan.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            Puan.Name = "Puan";
            Puan.Size = new Size(80, 27);
            Puan.TabIndex = 21;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(320, 197);
            label7.Name = "label7";
            label7.Size = new Size(44, 20);
            label7.TabIndex = 20;
            label7.Text = "Puan:";
            // 
            // OkunanSayfa
            // 
            OkunanSayfa.Location = new Point(170, 220);
            OkunanSayfa.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            OkunanSayfa.Name = "OkunanSayfa";
            OkunanSayfa.Size = new Size(130, 27);
            OkunanSayfa.TabIndex = 19;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(170, 197);
            label6.Name = "label6";
            label6.Size = new Size(102, 20);
            label6.TabIndex = 18;
            label6.Text = "Okunan Sayfa:";
            // 
            // ToplamSayfa
            // 
            ToplamSayfa.Location = new Point(30, 220);
            ToplamSayfa.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            ToplamSayfa.Name = "ToplamSayfa";
            ToplamSayfa.Size = new Size(130, 27);
            ToplamSayfa.TabIndex = 17;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(30, 197);
            label5.Name = "label5";
            label5.Size = new Size(102, 20);
            label5.TabIndex = 16;
            label5.Text = "Toplam Sayfa:";
            // 
            // Yazar
            // 
            Yazar.DropDownStyle = ComboBoxStyle.DropDownList;
            Yazar.FormattingEnabled = true;
            Yazar.Location = new Point(30, 150);
            Yazar.Name = "Yazar";
            Yazar.Size = new Size(260, 28);
            Yazar.TabIndex = 15;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(30, 127);
            label4.Name = "label4";
            label4.Size = new Size(47, 20);
            label4.TabIndex = 14;
            label4.Text = "Yazar:";
            // 
            // KitapAdi
            // 
            KitapAdi.Location = new Point(30, 85);
            KitapAdi.Name = "KitapAdi";
            KitapAdi.Size = new Size(560, 27);
            KitapAdi.TabIndex = 13;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 62);
            label3.Name = "label3";
            label3.Size = new Size(74, 20);
            label3.TabIndex = 12;
            label3.Text = "Kitap Adı:";
            // 
            // Baslik
            // 
            Baslik.AutoSize = true;
            Baslik.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            Baslik.Location = new Point(30, 15);
            Baslik.Name = "Baslik";
            Baslik.Size = new Size(182, 32);
            Baslik.TabIndex = 11;
            Baslik.Text = "Yeni Kitap Ekle";
            // 
            // Istatistikler
            // 
            Istatistikler.Controls.Add(label21);
            Istatistikler.Controls.Add(label20);
            Istatistikler.Controls.Add(label19);
            Istatistikler.Controls.Add(label18);
            Istatistikler.Controls.Add(label17);
            Istatistikler.Controls.Add(label16);
            Istatistikler.Controls.Add(label15);
            Istatistikler.Controls.Add(label14);
            Istatistikler.Location = new Point(4, 29);
            Istatistikler.Name = "Istatistikler";
            Istatistikler.Padding = new Padding(3);
            Istatistikler.Size = new Size(1392, 670);
            Istatistikler.TabIndex = 1;
            Istatistikler.Text = "İstatistikler";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Segoe UI", 12F);
            label21.Location = new Point(150, 20);
            label21.Name = "label21";
            label21.Size = new Size(256, 28);
            label21.TabIndex = 7;
            label21.Text = "KÜTÜPHANE İSTATİSTİKLERİ";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Segoe UI", 12F);
            label20.Location = new Point(50, 380);
            label20.Name = "label20";
            label20.Size = new Size(158, 28);
            label20.TabIndex = 0;
            label20.Text = "Ortalama Puan: -";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI", 12F);
            label19.Location = new Point(50, 300);
            label19.Name = "label19";
            label19.Size = new Size(152, 28);
            label19.TabIndex = 1;
            label19.Text = "Okunan Sayfa: 0";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 12F);
            label18.Location = new Point(50, 260);
            label18.Name = "label18";
            label18.Size = new Size(148, 28);
            label18.TabIndex = 2;
            label18.Text = "Toplam Sayfa: 0";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 12F);
            label17.Location = new Point(50, 180);
            label17.Name = "label17";
            label17.Size = new Size(223, 28);
            label17.TabIndex = 3;
            label17.Text = "Okunacak Kitap Sayısı: 0";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 12F);
            label16.Location = new Point(50, 140);
            label16.Name = "label16";
            label16.Size = new Size(205, 28);
            label16.TabIndex = 4;
            label16.Text = "Okunan Kitap Sayısı: 0";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 12F);
            label15.Location = new Point(50, 100);
            label15.Name = "label15";
            label15.Size = new Size(220, 28);
            label15.TabIndex = 5;
            label15.Text = "Okunmuş Kitap Sayısı: 0";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 12F);
            label14.Location = new Point(50, 60);
            label14.Name = "label14";
            label14.Size = new Size(147, 28);
            label14.TabIndex = 6;
            label14.Text = "Toplam Kitap: 0";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1400, 703);
            Controls.Add(tabControl1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Benim Kütüphanem";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            Kutuphane.ResumeLayout(false);
            Kutuphane.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Kitaplar).EndInit();
            Ekle.ResumeLayout(false);
            Ekle.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Cilt).EndInit();
            ((System.ComponentModel.ISupportInitialize)Puan).EndInit();
            ((System.ComponentModel.ISupportInitialize)OkunanSayfa).EndInit();
            ((System.ComponentModel.ISupportInitialize)ToplamSayfa).EndInit();
            Istatistikler.ResumeLayout(false);
            Istatistikler.PerformLayout();
            ResumeLayout(false);
        }

        private TabControl tabControl1;
        private TabPage Kutuphane;
        private Panel panelFiltre;
        private ComboBox FiltreDurum;
        private Label labelDurum;
        private DataGridView Kitaplar;
        private TextBox Ara;
        private Label label2;
        private TabPage Ekle;
        private TabPage Istatistikler;
        private Label Baslik;
        private Label label3;
        private TextBox KitapAdi;
        private Label label4;
        private ComboBox Yazar;
        private Label label5;
        private NumericUpDown ToplamSayfa;
        private Label label6;
        private NumericUpDown OkunanSayfa;
        private Label label7;
        private NumericUpDown Puan;
        private Label label8;
        private ComboBox Durum;
        private Label label9;
        private DateTimePicker Baslangic;
        private Label label10;
        private DateTimePicker Bitis;
        private Label label11;
        private NumericUpDown Cilt;
        private Label label12;
        private CheckedListBox Kategoriler;
        private Button Kaydet;
        private Button Sil;
        private Button Iptal;
        private GroupBox groupBox1;
        private Button KategoriEkle;
        private TextBox YeniKategori;
        private GroupBox groupBox2;
        private Button YazarEkle;
        private TextBox YeniYazar;
        private Label label14;
        private Label label16;
        private Label label15;
        private Label label17;
        private Label label20;
        private Label label19;
        private Label label18;
        private Label label21;
    }
}
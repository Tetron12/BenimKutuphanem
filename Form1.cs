using System.Data;
using System.Data.SqlClient;

namespace BenimKutuphanem
{
    public partial class Form1 : Form
    {
        // Filtre
        private Dictionary<int, int> kategoriFiltreDurumlari = new Dictionary<int, int>();
        private List<Button> kategoriButonlari = new List<Button>();
        private Color renkNormal = Color.FromArgb(240, 240, 240);
        private Color renkDahil = Color.FromArgb(144, 238, 144);
        private Color renkHaric = Color.FromArgb(255, 182, 193);

        private Size normalBoyut;
        private Size ekleBoyut;
        private Size istatistikBoyut;

        public Form1()
        {
            InitializeComponent();
            normalBoyut = new Size(1400, 703);
            ekleBoyut = new Size(1100, 700);
            istatistikBoyut = new Size(600, 500);
            this.Size = normalBoyut;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
                VeritabaniAl();
                KitaplariYukle();
                KategorileriYukle();
                YazarlariYukle();
                EkleFormSifirla();
                IstatistikleriYukle();
                Kitaplar.KeyDown += Kitaplar_KeyDown;
                FiltreDurum.SelectedIndex = 0;
                KategoriFiltreButonlariniOlustur();
                this.Size = normalBoyut;
        }

        // Veritabanını sql dosyasından al
        private void VeritabaniAl()
        {
            try
            {
                string sqlDosya = Path.Combine(Application.StartupPath, "BenimKutuphanem.sql");

                if (!File.Exists(sqlDosya))
                {
                    MessageBox.Show("BenimKutuphanem.sql dosyası bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string masterBaglanti = @"Data Source=.\SQLEXPRESS;Initial Catalog=master;Integrated Security=True;";

                using (SqlConnection conn = new SqlConnection(masterBaglanti))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(
                        "IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'BenimKutuphanem') CREATE DATABASE BenimKutuphanem", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

                // Şimdi veritabanına bağlanıp SQL dosyasını çalıştır
                string sql = File.ReadAllText(sqlDosya);
                string[] komutlar = sql.Split(new[] { "GO" }, StringSplitOptions.RemoveEmptyEntries);

                using (SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=BenimKutuphanem;Integrated Security=True;"))
                {
                    conn.Open();

                    for (int i = 0; i < komutlar.Length; i++)
                    {
                        string komut = komutlar[i].Trim();
                        if (!string.IsNullOrEmpty(komut))
                        {
                            if (komut.StartsWith("USE", StringComparison.OrdinalIgnoreCase))
                                continue;

                            try
                            {
                                using (SqlCommand cmd = new SqlCommand(komut, conn))
                                {
                                    cmd.ExecuteNonQuery();
                                }
                            }
                            catch
                            {
                                // Tablo zaten varsa devam et
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veritabanı oluşturulurken hata: {ex.Message}", "Hata");
            }
        }

        // Kategori filtre butonları
        private void KategoriFiltreButonlariniOlustur()
        {
            panelFiltre.Controls.Clear();
            kategoriButonlari.Clear();
            kategoriFiltreDurumlari.Clear();

            DataTable dt = Veritabani.Sorgu("SELECT KategoriID, KategoriAd FROM Kategoriler ORDER BY KategoriAd");

            int x = 5, y = 5;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                int katID = Convert.ToInt32(row["KategoriID"]);
                string katAd = row["KategoriAd"].ToString();

                kategoriFiltreDurumlari[katID] = 0;

                Button btn = new Button();
                btn.Text = katAd;
                btn.Tag = katID;
                btn.AutoSize = true;
                btn.FlatStyle = FlatStyle.Flat;
                btn.BackColor = renkNormal;
                btn.Font = new Font("Segoe UI", 8F);
                btn.Padding = new Padding(4, 2, 4, 2);
                btn.Margin = new Padding(2);
                btn.Cursor = Cursors.Hand;

                using (Graphics g = btn.CreateGraphics())
                {
                    SizeF size = g.MeasureString(katAd, btn.Font);
                    btn.Width = (int)size.Width + 20;
                    btn.Height = 26;
                }

                btn.Location = new Point(x, y);
                btn.Click += KategoriFiltreButon_Click;

                panelFiltre.Controls.Add(btn);
                kategoriButonlari.Add(btn);

                x += btn.Width + 3;
                if (x + 100 > panelFiltre.Width - 20)
                {
                    x = 5;
                    y += 30;
                }
            }
        }

        // 3 durumlu filtre tıklaması
        private void KategoriFiltreButon_Click(object? sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is int katID)
            {
                if (!kategoriFiltreDurumlari.ContainsKey(katID))
                    kategoriFiltreDurumlari[katID] = 0;

                kategoriFiltreDurumlari[katID] = (kategoriFiltreDurumlari[katID] + 1) % 3;

                switch (kategoriFiltreDurumlari[katID])
                {
                    case 0: btn.BackColor = renkNormal; break;
                    case 1: btn.BackColor = renkDahil; break;
                    case 2: btn.BackColor = renkHaric; break;
                }

                KitaplariYukle();
            }
        }

        // Kitap listesini yükle
        private void KitaplariYukle()
        {
            try
            {
                string kategoriSarti = KategoriFiltreSartiOlustur();

                string sql = @"SELECT k.KitapID, k.KitapAd as 'Kitap', ISNULL(y.AdSoyad,'Bilinmiyor') as 'Yazar', 
                    k.Puan, k.Durum, k.OkunanSayfa as 'Okunan', k.ToplamSayfa as 'Toplam', k.Cilt 
                    FROM Kitaplar k 
                    LEFT JOIN Yazarlar y ON k.YazarID=y.YazarID 
                    WHERE 1=1";

                if (FiltreDurum.SelectedIndex > 0)
                    sql += $" AND k.Durum=N'{FiltreDurum.SelectedItem}'";

                if (!string.IsNullOrWhiteSpace(Ara.Text))
                    sql += $" AND (k.KitapAd LIKE N'%{Ara.Text.Replace("'", "''")}%' OR ISNULL(y.AdSoyad,'') LIKE N'%{Ara.Text.Replace("'", "''")}%')";

                if (!string.IsNullOrEmpty(kategoriSarti))
                    sql += kategoriSarti;

                sql += " ORDER BY k.KitapID DESC";

                DataTable dt = Veritabani.Sorgu(sql);
                Kitaplar.DataSource = dt;
                if (Kitaplar.Columns["KitapID"] != null) Kitaplar.Columns["KitapID"].Visible = false;
            }
            catch (Exception ex) { MessageBox.Show($"Hata: {ex.Message}"); }
        }

        // Filtre SQL şartı oluştur
        private string KategoriFiltreSartiOlustur()
        {
            var dahilKategoriler = new List<int>();
            var haricKategoriler = new List<int>();

            foreach (var kvp in kategoriFiltreDurumlari)
            {
                if (kvp.Value == 1) dahilKategoriler.Add(kvp.Key);
                else if (kvp.Value == 2) haricKategoriler.Add(kvp.Key);
            }

            if (dahilKategoriler.Count == 0 && haricKategoriler.Count == 0)
                return "";

            string sart = "";

            for (int i = 0; i < dahilKategoriler.Count; i++)
            {
                sart += $" AND k.KitapID IN (SELECT KitapID FROM KitapKategoriler WHERE KategoriID={dahilKategoriler[i]})";
            }

            for (int i = 0; i < haricKategoriler.Count; i++)
            {
                sart += $" AND k.KitapID NOT IN (SELECT KitapID FROM KitapKategoriler WHERE KategoriID={haricKategoriler[i]})";
            }

            return sart;
        }

        private void FiltreDurum_SelectedIndexChanged(object sender, EventArgs e)
        {
            KitaplariYukle();
        }

        private void Ara_TextChanged(object sender, EventArgs e)
        {
            KitaplariYukle();
        }

        private void Kitaplar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int id = Convert.ToInt32(Kitaplar.Rows[e.RowIndex].Cells["KitapID"].Value);
                tabControl1.SelectedTab = Ekle;
                DuzenlemeAc(id);
            }
        }

        // Ekle / Düzenle
        private int _duzenlemeID = 0;

        private void KategorileriYukle()
        {
            DataTable dt = Veritabani.Sorgu("SELECT KategoriID,KategoriAd FROM Kategoriler ORDER BY KategoriAd");
            Kategoriler.DataSource = dt;
            Kategoriler.DisplayMember = "KategoriAd";
            Kategoriler.ValueMember = "KategoriID";
        }

        private void YazarlariYukle()
        {
            DataTable dt = Veritabani.Sorgu("SELECT YazarID,AdSoyad FROM Yazarlar ORDER BY AdSoyad");
            Yazar.DataSource = dt;
            Yazar.DisplayMember = "AdSoyad";
            Yazar.ValueMember = "YazarID";
            Yazar.SelectedIndex = -1;
        }

        private void EkleFormSifirla()
        {
            _duzenlemeID = 0;
            Baslik.Text = "Yeni Kitap Ekle";
            Kaydet.Text = "Ekle";
            Sil.Visible = false;
            KitapAdi.Clear();
            Yazar.SelectedIndex = -1;
            ToplamSayfa.Value = 0;
            OkunanSayfa.Value = 0;
            Puan.Value = 0;
            Cilt.Value = 0;
            Durum.SelectedIndex = 0;
            Baslangic.Checked = false;
            Bitis.Checked = false;
            for (int i = 0; i < Kategoriler.Items.Count; i++) Kategoriler.SetItemChecked(i, false);
            YeniKategori.Clear();
            YeniYazar.Clear();
        }

        private void DuzenlemeAc(int id)
        {
            _duzenlemeID = id;
            Baslik.Text = "Kitap Düzenle";
            Kaydet.Text = "Güncelle";
            Sil.Visible = true;

            for (int i = 0; i < Kategoriler.Items.Count; i++) Kategoriler.SetItemChecked(i, false);

            try
            {
                DataTable dt = Veritabani.Sorgu($"SELECT * FROM Kitaplar WHERE KitapID={id}");
                if (dt.Rows.Count > 0)
                {
                    DataRow r = dt.Rows[0];
                    KitapAdi.Text = r["KitapAd"].ToString();
                    if (r["YazarID"] != DBNull.Value) Yazar.SelectedValue = Convert.ToInt32(r["YazarID"]); else Yazar.SelectedIndex = -1;
                    ToplamSayfa.Value = Convert.ToDecimal(r["ToplamSayfa"]);
                    OkunanSayfa.Value = Convert.ToDecimal(r["OkunanSayfa"]);
                    Puan.Value = Convert.ToDecimal(r["Puan"]);
                    Cilt.Value = Convert.ToDecimal(r["Cilt"]);
                    Durum.SelectedItem = r["Durum"].ToString();
                    if (r["BaslangicTarihi"] != DBNull.Value) { Baslangic.Checked = true; Baslangic.Value = Convert.ToDateTime(r["BaslangicTarihi"]); } else Baslangic.Checked = false;
                    if (r["BitisTarihi"] != DBNull.Value) { Bitis.Checked = true; Bitis.Value = Convert.ToDateTime(r["BitisTarihi"]); } else Bitis.Checked = false;
                }

                DataTable kk = Veritabani.Sorgu($"SELECT KategoriID FROM KitapKategoriler WHERE KitapID={id}");
                for (int i = 0; i < kk.Rows.Count; i++)
                {
                    DataRow row = kk.Rows[i];
                    int katID = Convert.ToInt32(row["KategoriID"]);
                    for (int j = 0; j < Kategoriler.Items.Count; j++)
                    {
                        if (Convert.ToInt32(((DataRowView)Kategoriler.Items[j])["KategoriID"]) == katID)
                        {
                            Kategoriler.SetItemChecked(j, true);
                            break;
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Hata: {ex.Message}"); }
        }

        // Kaydet / Güncelle
        private void Kaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(KitapAdi.Text)) { MessageBox.Show("Kitap adı zorunlu!"); return; }
            try
            {
                string ad = KitapAdi.Text.Replace("'", "''");
                string yID = Yazar.SelectedValue?.ToString() ?? "NULL";
                int t = (int)ToplamSayfa.Value, o = (int)OkunanSayfa.Value, c = (int)Cilt.Value;
                string p = Puan.Value.ToString().Replace(',', '.');
                string d = Durum.SelectedItem!.ToString()!;
                string bas = Baslangic.Checked ? $"'{Baslangic.Value:yyyy-MM-dd}'" : "NULL";
                string bit = Bitis.Checked ? $"'{Bitis.Value:yyyy-MM-dd}'" : "NULL";

                int kitapID = _duzenlemeID;

                if (_duzenlemeID > 0)
                {
                    Veritabani.Komut($"UPDATE Kitaplar SET KitapAd=N'{ad}',YazarID={yID},ToplamSayfa={t},OkunanSayfa={o},Puan={p},Durum=N'{d}',BaslangicTarihi={bas},BitisTarihi={bit},Cilt={c} WHERE KitapID={_duzenlemeID}");
                    Veritabani.Komut($"DELETE FROM KitapKategoriler WHERE KitapID={_duzenlemeID}");
                    MessageBox.Show("Güncellendi!");
                }
                else
                {
                    Veritabani.Komut($"INSERT INTO Kitaplar (KitapAd,YazarID,ToplamSayfa,OkunanSayfa,Puan,Durum,BaslangicTarihi,BitisTarihi,KayitTarihi,Cilt) VALUES (N'{ad}',{yID},{t},{o},{p},N'{d}',{bas},{bit},GETDATE(),{c})");
                    object sonID = Veritabani.TekDeger("SELECT IDENT_CURRENT('Kitaplar')");
                    kitapID = Convert.ToInt32(sonID);
                    MessageBox.Show("Eklendi!");
                }

                for (int i = 0; i < Kategoriler.Items.Count; i++)
                {
                    if (Kategoriler.GetItemChecked(i))
                    {
                        int katID = Convert.ToInt32(((DataRowView)Kategoriler.Items[i])["KategoriID"]);
                        Veritabani.Komut($"INSERT INTO KitapKategoriler (KitapID, KategoriID) VALUES ({kitapID}, {katID})");
                    }
                }

                EkleFormSifirla();
                tabControl1.SelectedTab = Kutuphane;
                KitaplariYukle();
                IstatistikleriYukle();
                KategoriFiltreButonlariniOlustur();
            }
            catch (Exception ex) { MessageBox.Show($"Hata: {ex.Message}"); }
        }

        // Sil
        private void Sil_Click(object sender, EventArgs e)
        {
            if (_duzenlemeID <= 0) return;
            if (MessageBox.Show("Silmek istediğine emin misin?", "Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Veritabani.Komut($"DELETE FROM Kitaplar WHERE KitapID={_duzenlemeID}");
                EkleFormSifirla();
                tabControl1.SelectedTab = Kutuphane;
                KitaplariYukle();
                IstatistikleriYukle();
                KategoriFiltreButonlariniOlustur();
                MessageBox.Show("Silindi!");
            }
        }

        private void Iptal_Click(object sender, EventArgs e)
        {
            EkleFormSifirla();
            tabControl1.SelectedTab = Kutuphane;
        }

        // Yeni kategori ekle
        private void KategoriEkle_Click(object sender, EventArgs e)
        {
            string ad = YeniKategori.Text.Trim();
            if (string.IsNullOrWhiteSpace(ad)) { MessageBox.Show("Kategori adı yaz!"); return; }
            try
            {
                if (Convert.ToInt32(Veritabani.TekDeger($"SELECT COUNT(*) FROM Kategoriler WHERE KategoriAd=N'{ad.Replace("'", "''")}'")) > 0)
                { MessageBox.Show("Zaten var!"); return; }
                Veritabani.Komut($"INSERT INTO Kategoriler (KategoriAd) VALUES (N'{ad.Replace("'", "''")}')");
                KategorileriYukle();
                YeniKategori.Clear();
                KategoriFiltreButonlariniOlustur();
                MessageBox.Show("Kategori eklendi!");
            }
            catch (Exception ex) { MessageBox.Show($"Hata: {ex.Message}"); }
        }

        // Yeni yazar ekle
        private void YazarEkle_Click(object sender, EventArgs e)
        {
            string ad = YeniYazar.Text.Trim();
            if (string.IsNullOrWhiteSpace(ad)) { MessageBox.Show("Yazar adı yaz!"); return; }
            try
            {
                if (Convert.ToInt32(Veritabani.TekDeger($"SELECT COUNT(*) FROM Yazarlar WHERE AdSoyad=N'{ad.Replace("'", "''")}'")) > 0)
                { MessageBox.Show("Zaten var!"); return; }
                Veritabani.Komut($"INSERT INTO Yazarlar (AdSoyad) VALUES (N'{ad.Replace("'", "''")}')");
                YazarlariYukle();
                YeniYazar.Clear();
                MessageBox.Show("Yazar eklendi!");
            }
            catch (Exception ex) { MessageBox.Show($"Hata: {ex.Message}"); }
        }

        // İstatistikleri yükle
        private void IstatistikleriYukle()
        {
            try
            {
                object t = Veritabani.TekDeger("SELECT COUNT(*) FROM Kitaplar");
                object o1 = Veritabani.TekDeger("SELECT COUNT(*) FROM Kitaplar WHERE Durum='Okundu'");
                object o2 = Veritabani.TekDeger("SELECT COUNT(*) FROM Kitaplar WHERE Durum='Okunuyor'");
                object o3 = Veritabani.TekDeger("SELECT COUNT(*) FROM Kitaplar WHERE Durum='Okunacak'");
                object ts = Veritabani.TekDeger("SELECT SUM(ToplamSayfa) FROM Kitaplar");
                object os = Veritabani.TekDeger("SELECT SUM(OkunanSayfa) FROM Kitaplar");
                object puan = Veritabani.TekDeger("SELECT AVG(CAST(Puan AS DECIMAL(10,1))) FROM Kitaplar WHERE Puan>0");

                label14.Text = $"Toplam Kitap: {t ?? 0}";
                label15.Text = $"Okunmuş Kitap Sayısı: {o1 ?? 0}";
                label16.Text = $"Okunan Kitap Sayısı: {o2 ?? 0}";
                label17.Text = $"Okunacak Kitap Sayısı: {o3 ?? 0}";
                label18.Text = $"Toplam Sayfa: {ts ?? 0}";
                label19.Text = $"Okunan Sayfa: {os ?? 0}";
                if (puan != DBNull.Value && puan != null)
                    label20.Text = $"Ortalama Puan: {Convert.ToDecimal(puan):F1}";
                else
                    label20.Text = "Ortalama Puan: -";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"İstatistik yüklenirken hata: {ex.Message}");
            }
        }

        private void Kutuphane_Click(object sender, EventArgs e) { }

        // Tab değişince form boyutu ayarla
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == Istatistikler)
            {
                IstatistikleriYukle();
                this.Size = istatistikBoyut;
            }
            else if (tabControl1.SelectedTab == Ekle)
            {
                this.Size = ekleBoyut;
            }
            else
            {
                this.Size = normalBoyut;
            }
        }

        // Delete tuşu ile kitap sil
        private void Kitaplar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (Kitaplar.CurrentRow != null)
                {
                    int kitapID = Convert.ToInt32(Kitaplar.CurrentRow.Cells["KitapID"].Value);
                    string kitapAd = Kitaplar.CurrentRow.Cells["Kitap"].Value.ToString();

                    DialogResult sonuc = MessageBox.Show(
                        $"\"{kitapAd}\" kitabını silmek istediğine emin misin?",
                        "Kitap Sil",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button2);

                    if (sonuc == DialogResult.Yes)
                    {
                        try
                        {
                            Veritabani.Komut($"DELETE FROM Kitaplar WHERE KitapID={kitapID}");
                            KitaplariYukle();
                            IstatistikleriYukle();
                            KategoriFiltreButonlariniOlustur();

                            if (_duzenlemeID == kitapID)
                            {
                                EkleFormSifirla();
                                tabControl1.SelectedTab = Kutuphane;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Silme hatası: {ex.Message}");
                        }
                    }

                    e.Handled = true;
                }
            }
        }
    }
}
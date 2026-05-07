USE BenimKutuphanem

-- Tablolar
CREATE TABLE Yazarlar (
    YazarID INT PRIMARY KEY IDENTITY(1,1),
    AdSoyad NVARCHAR(100) NOT NULL
);

CREATE TABLE Kategoriler (
    KategoriID INT PRIMARY KEY IDENTITY(1,1),
    KategoriAd NVARCHAR(50) NOT NULL
);

CREATE TABLE Kitaplar (
    KitapID INT PRIMARY KEY IDENTITY(1,1),
    KitapAd NVARCHAR(200) NOT NULL,
    YazarID INT FOREIGN KEY REFERENCES Yazarlar(YazarID),
    ToplamSayfa INT DEFAULT 0,
    OkunanSayfa INT DEFAULT 0,
    Puan DECIMAL(3,1) DEFAULT 0,
    Durum NVARCHAR(20) DEFAULT 'Okunacak',
    BaslangicTarihi DATE NULL,
    BitisTarihi DATE NULL,
    KayitTarihi DATE DEFAULT GETDATE(),
    Cilt INT DEFAULT 0
);

CREATE TABLE KitapKategoriler (
    KitapKategoriID INT PRIMARY KEY IDENTITY(1,1),
    KitapID INT FOREIGN KEY REFERENCES Kitaplar(KitapID) ON DELETE CASCADE,
    KategoriID INT FOREIGN KEY REFERENCES Kategoriler(KategoriID) ON DELETE CASCADE
);

--Örnekler

-- Kategoriler
INSERT INTO Kategoriler (KategoriAd) VALUES 
('Roman'),('Bilim Kurgu'),('Fantastik'),('Korku'),('Polisiye'),
('Tarih'),('Felsefe'),('Bilim'),('Biyografi'),('Kişisel Gelişim'),
('Psikoloji'),('Ekonomi'),('Siyaset'),('Sanat'),('Gezi'),
('Şiir'),('Öykü'),('Çizgi Roman'),('Aşk'),('Macera');

-- Yazarlar
INSERT INTO Yazarlar (AdSoyad) VALUES 
('George Orwell'),('Sabahattin Ali'),('Orhan Pamuk'),('Franz Kafka'),
('Stefan Zweig'),('Dostoyevski'),('Tolstoy'),('Oğuz Atay'),
('Yusuf Atılgan'),('Ahmet Hamdi Tanpınar'),('J.R.R. Tolkien'),
('J.K. Rowling'),('Stephen King'),('Agatha Christie'),
('Yuval Noah Harari'),('Carl Sagan'),('Marcus Aurelius');

-- Kitaplar (Cilt: 0 = tek kitap/ciltsiz, 3 = 3 ciltli seri vs)
INSERT INTO Kitaplar (KitapAd, YazarID, ToplamSayfa, OkunanSayfa, Puan, Durum, BaslangicTarihi, BitisTarihi, Cilt) VALUES
('1984', 1, 352, 352, 9.5, 'Okundu', '2025-01-15', '2025-02-01', 0),
('Kürk Mantolu Madonna', 2, 160, 160, 9.2, 'Okundu', '2025-03-10', '2025-03-14', 0),
('Kara Kitap', 3, 448, 220, 8.0, 'Okunuyor', '2026-04-20', NULL, 0),
('Dönüşüm', 4, 74, 74, 8.8, 'Okundu', '2025-05-01', '2025-05-02', 0),
('Satranç', 5, 80, 80, 9.0, 'Okundu', '2025-02-20', '2025-02-22', 0),
('Suç ve Ceza', 6, 672, 672, 9.7, 'Okundu', '2024-11-01', '2024-12-15', 0),
('Anna Karenina', 7, 864, 0, 0, 'Okunacak', NULL, NULL, 0),
('Tutunamayanlar', 8, 724, 350, 8.5, 'Okunuyor', '2026-03-01', NULL, 0),
('Anayurt Oteli', 9, 112, 112, 8.3, 'Okundu', '2025-06-10', '2025-06-13', 0),
('Saatleri Ayarlama Enstitüsü', 10, 400, 0, 0, 'Okunacak', NULL, NULL, 0),
('Yüzüklerin Efendisi', 11, 1216, 1216, 9.8, 'Okundu', '2024-06-01', '2024-08-15', 3),
('Harry Potter ve Felsefe Taşı', 12, 274, 0, 8.7, 'Okunuyor', '2026-05-01', NULL, 7),
('O (It)', 13, 1152, 0, 0, 'Okunacak', NULL, NULL, 0),
('Doğu Ekspresinde Cinayet', 14, 256, 256, 9.1, 'Okundu', '2025-09-15', '2025-09-22', 0),
('Sapiens', 15, 464, 300, 9.3, 'Okunuyor', '2026-04-01', NULL, 0),
('Kozmos', 16, 368, 0, 0, 'Okunacak', NULL, NULL, 0),
('Kendime Düşünceler', 17, 304, 304, 8.9, 'Okundu', '2025-07-01', '2025-07-20', 0);

-- Kitap-Kategori eşleştirmeleri
INSERT INTO KitapKategoriler (KitapID, KategoriID) VALUES 
(1,1),(1,2),        -- 1984: Roman, Bilim Kurgu
(2,1),(2,19),       -- Kürk Mantolu Madonna: Roman, Aşk
(3,1),(3,5),        -- Kara Kitap: Roman, Polisiye
(4,1),(4,17),       -- Dönüşüm: Roman, Öykü
(5,1),(5,17),       -- Satranç: Roman, Öykü
(6,1),(6,11),       -- Suç ve Ceza: Roman, Psikoloji
(7,1),(7,19),       -- Anna Karenina: Roman, Aşk
(8,1),(8,11),       -- Tutunamayanlar: Roman, Psikoloji
(9,1),(9,11),       -- Anayurt Oteli: Roman, Psikoloji
(10,1),(10,11),     -- Saatleri Ayarlama Enstitüsü: Roman, Psikoloji
(11,3),(11,20),     -- Yüzüklerin Efendisi: Fantastik, Macera (3 cilt)
(12,3),(12,20),     -- Harry Potter: Fantastik, Macera (7 ciltlik seri)
(13,4),(13,3),      -- O (It): Korku, Fantastik
(14,5),             -- Doğu Ekspresinde Cinayet: Polisiye
(15,6),(15,8),      -- Sapiens: Tarih, Bilim
(16,8),(16,2),      -- Kozmos: Bilim, Bilim Kurgu
(17,7),(17,10);     -- Kendime Düşünceler: Felsefe, Kişisel Gelişim
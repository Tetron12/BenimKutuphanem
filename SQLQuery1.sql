USE Proje;

--Tablolar
CREATE TABLE Kategoriler (
    KategoriID INT PRIMARY KEY,
    KategoriAd VARCHAR(50)
);

CREATE TABLE Yazarlar (
    YazarID INT PRIMARY KEY,
    Ad VARCHAR(50),
    Soyad VARCHAR(50)
);

CREATE TABLE Uyeler (
    UyeID INT PRIMARY KEY,
    Ad VARCHAR(50),
    Soyad VARCHAR(50),
    Eposta VARCHAR(100),
    Telefon VARCHAR(15)
);

CREATE TABLE Kitaplar (
    KitapID INT PRIMARY KEY,
    KitapAd VARCHAR(100),
    YazarID INT FOREIGN KEY REFERENCES Yazarlar(YazarID),
    KategoriID INT FOREIGN KEY REFERENCES Kategoriler(KategoriID),
    SayfaSayisi INT,
    Stok INT
);

CREATE TABLE Emanetler (
    IslemID INT PRIMARY KEY,
    KitapID INT FOREIGN KEY REFERENCES Kitaplar(KitapID),
    UyeID INT FOREIGN KEY REFERENCES Uyeler(UyeID),
    VerilisTarihi DATE,
    IadeTarihi DATE,
    TeslimDurumu INT -- 0: Üyede, 1: Teslim Edildi
);

--Örnekler
INSERT INTO Kategoriler VALUES (1, 'Dünya Klasikleri');
INSERT INTO Kategoriler VALUES (2, 'Türk Edebiyatı');
INSERT INTO Kategoriler VALUES (3, 'Tarih');
INSERT INTO Kategoriler VALUES (4, 'Bilim Kurgu');
INSERT INTO Kategoriler VALUES (5, 'Polisiye');

INSERT INTO Yazarlar VALUES (1, 'Fyodor', 'Dostoyevski');
INSERT INTO Yazarlar VALUES (2, 'Sabahattin', 'Ali');
INSERT INTO Yazarlar VALUES (3, 'İlber', 'Ortaylı');
INSERT INTO Yazarlar VALUES (4, 'George', 'Orwell');
INSERT INTO Yazarlar VALUES (5, 'Agatha', 'Christie');
INSERT INTO Yazarlar VALUES (6, 'Reşat Nuri', 'Güntekin');
INSERT INTO Yazarlar VALUES (7, 'Franz', 'Kafka');

INSERT INTO Uyeler VALUES (1, 'Ali', 'Yılmaz', 'ali.yilmaz@gmail.com', '05321112233');
INSERT INTO Uyeler VALUES (2, 'Ayşe', 'Kaya', 'ayse.kaya@gmail.com', '05442223344');
INSERT INTO Uyeler VALUES (3, 'Mehmet', 'Demir', 'mehmet.demir@gmail.com', '05053334455');
INSERT INTO Uyeler VALUES (4, 'Fatma', 'Çelik', 'fatma.celik@gmail.com', '05554445566');
INSERT INTO Uyeler VALUES (5, 'Can', 'Öztürk', 'can.ozturk@gmail.com', '05335556677');

INSERT INTO Kitaplar VALUES (101, 'Suç ve Ceza', 1, 1, 687, 5);
INSERT INTO Kitaplar VALUES (102, 'Kürk Mantolu Madonna', 2, 2, 160, 8);
INSERT INTO Kitaplar VALUES (103, 'Türklerin Tarihi', 3, 3, 400, 3);
INSERT INTO Kitaplar VALUES (104, '1984', 4, 4, 352, 6);
INSERT INTO Kitaplar VALUES (105, 'Doğu Ekspresinde Cinayet', 5, 5, 256, 4);
INSERT INTO Kitaplar VALUES (106, 'Çalıkuşu', 6, 2, 544, 2);
INSERT INTO Kitaplar VALUES (107, 'Dönüşüm', 7, 1, 80, 10);
INSERT INTO Kitaplar VALUES (108, 'İçimizdeki Şeytan', 2, 2, 250, 5);
INSERT INTO Kitaplar VALUES (109, 'Hayvan Çiftliği', 4, 4, 150, 7);
INSERT INTO Kitaplar VALUES (110, 'İmparatorluğun En Uzun Yüzyılı', 3, 3, 350, 3);

INSERT INTO Emanetler VALUES (1, 101, 1, '2026-11-10', '2026-11-24', 0);
INSERT INTO Emanetler VALUES (2, 102, 2, '2026-11-12', '2026-11-26', 0);
INSERT INTO Emanetler VALUES (3, 104, 3, '2026-11-15', '2026-11-29', 0);
INSERT INTO Emanetler VALUES (4, 107, 4, '2026-11-18', '2026-12-02', 0);
INSERT INTO Emanetler VALUES (5, 103, 5, '2026-11-20', '2026-12-04', 1);
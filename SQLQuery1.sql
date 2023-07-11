create database NanangFutsal

-- Membuat tabel Customer
CREATE TABLE Customer (
  customer_id CHAR(10) PRIMARY KEY not null,
  nama_customer VARCHAR(50) not null,
  alamat VARCHAR(255)not null,
  no_telepon VARCHAR(13) not null
);


-- Membuat tabel Jaminan
CREATE TABLE Jaminan (
  jaminan_id CHAR(10) PRIMARY KEY not null,
  jenis_jaminan VARCHAR(4) not null,
  customer_id CHAR(10) not null,
  FOREIGN KEY (customer_id) REFERENCES Customer(customer_id)
);

-- Membuat tabel Lapangan
CREATE TABLE Lapangan (
  lapangan_id CHAR(10) PRIMARY KEY not null,
  no_lapangan CHAR(2) not null,
  jenis_lapangan VARCHAR(10) not null,
  harga_sewa_perjam MONEY not null
);

-- Membuat tabel Karyawan
CREATE TABLE Karyawan (
  karyawan_id CHAR(10) PRIMARY KEY not null,
  nama_karyawan VARCHAR(100) not null,
  jabatan VARCHAR(15) not null,
  gaji MONEY not null,
  jaminan_id CHAR(10) not null,
  lapangan_id CHAR(10) not null,
  FOREIGN KEY (jaminan_id) REFERENCES Jaminan(jaminan_id),
  FOREIGN KEY (lapangan_id) REFERENCES Lapangan(lapangan_id)
);



-- Membuat tabel StatusKaryawan
CREATE TABLE StatusKaryawan (
  status_id CHAR(10) PRIMARY KEY not null,
  jenis_karyawan VARCHAR(10) not null,
  karyawan_id CHAR(10) not null,
  FOREIGN KEY (karyawan_id) REFERENCES Karyawan(karyawan_id)
);

-- Membuat tabel Pembayaran
CREATE TABLE Pembayaran (
  id_pembayaran CHAR(10) PRIMARY KEY not null,
  jenis_pembayaran VARCHAR(5)not null,
  tanggal_pembayaran DATE not null,
  jumlah_pembayaran MONEY not null,
  lama_sewa VARCHAR(7) not null,
  customer_id CHAR(10) not null,
  karyawan_id CHAR(10) not null,
  FOREIGN KEY (customer_id) REFERENCES Customer(customer_id),
  FOREIGN KEY (karyawan_id) REFERENCES Karyawan(karyawan_id)
);

--Relasi antar tabel Costumer dan jaminan--
CREATE TABLE Memberi (
    jaminan_id char(10) not null,
    customer_id char(10) not null,
	primary key (jaminan_id, costumer_id),
	foreign key (jaminan_id) references Jaminan (jaminan_id), 
    FOREIGN KEY (customer_id) REFERENCES Customer(customer_id)
);

--Relasi antar jaminan dan Karyawan--
create table Menerima (
 karyawan_id char(10) not null,
 jaminan_id char(10) not null, 
 primary key (karyawan_id, jaminan_Id), 
 foreign key (karyawan_id) references Karyawan (karyawan_id),
 foreign key (jaminan_id) references Jaminan (jaminan_id) 
);

--relasi antar costumer dan karyawan--
create table Layani (
customer_id char(10) not null, 
karyawan_id char(10) not null,
id_pembayaran char(10) not null,
primary key (customer_id, karyawan_id, id_pembayaran), 
foreign key (customer_id) references Customer (customer_id),
foreign key (karyawan_Id) references Karyawan (karyawan_id),
foreign key (id_pembayaran) references Pembayaran (id_pembayaran)
);


-- relasi antar karyawan dan status karyawan-- 
create table Mempunyai (
karyawan_id char(10) not null, 
status_id char(10) not null, 
primary key (karyawan_id, status_id),
foreign key (karyawan_id) references Karyawan (karyawan_id),
foreign key (status_id) references StatusKaryawan (status_id)
);

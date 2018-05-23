-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 21, 2018 at 04:31 AM
-- Server version: 10.1.26-MariaDB
-- PHP Version: 7.1.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `minimarket`
--

-- --------------------------------------------------------

--
-- Table structure for table `admin`
--

CREATE TABLE `admin` (
  `Username` varchar(100) NOT NULL,
  `Nama` varchar(100) NOT NULL,
  `Password` varchar(100) NOT NULL,
  `Alamat` varchar(100) NOT NULL,
  `No_hp` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `admin`
--

INSERT INTO `admin` (`Username`, `Nama`, `Password`, `Alamat`, `No_hp`) VALUES
('A01', 'Adipati', 'ganteng', 'jakarta', '5198065487478'),
('A02', 'Vanesha', 'cantik', 'bandung', '52580032'),
('A03', 'Dhea', 'Oke', 'Jogja', '083283023');

-- --------------------------------------------------------

--
-- Table structure for table `barang`
--

CREATE TABLE `barang` (
  `id` varchar(100) NOT NULL,
  `nama_barang` varchar(100) NOT NULL,
  `harga` int(100) NOT NULL,
  `stock` int(100) NOT NULL,
  `expired_date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `barang`
--

INSERT INTO `barang` (`id`, `nama_barang`, `harga`, `stock`, `expired_date`) VALUES
('B01', 'Minyak Wangi', 12000, 255, '2018-10-25'),
('B02', 'Sabun', 10000, 65, '2018-05-31'),
('B03', 'Aqua', 2000, 125, '2018-08-14');

-- --------------------------------------------------------

--
-- Table structure for table `kasir`
--

CREATE TABLE `kasir` (
  `Username` varchar(100) NOT NULL,
  `Nama` varchar(100) NOT NULL,
  `Password` varchar(100) NOT NULL,
  `No_hp` varchar(20) NOT NULL,
  `Alamat` varchar(150) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `kasir`
--

INSERT INTO `kasir` (`Username`, `Nama`, `Password`, `No_hp`, `Alamat`) VALUES
('K01', 'Iqbale', 'dilan', '089465321743', 'Jakarta'),
('K02', 'Angela', 'oke', '089471263548', 'Medan'),
('K03', 'Regyta', 'sip', '3209302038', 'solo');

-- --------------------------------------------------------

--
-- Table structure for table `k_gudang`
--

CREATE TABLE `k_gudang` (
  `Username` varchar(100) NOT NULL,
  `Nama` varchar(100) NOT NULL,
  `Password` varchar(100) NOT NULL,
  `No_hp` varchar(20) NOT NULL,
  `Alamat` varchar(150) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `k_gudang`
--

INSERT INTO `k_gudang` (`Username`, `Nama`, `Password`, `No_hp`, `Alamat`) VALUES
('G01', 'Raisa', 'putri', '089453162785', 'Jawa Tengah'),
('G02', 'Hamish', 'daud', '084659712364', 'Bandung');

-- --------------------------------------------------------

--
-- Table structure for table `listbarang`
--

CREATE TABLE `listbarang` (
  `id` varchar(100) NOT NULL,
  `nama_brg` varchar(30) NOT NULL,
  `harga` bigint(100) NOT NULL,
  `jumlah` bigint(100) NOT NULL,
  `total` bigint(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `totaltab`
--

CREATE TABLE `totaltab` (
  `total` bigint(200) NOT NULL,
  `id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `totaltab`
--

INSERT INTO `totaltab` (`total`, `id`) VALUES
(12000, 16),
(36000, 17),
(2000, 18),
(20000, 19),
(44000, 20),
(12000, 21),
(12000, 22),
(20000, 23),
(24000, 24);

-- --------------------------------------------------------

--
-- Table structure for table `transaksi`
--

CREATE TABLE `transaksi` (
  `tanggal` date NOT NULL,
  `jumlah` int(100) NOT NULL,
  `jmlh_total` int(250) NOT NULL,
  `jam` time(3) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `transaksi`
--

INSERT INTO `transaksi` (`tanggal`, `jumlah`, `jmlh_total`, `jam`) VALUES
('2018-05-03', 8, 350000, '13:19:19.000'),
('2018-05-03', 10, 250000, '13:21:17.000'),
('2018-05-20', 1, 12000, '12:47:34.000'),
('2018-05-20', 3, 30000, '12:47:43.000'),
('2018-05-20', 5, 10000, '12:47:57.000'),
('2018-05-20', 1, 12000, '12:54:27.000'),
('2018-05-20', 3, 36000, '12:55:53.000'),
('2018-05-20', 1, 2000, '12:56:24.000'),
('2018-05-20', 4, 44000, '13:18:42.000'),
('2018-05-20', 1, 12000, '13:20:54.000'),
('2018-05-20', 1, 12000, '13:26:27.000'),
('2018-05-20', 2, 20000, '13:26:47.000'),
('2018-05-20', 2, 24000, '13:27:29.000');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `admin`
--
ALTER TABLE `admin`
  ADD PRIMARY KEY (`Username`);

--
-- Indexes for table `barang`
--
ALTER TABLE `barang`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `kasir`
--
ALTER TABLE `kasir`
  ADD PRIMARY KEY (`Username`);

--
-- Indexes for table `k_gudang`
--
ALTER TABLE `k_gudang`
  ADD PRIMARY KEY (`Username`);

--
-- Indexes for table `listbarang`
--
ALTER TABLE `listbarang`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `totaltab`
--
ALTER TABLE `totaltab`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `totaltab`
--
ALTER TABLE `totaltab`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=25;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `listbarang`
--
ALTER TABLE `listbarang`
  ADD CONSTRAINT `listbarang_ibfk_1` FOREIGN KEY (`id`) REFERENCES `barang` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

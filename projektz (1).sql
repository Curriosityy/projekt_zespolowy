-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: May 25, 2018 at 07:47 PM
-- Server version: 10.1.19-MariaDB
-- PHP Version: 5.6.28

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `projektz`
--

-- --------------------------------------------------------

--
-- Table structure for table `klient`
--

CREATE TABLE `klient` (
  `id` int(11) NOT NULL,
  `imie` varchar(30) NOT NULL,
  `nazwisko` varchar(30) NOT NULL,
  `tel` int(9) NOT NULL COMMENT 'numer telefonu',
  `ulica` varchar(50) NOT NULL,
  `nr_domu` int(11) NOT NULL,
  `nr_lokalu` int(11) NOT NULL,
  `miejscowosc` varchar(40) NOT NULL,
  `kod` int(11) NOT NULL COMMENT 'kod pocztowy'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `pracownik`
--

CREATE TABLE `pracownik` (
  `id` int(11) NOT NULL,
  `login` varchar(25) NOT NULL,
  `haslo` char(64) NOT NULL,
  `uprawnienia` int(1) NOT NULL,
  `pensja` decimal(15,2) NOT NULL,
  `premia` decimal(15,2) NOT NULL,
  `ulica` varchar(50) NOT NULL,
  `nr_domu` int(11) NOT NULL,
  `nr_lokalu` int(11) NOT NULL,
  `miejscowosc` varchar(50) NOT NULL,
  `kod` int(9) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `producent`
--

CREATE TABLE `producent` (
  `id` int(11) NOT NULL,
  `nazwa` varchar(50) NOT NULL,
  `email` varchar(40) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `produkt`
--

CREATE TABLE `produkt` (
  `id` int(11) NOT NULL,
  `nazwa` varchar(50) NOT NULL COMMENT 'nazwa produktu',
  `opis` text NOT NULL COMMENT 'dokładny opis produktu',
  `ilosc` int(11) NOT NULL COMMENT 'ilość dostępnych produktów w magazynie',
  `cena` decimal(10,2) NOT NULL COMMENT 'cena produktu ',
  `id_producenta` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `raport`
--

CREATE TABLE `raport` (
  `id` int(11) NOT NULL,
  `data` date NOT NULL COMMENT 'data raportu',
  `koszt` decimal(10,2) NOT NULL COMMENT 'zysk z przeprowadzonych zgłoszen w ciągu dnia',
  `ilosc_napraw` int(11) NOT NULL,
  `opis` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `raport_zgloszenie`
--

CREATE TABLE `raport_zgloszenie` (
  `id` int(11) NOT NULL,
  `id_raportu` int(11) NOT NULL,
  `id_zgloszenia` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `wiadomosc`
--

CREATE TABLE `wiadomosc` (
  `id` int(11) NOT NULL,
  `id_prac1` int(11) NOT NULL COMMENT 'id pracownika wysylajacego wiadomosc',
  `id_prac2` int(11) NOT NULL COMMENT 'id pracownika odbierajacego wiadomosc',
  `tresc` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `zgloszenie`
--

CREATE TABLE `zgloszenie` (
  `id` int(11) NOT NULL,
  `id_prac` int(11) NOT NULL,
  `id_klienta` int(11) NOT NULL,
  `koszt` decimal(10,2) DEFAULT NULL COMMENT 'koszt przeprowadzonej naprawy',
  `opis` text NOT NULL,
  `data1` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `data2` datetime NOT NULL,
  `status` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `zgloszenie_produkt`
--

CREATE TABLE `zgloszenie_produkt` (
  `id` int(11) NOT NULL,
  `id_zgloszenia` int(11) NOT NULL,
  `id_produktu` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `klient`
--
ALTER TABLE `klient`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `pracownik`
--
ALTER TABLE `pracownik`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `login` (`login`);

--
-- Indexes for table `producent`
--
ALTER TABLE `producent`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `email` (`email`);

--
-- Indexes for table `produkt`
--
ALTER TABLE `produkt`
  ADD PRIMARY KEY (`id`),
  ADD KEY `id_producenta` (`id_producenta`);

--
-- Indexes for table `raport`
--
ALTER TABLE `raport`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `raport_zgloszenie`
--
ALTER TABLE `raport_zgloszenie`
  ADD PRIMARY KEY (`id`),
  ADD KEY `id_raportu` (`id_raportu`),
  ADD KEY `id_zgloszenia` (`id_zgloszenia`);

--
-- Indexes for table `wiadomosc`
--
ALTER TABLE `wiadomosc`
  ADD PRIMARY KEY (`id`),
  ADD KEY `id_prac2` (`id_prac2`),
  ADD KEY `id_prac1` (`id_prac1`);

--
-- Indexes for table `zgloszenie`
--
ALTER TABLE `zgloszenie`
  ADD PRIMARY KEY (`id`),
  ADD KEY `id_prac` (`id_prac`),
  ADD KEY `id_klienta` (`id_klienta`);

--
-- Indexes for table `zgloszenie_produkt`
--
ALTER TABLE `zgloszenie_produkt`
  ADD PRIMARY KEY (`id`),
  ADD KEY `id_produktu` (`id_produktu`),
  ADD KEY `id_zgloszenia` (`id_zgloszenia`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `klient`
--
ALTER TABLE `klient`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `pracownik`
--
ALTER TABLE `pracownik`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `producent`
--
ALTER TABLE `producent`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `raport`
--
ALTER TABLE `raport`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `raport_zgloszenie`
--
ALTER TABLE `raport_zgloszenie`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `wiadomosc`
--
ALTER TABLE `wiadomosc`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `zgloszenie`
--
ALTER TABLE `zgloszenie`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `zgloszenie_produkt`
--
ALTER TABLE `zgloszenie_produkt`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- Constraints for dumped tables
--

--
-- Constraints for table `produkt`
--
ALTER TABLE `produkt`
  ADD CONSTRAINT `producentprodukt` FOREIGN KEY (`id_producenta`) REFERENCES `producent` (`id`);

--
-- Constraints for table `raport_zgloszenie`
--
ALTER TABLE `raport_zgloszenie`
  ADD CONSTRAINT `raportid` FOREIGN KEY (`id_raportu`) REFERENCES `raport` (`id`),
  ADD CONSTRAINT `zgloszenieid` FOREIGN KEY (`id_zgloszenia`) REFERENCES `zgloszenie` (`id`);

--
-- Constraints for table `wiadomosc`
--
ALTER TABLE `wiadomosc`
  ADD CONSTRAINT `prac1wiadomosc` FOREIGN KEY (`id_prac1`) REFERENCES `pracownik` (`id`),
  ADD CONSTRAINT `prac2wiadomosc` FOREIGN KEY (`id_prac2`) REFERENCES `pracownik` (`id`);

--
-- Constraints for table `zgloszenie`
--
ALTER TABLE `zgloszenie`
  ADD CONSTRAINT `zgloszenieklient` FOREIGN KEY (`id_klienta`) REFERENCES `klient` (`id`),
  ADD CONSTRAINT `zgloszeniepracownik` FOREIGN KEY (`id_prac`) REFERENCES `pracownik` (`id`);

--
-- Constraints for table `zgloszenie_produkt`
--
ALTER TABLE `zgloszenie_produkt`
  ADD CONSTRAINT `produktid` FOREIGN KEY (`id_produktu`) REFERENCES `produkt` (`id`),
  ADD CONSTRAINT `zgloszeniaid` FOREIGN KEY (`id_zgloszenia`) REFERENCES `zgloszenie` (`id`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Czas generowania: 03 Cze 2018, 14:14
-- Wersja serwera: 10.1.28-MariaDB
-- Wersja PHP: 7.1.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Baza danych: `projekt`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `klient`
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

--
-- Zrzut danych tabeli `klient`
--

INSERT INTO `klient` (`id`, `imie`, `nazwisko`, `tel`, `ulica`, `nr_domu`, `nr_lokalu`, `miejscowosc`, `kod`) VALUES
(1, 'sdads', 'asdad', 111111112, 'sadadadad', 12, 21, 'sdadsd', 11111),
(2, 'sdads', 'asdad', 111111113, 'sadadadad', 12, 21, 'sdadsd', 11111),
(3, 'Damian', 'Bajno', 111111114, 'Lesna', 111, 12, 'Miastkowo', 21377),
(4, 'dddasd', 'adsdasd', 0, 'dasdsad', 0, 0, 'dasd', 0),
(5, 'Basia', 'Basia', 412444256, 'alll', 122, 12, 'Bialystok', 15233);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `pracownik`
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

--
-- Zrzut danych tabeli `pracownik`
--

INSERT INTO `pracownik` (`id`, `login`, `haslo`, `uprawnienia`, `pensja`, `premia`, `ulica`, `nr_domu`, `nr_lokalu`, `miejscowosc`, `kod`) VALUES
(1, 'szef', 'szef', 3, '100000.00', '0.00', 'dasdasd', 21, 12, 'sdasdad', 12345),
(2, 'sekretarka', 'sekretarka', 2, '1233.00', '0.00', 'qdqwdw', 21, 12, 'dwqdwqd', 12312),
(3, 'admin', 'admin', 0, '11111.00', '0.00', 'dsadsd', 21, 12, 'dasdadasd', 12312),
(4, 'serwisant', 'serwisant', 1, '213123.00', '0.00', 'wqwdqd', 12, 321, 'sddadadadasd', 12131),
(5, 'serw1', 'serw1', 1, '1000.00', '0.00', 'ddasdsd', 12, 1, 'dasdsadad', 11111),
(6, 'serw2', 'serw2', 1, '1001.00', '0.00', '2000', 11, 12, 'Gdynia', 11111),
(7, 'serw3', 'serw3', 1, '200.00', '0.00', 'Duzego Bicka', 11, 11, 'Wadowice', 73112),
(8, 'serw4', 'serw4', 1, '2000.00', '0.00', 'Smieszków', 3, 4, 'sloneczna', 12345);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `producent`
--

CREATE TABLE `producent` (
  `id` int(11) NOT NULL,
  `nazwa` varchar(50) NOT NULL,
  `email` varchar(40) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Zrzut danych tabeli `producent`
--

INSERT INTO `producent` (`id`, `nazwa`, `email`) VALUES
(1, 'GiGABYTE', 'GiGABYTE@gmail.com'),
(2, 'NVidia', 'NVidia@o2,pl');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `produkt`
--

CREATE TABLE `produkt` (
  `id` int(11) NOT NULL,
  `nazwa` varchar(50) NOT NULL COMMENT 'nazwa produktu',
  `opis` text NOT NULL COMMENT 'dokładny opis produktu',
  `ilosc` int(11) NOT NULL COMMENT 'ilość dostępnych produktów w magazynie',
  `cena` decimal(10,2) NOT NULL COMMENT 'cena produktu ',
  `id_producenta` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Zrzut danych tabeli `produkt`
--

INSERT INTO `produkt` (`id`, `nazwa`, `opis`, `ilosc`, `cena`, `id_producenta`) VALUES
(0, 'super cz???', 'Panie lepszej nie znajdziesz', 0, '1000.00', 1),
(2, 'kozaczki', 'raz dwa tszy', 3, '102.00', 2),
(10, 'super czesc', 'Panie lepszej nie znajdziesz', 0, '1000.00', 1);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `raport`
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
-- Struktura tabeli dla tabeli `raport_zgloszenie`
--

CREATE TABLE `raport_zgloszenie` (
  `id` int(11) NOT NULL,
  `id_raportu` int(11) NOT NULL,
  `id_zgloszenia` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `wiadomosc`
--

CREATE TABLE `wiadomosc` (
  `id` int(11) NOT NULL,
  `id_prac1` int(11) NOT NULL COMMENT 'id pracownika wysylajacego wiadomosc',
  `id_prac2` int(11) NOT NULL COMMENT 'id pracownika odbierajacego wiadomosc',
  `tresc` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Zrzut danych tabeli `wiadomosc`
--

INSERT INTO `wiadomosc` (`id`, `id_prac1`, `id_prac2`, `tresc`) VALUES
(1, 2, 1, 'Kocham Pana'),
(2, 4, 1, 'Najlepszy szef na swiecie');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `zgloszenie`
--

CREATE TABLE `zgloszenie` (
  `id` int(11) NOT NULL,
  `id_prac` int(11) DEFAULT NULL,
  `id_klienta` int(11) NOT NULL,
  `koszt` decimal(10,2) DEFAULT NULL COMMENT 'koszt przeprowadzonej naprawy',
  `opis` text NOT NULL,
  `data1` datetime DEFAULT CURRENT_TIMESTAMP,
  `data2` datetime DEFAULT NULL,
  `status` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Zrzut danych tabeli `zgloszenie`
--

INSERT INTO `zgloszenie` (`id`, `id_prac`, `id_klienta`, `koszt`, `opis`, `data1`, `data2`, `status`) VALUES
(3, NULL, 3, NULL, 'jjjj', '2018-05-28 23:37:15', NULL, 0),
(4, NULL, 1, NULL, 'ocham', '2018-05-29 09:44:29', NULL, 0);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `zgloszenie_produkt`
--

CREATE TABLE `zgloszenie_produkt` (
  `id` int(11) NOT NULL,
  `id_zgloszenia` int(11) NOT NULL,
  `id_produktu` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Indeksy dla zrzutów tabel
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
-- AUTO_INCREMENT dla tabeli `klient`
--
ALTER TABLE `klient`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT dla tabeli `pracownik`
--
ALTER TABLE `pracownik`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT dla tabeli `producent`
--
ALTER TABLE `producent`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT dla tabeli `raport`
--
ALTER TABLE `raport`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT dla tabeli `raport_zgloszenie`
--
ALTER TABLE `raport_zgloszenie`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT dla tabeli `wiadomosc`
--
ALTER TABLE `wiadomosc`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT dla tabeli `zgloszenie`
--
ALTER TABLE `zgloszenie`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT dla tabeli `zgloszenie_produkt`
--
ALTER TABLE `zgloszenie_produkt`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Ograniczenia dla zrzutów tabel
--

--
-- Ograniczenia dla tabeli `produkt`
--
ALTER TABLE `produkt`
  ADD CONSTRAINT `producentprodukt` FOREIGN KEY (`id_producenta`) REFERENCES `producent` (`id`);

--
-- Ograniczenia dla tabeli `raport_zgloszenie`
--
ALTER TABLE `raport_zgloszenie`
  ADD CONSTRAINT `raportid` FOREIGN KEY (`id_raportu`) REFERENCES `raport` (`id`),
  ADD CONSTRAINT `zgloszenieid` FOREIGN KEY (`id_zgloszenia`) REFERENCES `zgloszenie` (`id`);

--
-- Ograniczenia dla tabeli `wiadomosc`
--
ALTER TABLE `wiadomosc`
  ADD CONSTRAINT `prac1wiadomosc` FOREIGN KEY (`id_prac1`) REFERENCES `pracownik` (`id`),
  ADD CONSTRAINT `prac2wiadomosc` FOREIGN KEY (`id_prac2`) REFERENCES `pracownik` (`id`);

--
-- Ograniczenia dla tabeli `zgloszenie`
--
ALTER TABLE `zgloszenie`
  ADD CONSTRAINT `zgloszenieklient` FOREIGN KEY (`id_klienta`) REFERENCES `klient` (`id`),
  ADD CONSTRAINT `zgloszeniepracownik` FOREIGN KEY (`id_prac`) REFERENCES `pracownik` (`id`);

--
-- Ograniczenia dla tabeli `zgloszenie_produkt`
--
ALTER TABLE `zgloszenie_produkt`
  ADD CONSTRAINT `produktid` FOREIGN KEY (`id_produktu`) REFERENCES `produkt` (`id`),
  ADD CONSTRAINT `zgloszeniaid` FOREIGN KEY (`id_zgloszenia`) REFERENCES `zgloszenie` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: 03-Jan-2020 às 23:02
-- Versão do servidor: 8.0.13-4
-- versão do PHP: 7.2.24-0ubuntu0.18.04.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `XgXq4vJX83`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `Brands`
--

CREATE TABLE `Brands` (
  `id` bigint(20) NOT NULL,
  `name` varchar(500) COLLATE utf8_unicode_ci NOT NULL,
  `createdAt` datetime NOT NULL,
  `updatedAt` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Extraindo dados da tabela `Brands`
--

INSERT INTO `Brands` (`id`, `name`, `createdAt`, `updatedAt`) VALUES
(1, 'Adidas', '2020-01-03 15:15:53', '2020-01-03 15:15:53'),
(2, 'Samsung', '2020-01-03 15:16:10', '2020-01-03 15:16:10'),
(3, 'LG Eletronics', '2020-01-03 15:16:33', '2020-01-03 15:16:33'),
(4, 'LG Eletronics', '2020-01-03 22:56:27', '2020-01-03 22:56:27');

-- --------------------------------------------------------

--
-- Estrutura da tabela `Customers`
--

CREATE TABLE `Customers` (
  `id` bigint(20) NOT NULL,
  `name` varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `address` varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `email` varchar(300) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `createdAt` datetime NOT NULL,
  `updatedAt` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `Customers`
--

INSERT INTO `Customers` (`id`, `name`, `address`, `email`, `createdAt`, `updatedAt`) VALUES
(1, 'Juliano Oliveira', 'São Paulo', 'jul.oliveira@gmail.com', '2020-01-02 00:00:00', '2020-01-02 00:00:00'),
(2, 'Jose Silva', 'Rio de Janeiro', 'rj@gmail.com', '2020-01-02 00:00:00', '2020-01-02 00:00:00'),
(3, 'Gabriel Ferreira', 'Natal', 'rn@gmail.com', '2020-01-02 00:00:00', '2020-01-02 00:00:00'),
(4, 'Felipe Nogueira', 'Guarujá', 'sp@gmail.com', '2020-01-02 00:00:00', '2020-01-02 00:00:00'),
(5, 'Julia Rocha', 'Porto Alegre', 'rs@gmail.com', '2020-01-02 00:00:00', '2020-01-02 00:00:00'),
(6, 'Nome do Cliente', 'Meu endereço', 'email@email.com', '2020-01-02 20:48:18', '2020-01-02 20:48:18'),
(7, 'Nome do Cliente', 'Meu endereço', 'emaail@email.com', '2020-01-02 20:50:46', '2020-01-02 20:50:46'),
(9, 'Carol Ferlin', 'Vila Andrade', 'esmaail@email.com', '2020-01-03 14:39:48', '2020-01-03 15:08:11');

-- --------------------------------------------------------

--
-- Estrutura da tabela `Customers_FavoritiesProducts`
--

CREATE TABLE `Customers_FavoritiesProducts` (
  `customer_id` bigint(20) NOT NULL,
  `product_id` bigint(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Extraindo dados da tabela `Customers_FavoritiesProducts`
--

INSERT INTO `Customers_FavoritiesProducts` (`customer_id`, `product_id`) VALUES
(1, 1),
(1, 2);

-- --------------------------------------------------------

--
-- Estrutura da tabela `Products`
--

CREATE TABLE `Products` (
  `id` bigint(20) NOT NULL,
  `title` varchar(500) COLLATE utf8_unicode_ci NOT NULL,
  `price` double NOT NULL,
  `brand_id` bigint(20) NOT NULL,
  `image` varchar(500) COLLATE utf8_unicode_ci NOT NULL,
  `reviewScore` double NOT NULL,
  `createdAt` datetime NOT NULL,
  `updatedAt` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Extraindo dados da tabela `Products`
--

INSERT INTO `Products` (`id`, `title`, `price`, `brand_id`, `image`, `reviewScore`, `createdAt`, `updatedAt`) VALUES
(1, 'Tênis XYZ', 123.12, 1, 'http://', 3.4478000000000004, '2020-01-03 15:57:40', '2020-01-03 15:57:40'),
(2, 'Galaxy S10', 3423.12, 2, 'http://', 2.915, '2020-01-03 15:58:21', '2020-01-03 15:58:21'),
(3, 'Galaxy A2', 323.12, 2, 'http://', 0, '2020-01-03 21:47:46', '2020-01-03 21:47:46'),
(4, 'Galaxy A3', 423.12, 2, 'http://', 0, '2020-01-03 21:47:57', '2020-01-03 21:47:57'),
(5, 'Galaxy A4', 523.12, 2, 'http://', 0, '2020-01-03 21:48:03', '2020-01-03 21:48:03'),
(6, 'Galaxy A6', 623.12, 2, 'http://', 0, '2020-01-03 21:48:10', '2020-01-03 21:48:10'),
(7, 'Galaxy A7', 723.12, 2, 'http://', 0, '2020-01-03 21:48:18', '2020-01-03 21:48:18'),
(8, 'Galaxy A8', 923.12, 2, 'http://', 0, '2020-01-03 21:48:24', '2020-01-03 21:48:24'),
(9, 'Galaxy A9', 1023.12, 2, 'http://', 0, '2020-01-03 21:48:31', '2020-01-03 21:48:31'),
(10, 'Galaxy XA', 2023.12, 2, 'http://', 0, '2020-01-03 21:48:53', '2020-01-03 21:48:53'),
(11, 'Galaxy XB', 2023.12, 2, 'http://', 0, '2020-01-03 21:48:58', '2020-01-03 21:48:58'),
(12, 'Galaxy XC', 2323.12, 2, 'http://', 0, '2020-01-03 21:49:05', '2020-01-03 21:49:05');

-- --------------------------------------------------------

--
-- Estrutura da tabela `Reviews`
--

CREATE TABLE `Reviews` (
  `id` bigint(20) NOT NULL,
  `customer_id` bigint(20) NOT NULL,
  `product_id` bigint(20) NOT NULL,
  `score` double NOT NULL,
  `comment` text COLLATE utf8_unicode_ci NOT NULL,
  `createdAt` datetime NOT NULL,
  `updatedAt` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Extraindo dados da tabela `Reviews`
--

INSERT INTO `Reviews` (`id`, `customer_id`, `product_id`, `score`, `comment`, `createdAt`, `updatedAt`) VALUES
(1, 1, 1, 3, 'Um comentário', '2020-01-03 16:35:43', '2020-01-03 16:35:43'),
(2, 1, 1, 3, 'Um comentário', '2020-01-03 16:36:04', '2020-01-03 16:36:04'),
(3, 1, 1, 1, 'Um comentário', '2020-01-03 16:40:47', '2020-01-03 16:40:47'),
(4, 1, 1, 5, 'Um comentário', '2020-01-03 16:43:35', '2020-01-03 16:43:35'),
(5, 1, 1, 4.1001, 'Um comentário', '2020-01-03 16:43:52', '2020-01-03 16:43:52'),
(6, 1, 1, 4.1001, 'Um comentário', '2020-01-03 16:52:18', '2020-01-03 16:52:18'),
(7, 1, 1, 2.3, 'Um comentário', '2020-01-03 16:59:43', '2020-01-03 16:59:43'),
(8, 1, 2, 2.3, 'Um comentário', '2020-01-03 17:06:49', '2020-01-03 17:06:49'),
(9, 1, 2, 3.53, 'Um comentário', '2020-01-03 17:07:03', '2020-01-03 17:07:03'),
(10, 1, 1, 3.53, 'Um comentário', '2020-01-03 17:07:23', '2020-01-03 17:07:23'),
(11, 1, 1, 5, 'Um comentário', '2020-01-03 17:07:37', '2020-01-03 17:07:37');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `Brands`
--
ALTER TABLE `Brands`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `Customers`
--
ALTER TABLE `Customers`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `Customers_FavoritiesProducts`
--
ALTER TABLE `Customers_FavoritiesProducts`
  ADD UNIQUE KEY `customer_id` (`customer_id`,`product_id`),
  ADD KEY `product` (`product_id`);

--
-- Indexes for table `Products`
--
ALTER TABLE `Products`
  ADD PRIMARY KEY (`id`),
  ADD KEY `product_brand` (`brand_id`);

--
-- Indexes for table `Reviews`
--
ALTER TABLE `Reviews`
  ADD PRIMARY KEY (`id`),
  ADD KEY `review_product` (`product_id`),
  ADD KEY `review_customer` (`customer_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `Brands`
--
ALTER TABLE `Brands`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `Customers`
--
ALTER TABLE `Customers`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `Products`
--
ALTER TABLE `Products`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT for table `Reviews`
--
ALTER TABLE `Reviews`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- Constraints for dumped tables
--

--
-- Limitadores para a tabela `Customers_FavoritiesProducts`
--
ALTER TABLE `Customers_FavoritiesProducts`
  ADD CONSTRAINT `customer` FOREIGN KEY (`customer_id`) REFERENCES `Customers` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  ADD CONSTRAINT `product` FOREIGN KEY (`product_id`) REFERENCES `Products` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT;

--
-- Limitadores para a tabela `Products`
--
ALTER TABLE `Products`
  ADD CONSTRAINT `product_brand` FOREIGN KEY (`brand_id`) REFERENCES `Brands` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT;

--
-- Limitadores para a tabela `Reviews`
--
ALTER TABLE `Reviews`
  ADD CONSTRAINT `review_customer` FOREIGN KEY (`customer_id`) REFERENCES `Customers` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  ADD CONSTRAINT `review_product` FOREIGN KEY (`product_id`) REFERENCES `Products` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

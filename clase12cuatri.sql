-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 17-08-2023 a las 17:07:06
-- Versión del servidor: 10.4.22-MariaDB
-- Versión de PHP: 7.4.27

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `clase12cuatri`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `detallesfacturas`
--

CREATE TABLE `detallesfacturas` (
  `id` int(11) NOT NULL,
  `producto` text NOT NULL,
  `costbruto` double(10,2) NOT NULL,
  `cantidad` int(11) NOT NULL,
  `id_factura` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `detallesfacturas`
--

INSERT INTO `detallesfacturas` (`id`, `producto`, `costbruto`, `cantidad`, `id_factura`) VALUES
(1, 'Cafe', 72.25, 1, 1),
(2, 'Shampoo', 72.25, 1, 1),
(3, 'Caramelitos', 30.25, 2, 2),
(4, 'Yerba', 60.50, 1, 2);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `facturas`
--

CREATE TABLE `facturas` (
  `id` int(11) NOT NULL,
  `tipo` char(1) NOT NULL,
  `fechaemision` date NOT NULL DEFAULT current_timestamp(),
  `totbruto` double(10,2) NOT NULL,
  `totneto` double(10,2) NOT NULL,
  `receptor` text NOT NULL,
  `emisor` text NOT NULL DEFAULT 'PelucaInc'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `facturas`
--

INSERT INTO `facturas` (`id`, `tipo`, `fechaemision`, `totbruto`, `totneto`, `receptor`, `emisor`) VALUES
(1, 'A', '2023-08-17', 145.50, 120.00, 'Marianito Proveedor', 'PelucaInc'),
(2, 'B', '2023-08-17', 121.00, 100.00, 'El pichichi', 'PelucaInc');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `detallesfacturas`
--
ALTER TABLE `detallesfacturas`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `facturas`
--
ALTER TABLE `facturas`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `detallesfacturas`
--
ALTER TABLE `detallesfacturas`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT de la tabla `facturas`
--
ALTER TABLE `facturas`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

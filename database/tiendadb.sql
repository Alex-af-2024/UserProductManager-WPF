-- MySQL dump 10.13  Distrib 8.0.41, for Win64 (x86_64)
--
-- Host: localhost    Database: tiendadb
-- ------------------------------------------------------
-- Server version	9.2.0

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `boleta`
--

DROP TABLE IF EXISTS `boleta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `boleta` (
  `id` int NOT NULL AUTO_INCREMENT,
  `fecha` datetime NOT NULL,
  `total` decimal(10,2) NOT NULL,
  `id_usuario` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `id_usuario` (`id_usuario`),
  CONSTRAINT `boleta_ibfk_1` FOREIGN KEY (`id_usuario`) REFERENCES `usuario` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `boleta`
--

LOCK TABLES `boleta` WRITE;
/*!40000 ALTER TABLE `boleta` DISABLE KEYS */;
INSERT INTO `boleta` VALUES (1,'2025-04-01 10:15:00',139.94,1),(2,'2025-04-02 12:30:00',119.97,2),(3,'2025-04-03 14:45:00',79.96,3),(4,'2025-04-04 16:00:00',199.95,4),(5,'2025-04-05 17:30:00',69.95,5),(6,'2025-04-06 18:00:00',139.94,6),(7,'2025-04-07 09:00:00',109.94,7),(8,'2025-04-08 11:15:00',149.94,8),(9,'2025-04-09 13:30:00',119.94,9),(10,'2025-04-10 15:45:00',179.94,10);
/*!40000 ALTER TABLE `boleta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `detalle_boleta`
--

DROP TABLE IF EXISTS `detalle_boleta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `detalle_boleta` (
  `id` int NOT NULL AUTO_INCREMENT,
  `id_producto` int DEFAULT NULL,
  `id_boleta` int DEFAULT NULL,
  `cantidad` int NOT NULL,
  `precio` decimal(10,2) NOT NULL,
  `total` decimal(10,2) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id_producto` (`id_producto`),
  KEY `id_boleta` (`id_boleta`),
  CONSTRAINT `detalle_boleta_ibfk_1` FOREIGN KEY (`id_producto`) REFERENCES `producto` (`codigo`),
  CONSTRAINT `detalle_boleta_ibfk_2` FOREIGN KEY (`id_boleta`) REFERENCES `boleta` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=33 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `detalle_boleta`
--

LOCK TABLES `detalle_boleta` WRITE;
/*!40000 ALTER TABLE `detalle_boleta` DISABLE KEYS */;
INSERT INTO `detalle_boleta` VALUES (1,101,1,2,15.99,31.98),(2,102,1,1,29.99,29.99),(3,105,1,1,12.99,12.99),(4,109,1,1,5.99,5.99),(5,103,2,1,49.99,49.99),(6,106,2,1,39.99,39.99),(7,109,2,1,5.99,5.99),(8,104,3,1,89.99,89.99),(9,109,3,2,5.99,11.98),(10,107,4,2,19.99,39.98),(11,110,4,1,34.99,34.99),(12,103,4,1,49.99,49.99),(13,101,5,1,15.99,15.99),(14,106,5,1,39.99,39.99),(15,109,5,1,5.99,5.99),(16,102,6,1,29.99,29.99),(17,105,6,2,12.99,25.98),(18,107,6,1,19.99,19.99),(19,103,7,1,49.99,49.99),(20,108,7,2,9.99,19.98),(21,110,7,1,34.99,34.99),(22,109,8,2,5.99,11.98),(23,101,8,1,15.99,15.99),(24,106,8,1,39.99,39.99),(25,105,9,1,12.99,12.99),(26,108,9,1,9.99,9.99),(27,107,9,1,19.99,19.99),(28,110,9,1,34.99,34.99),(29,102,10,2,29.99,59.98),(30,103,10,1,49.99,49.99),(31,106,10,1,39.99,39.99),(32,110,10,1,34.99,34.99);
/*!40000 ALTER TABLE `detalle_boleta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `producto`
--

DROP TABLE IF EXISTS `producto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `producto` (
  `codigo` int NOT NULL,
  `nombre` varchar(255) NOT NULL,
  `precio` decimal(10,2) NOT NULL,
  `stock` int NOT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `producto`
--

LOCK TABLES `producto` WRITE;
/*!40000 ALTER TABLE `producto` DISABLE KEYS */;
INSERT INTO `producto` VALUES (101,'Camiseta',15.99,50),(102,'Pantalón',29.99,30),(103,'Zapatos',49.99,20),(104,'Chaqueta',89.99,15),(105,'Gorra',12.99,60),(106,'Mochila',39.99,25),(107,'Cinturón',19.99,40),(108,'Bufanda',9.99,80),(109,'Guantes',5.99,100),(110,'Sudadera',34.99,35),(111,'Calcetines',10.98,25),(112,'Pecheron',1000.00,25);
/*!40000 ALTER TABLE `producto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuario`
--

DROP TABLE IF EXISTS `usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuario` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(255) NOT NULL,
  `username` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `username` (`username`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario`
--

LOCK TABLES `usuario` WRITE;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` VALUES (1,'Juan Pocoyo','juanperez','ronroco1'),(2,'Anita Del barrio','anagarcia','choca1'),(3,'Carlos López','carloslopez','password123'),(4,'Marta Fernández','martafernandez','password123'),(5,'Pedro Martínez','pedromartinez','password123'),(6,'Lucía Rodríguez','luciarodriguez','password123'),(7,'Sergio González','sergiogonzalez','password123'),(8,'Elena Sánchez','elenasanchez','password123'),(9,'Raúl Gómez','raulgomez','password123'),(10,'Carmen Díaz','carmeindiaz','password123'),(11,'Alex','afranco','123456');
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-04-14 22:03:52

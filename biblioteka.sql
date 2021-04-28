/*
Navicat MySQL Data Transfer

Source Server         : Konekcija
Source Server Version : 50018
Source Host           : localhost:3306
Source Database       : biblioteka

Target Server Type    : MYSQL
Target Server Version : 50018
File Encoding         : 65001

Date: 2021-04-28 12:25:08
*/

SET FOREIGN_KEY_CHECKS=0;
-- ----------------------------
-- Table structure for `bi_clanovi`
-- ----------------------------
DROP TABLE IF EXISTS `bi_clanovi`;
CREATE TABLE `bi_clanovi` (
  `clan_ID` int(11) NOT NULL auto_increment,
  `clan_broj` varchar(10) NOT NULL,
  `clan_ime` varchar(50) NOT NULL,
  `clan_prezime` varchar(50) NOT NULL,
  `clan_email` varchar(50) default NULL,
  `clan_adresa` varchar(50) default NULL,
  `clan_telefon` varchar(50) default NULL,
  PRIMARY KEY  (`clan_ID`),
  UNIQUE KEY `clan_broj` (`clan_broj`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of bi_clanovi
-- ----------------------------
INSERT INTO `bi_clanovi` VALUES ('1', 'C001', 'Faruk', 'Fazlinovic', 'faruk@mail.com', 'Titova BB', '060423867');
INSERT INTO `bi_clanovi` VALUES ('2', 'C002', 'Samir', 'Jakupovic', 'samir@mail.com', 'Džemala Bijedica BB', '12333114');

-- ----------------------------
-- Table structure for `bi_dobavljaci`
-- ----------------------------
DROP TABLE IF EXISTS `bi_dobavljaci`;
CREATE TABLE `bi_dobavljaci` (
  `dobavljac_ID` int(11) NOT NULL auto_increment,
  `dobavljac_ime` varchar(30) NOT NULL,
  `adresa_dobavljac` varchar(50) default NULL,
  `dobavljac_telefon` bigint(10) NOT NULL,
  `email_dobavljac` varchar(15) NOT NULL,
  PRIMARY KEY  (`dobavljac_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of bi_dobavljaci
-- ----------------------------

-- ----------------------------
-- Table structure for `bi_knjige`
-- ----------------------------
DROP TABLE IF EXISTS `bi_knjige`;
CREATE TABLE `bi_knjige` (
  `knjiga_kod` int(11) NOT NULL auto_increment,
  `knjiga_naslov` varchar(50) NOT NULL,
  `knjiga_autor` varchar(30) NOT NULL,
  `knjiga_broj_stranica` int(11) NOT NULL,
  `knjiga_izdavac` varchar(30) NOT NULL,
  `cijena` decimal(8,2) NOT NULL,
  `dobavljac_ID` int(11) default NULL,
  `kolicina_knjiga` int(11) NOT NULL,
  PRIMARY KEY  (`knjiga_kod`),
  UNIQUE KEY `knjiga_naslov` (`knjiga_naslov`),
  KEY `cts_dobavljac` (`dobavljac_ID`),
  CONSTRAINT `cts_dobavljac` FOREIGN KEY (`dobavljac_ID`) REFERENCES `bi_dobavljaci` (`dobavljac_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of bi_knjige
-- ----------------------------
INSERT INTO `bi_knjige` VALUES ('1', 'Derviš i smrt', 'Meša Selimovic', '200', 'Svjetlost', '25.00', null, '18');
INSERT INTO `bi_knjige` VALUES ('5', 'Ana Karenjina', 'Lav Tolstoj', '800', 'Svjetlost', '50.00', null, '36');
INSERT INTO `bi_knjige` VALUES ('6', 'Slika Doriana Greja', 'Oscar Wilde', '161', 'Svjetlost', '35.00', null, '14');

-- ----------------------------
-- Table structure for `bi_korisnik`
-- ----------------------------
DROP TABLE IF EXISTS `bi_korisnik`;
CREATE TABLE `bi_korisnik` (
  `Korisnik_ID` int(11) NOT NULL auto_increment,
  `imeKor` varchar(50) default NULL,
  `prezimeKor` varchar(50) default NULL,
  `korisnickoIme` varchar(20) default NULL,
  `password` varchar(20) default NULL,
  `emailKor` varchar(50) default NULL,
  `telefonKor` varchar(50) default NULL,
  `status_login` int(11) NOT NULL default '0',
  PRIMARY KEY  (`Korisnik_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of bi_korisnik
-- ----------------------------
INSERT INTO `bi_korisnik` VALUES ('1', 'Amil', 'Ljaljak', 'amil', '1234', 'amil@mail.com', '062556126', '0');

-- ----------------------------
-- Table structure for `bi_posudbe`
-- ----------------------------
DROP TABLE IF EXISTS `bi_posudbe`;
CREATE TABLE `bi_posudbe` (
  `posudba_ID` int(11) NOT NULL auto_increment,
  `clan_ID` int(11) NOT NULL,
  `knjiga_kod` int(11) NOT NULL,
  `datum_posudbe` date NOT NULL,
  `datum_do_vracanja` date default NULL,
  `datum_vracanja` date default NULL,
  PRIMARY KEY  (`posudba_ID`),
  KEY `clanovi` (`clan_ID`),
  KEY `knjige` (`knjiga_kod`),
  CONSTRAINT `clanovi` FOREIGN KEY (`clan_ID`) REFERENCES `bi_clanovi` (`clan_ID`) ON UPDATE NO ACTION,
  CONSTRAINT `knjige` FOREIGN KEY (`knjiga_kod`) REFERENCES `bi_knjige` (`knjiga_kod`) ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of bi_posudbe
-- ----------------------------
INSERT INTO `bi_posudbe` VALUES ('40', '1', '1', '2021-04-13', '2021-04-28', '2021-04-15');
INSERT INTO `bi_posudbe` VALUES ('41', '1', '1', '2021-04-13', '2021-04-28', '2021-05-01');
INSERT INTO `bi_posudbe` VALUES ('42', '2', '5', '2021-04-14', '2021-04-29', '2021-04-30');
INSERT INTO `bi_posudbe` VALUES ('43', '2', '1', '2021-04-14', '2021-04-29', '2021-05-05');
INSERT INTO `bi_posudbe` VALUES ('44', '2', '1', '2021-04-14', '2021-04-29', null);
INSERT INTO `bi_posudbe` VALUES ('45', '2', '5', '2021-04-14', '2021-04-29', '2021-05-01');
INSERT INTO `bi_posudbe` VALUES ('46', '1', '1', '2021-04-14', '2021-04-29', '2021-04-14');
INSERT INTO `bi_posudbe` VALUES ('47', '1', '1', '2021-04-14', '2021-04-29', null);
INSERT INTO `bi_posudbe` VALUES ('48', '1', '5', '2021-04-14', '2021-04-29', null);
INSERT INTO `bi_posudbe` VALUES ('49', '2', '6', '2021-04-16', '2021-05-01', '2021-05-02');

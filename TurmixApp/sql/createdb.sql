drop database if exists turmix;
create database turmix;

DROP TABLE IF EXISTS `turmix`.`auto`;
CREATE TABLE  `turmix`.`auto` (
  `Rendszam` varchar(10) NOT NULL primary key,
  `Kapacitas` tinyint(4) NOT NULL,
  `Lizing` float NOT NULL default '0',
  `Koltseg` float NOT NULL default '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS `turmix`.`latlng2`;
CREATE TABLE  `turmix`.`latlng2` (
  `Utca` varchar(255) character set utf8 NOT NULL,
  `Lat` double default NULL,
  `Lng` double default NULL,
  PRIMARY KEY  (`Utca`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS `turmix`.`problematic`;
CREATE TABLE  `turmix`.`problematic` (
  `Cim` varchar(255) NOT NULL,
  PRIMARY KEY  (`Cim`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS `turmix`.`problemutca`;
CREATE TABLE  `turmix`.`problemutca` (
  `Utca` varchar(255) NOT NULL,
  PRIMARY KEY  (`Utca`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS `turmix`.`tm3`;
CREATE TABLE  `turmix`.`tm3` (
  `Cim` varchar(255) NOT NULL,
  `Tm3` tinyint(4) default '0',
  `Datum` date default NULL,
  PRIMARY KEY  (`Cim`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS `turmix`.`menetlevel`;
CREATE TABLE  `turmix`.`menetlevel` (
  `Datum` date NOT NULL,
  `Rendszam` varchar(10) NOT NULL,
  `Sofor` varchar(50) NOT NULL,
  `Seged1` varchar(50) default NULL,
  `Seged2` varchar(50) default NULL,
  `Kezdo` int(10) unsigned NOT NULL default '0',
  `Zaro` int(10) unsigned NOT NULL default '0',
  `Osszes` int(10) unsigned NOT NULL default '0',
  `Hol` varchar(100) default NULL,
  `Fordulo` tinyint(3) unsigned default '0',
  `Me` varchar(50) default NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS `turmix`.`tankolas`;
CREATE TABLE  `turmix`.`tankolas` (
  `Datum` date default NULL,
  `Rendszam` varchar(10) NOT NULL,
  `Km` int(11) NOT NULL default '0',
  `Liter` float NOT NULL default '0',
  `Egysegar` float NOT NULL default '0',
  `Koltseg` float NOT NULL default '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

create user dev identified by 'dev';
grant all on turmix.* to dev;
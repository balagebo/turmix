use turmix;

DROP TABLE IF EXISTS `turmix`.`munkalap`;
CREATE TABLE  `turmix`.`munkalap` (
  `munkalapszam` int(10) unsigned NOT NULL DEFAULT '0',
  `datum` date NOT NULL DEFAULT '0000-00-00',
  `rendszam` varchar(7) NOT NULL,
  `sofor` varchar(50) NOT NULL,
  `seged` varchar(50) DEFAULT NULL,
  `irszam` smallint(5) unsigned DEFAULT NULL,
  `utca` varchar(50) default null,
  `hazszam` varchar(10) DEFAULT NULL,
  `napszak` tinyint(3) unsigned DEFAULT NULL,
  `csohossz` tinyint(3) unsigned DEFAULT NULL,
  `kapacitas` tinyint(3) unsigned DEFAULT NULL,
  `fkod` int(10) unsigned,
  `megrendelo` varchar(50),

  PRIMARY KEY (`munkalapszam`,`datum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS `turmix`.`munkalaptranzit`;
CREATE TABLE  `turmix`.`munkalaptranzit` (
  `munkalapszam` int(10) unsigned NOT NULL DEFAULT '0',
  `datum` date NOT NULL DEFAULT '0000-00-00',
  `rendszam` varchar(7) NOT NULL,
  `sofor` varchar(50) NOT NULL,
  `seged` varchar(50) DEFAULT NULL,
  `irszam` smallint(5) unsigned DEFAULT NULL,
  `utca` varchar(50) default null,
  `hazszam` varchar(10) DEFAULT NULL,
  `napszak` tinyint(3) unsigned DEFAULT NULL,
  `csohossz` tinyint(3) unsigned DEFAULT NULL,
  `kapacitas` tinyint(3) unsigned DEFAULT NULL,
  `fkod` int(10) unsigned,
  `megrendelo` varchar(50),
  `printed` datetime DEFAULT '0000-00-00',
  PRIMARY KEY (`munkalapszam`,`datum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

SET character_set_client = utf8;
SET character_set_results = utf8;
SET character_set_connection = utf8;
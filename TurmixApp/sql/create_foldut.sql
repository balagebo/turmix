use turmix;

ALTER TABLE `turmix`.`latlng2`
  ADD COLUMN `foldlat` DOUBLE DEFAULT 0 AFTER `Lng`,
  ADD COLUMN `foldlng` DOUBLE DEFAULT 0 AFTER `foldlat`,
  ADD COLUMN `foldhossz` MEDIUMINT UNSIGNED DEFAULT 0 AFTER `foldlng`;

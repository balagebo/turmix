load data local infile 'e:\\tx-data-menetlevel_uj.csv' into table menetlevel
character set utf8
fields
  terminated by ';'
lines
  terminated by '\n'
(Datum, Rendszam, Sofor, Seged1, Seged2, Kezdo, Zaro, Osszes, Hol, @ford, Me)
set Fordulo = CASE WHEN @ford='' THEN 0 ELSE @ford END;
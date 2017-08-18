
delimiter \
drop procedure if exists turmix.SelectAtlagFogy \

create procedure turmix.SelectAtlagFogy(in kezdo date, in veg date)
reads sql data
begin
  if kezdo is null then
    set kezdo = current_date;
  end if;
  if veg is null then
    set veg = current_date;
  end if;
  set @sel = concat('select Rendszam, avg(Ktg) as Atlag, avg(Liter) as Literatlag from (select *, sum(Koltseg) as Ktg from tankolas
    where Datum between \'', kezdo, '\' and \'', veg, '\' group by Datum, Rendszam) as Temp group by Rendszam order by Rendszam;');
  prepare atlagFogy from @sel;
  execute atlagFogy;

end \

delimiter ;
--Winkler Lara
--Aufgabe 20
--20-05-2022


use kryptologie;


--C2
--s20170616
create function dbo.Ceasar(
	@Letter char,
	@Key integer
)
returns char
as
begin
	declare @result char= ''
	while (@Key > 26)
		begin
			set @Key = @Key -26
		end
	set @Letter = upper(@Letter);
	if(64 < ascii(@Letter) and ascii(@Letter) < 91)
		begin
			set @result = char(ascii(@Letter) + @Key)
			if(ascii(@result) > 90)
				begin 
					set @result = char(64 + (ascii(@result) - 90))
				end
		end
		return @result
end
go


select	substring('Kleopatra', #, 1) Klartext, 
		dbo.Ceasar(substring('Kleopatra', #, 1), 6) Schlüsseltext
   from Numbers
  where # > 0 and # <= len('Kleopatra')
;
go



--C3 Teil1
--s20170616
create function dbo.CeasarEncrypt(
	@Message varchar(1024),
	@Key integer
)
returns varchar(1024)
begin
	declare @result varchar(1024) = '';
	declare @i integer = 0;
	set @Message = replace(@Message, ' ', '')
	while(@i < len(@Message))
		begin 
			set @i = @i + 1
			set @result = concat(@result, dbo.Ceasar(substring(@Message, @i, 1), @Key))

		end
		return @result
end
go


select dbo.CeasarEncrypt(
	'Der Mohr hat seine Schuldigkeit getan',
	7
) Schlüsseltext
;
go



--C3 Teil2
--s20170616
create function dbo.CeasarDecrypt(
	@Message varchar(1024),
	@Key integer
)
returns varchar(1024)
begin
	declare @result varchar(1024) = '';
	while (@Key > 26)
		begin 
			set @Key = @Key - 26
		end
		set @result = dbo.CeasarEncrypt(@Message, 26 - @Key)
		return @result
end
go


select dbo.CeasarEncrypt(
	'Erkenne den rechten Zeitpunkt',
	9
) Schlüsseltext

select dbo.CeasarDecrypt(
	'NATNWWNMNWANLQCNWINRCYDWTC',
	9
) Klartext


/*	C3 Fragen s20170616
  -	Man erhält mit dem gleichen Schlüssel wieder den Klartext
  - Man muss den gleichen Schlüssel, wie beim Chiffrieren
*/



--C4
--s20170616
select # Verschiebung,
	   dbo.CeasarEncrypt('RSVEUJNZIUUVIWRLCVWCVZJJZX', #) Decodierung
   from Numbers
  where # > 0 and # <= 26
;
go


/*	C4 Fragen s20170616
  -	ABENDSWIRDDERFAULEFLEISSIG
    (Abends wird der Faule fleissig)
  - Es wurde die 17te Verschiebung benutzt
*/



--C5
create function dbo.CeasarAlphabet(
	@Key integer,
	@Separator varchar = ''
)
returns varchar(52)
begin
	declare @result varchar(52) = ''
	declare @i integer = 1
	while(@i < 27)
		begin 
			if(@i != 1 and @i != 27)
				begin 
					set @result = concat(@result, @Separator)
				end
				set @result = concat(@result, dbo.Ceasar(char(64 + @i), @Key))
				set @i = @i + 1
		end
		return @result
end
go


select dbo.CeasarAlphabet(3, '|') Verschiebung3
;
go

select dbo.CeasarAlphabet(#, '|') "Vigenère-Quadrat"
   from Numbers
  where # > -1 and # <= 25
;
go


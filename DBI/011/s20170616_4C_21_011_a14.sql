--Winkler Lara
--Aufgabe 11
--Übung 14
--Teil a

--use Catalog;
--go

set datefirst 1;

drop function if exists dbo.Calendar;
go

create function dbo.Calendar(
  @Year int
, @Month tinyint
) returns @Calendar table
	(
		Mo char(2),	
		Tu char(2),	
		We char(2),	
		Th char(2),	
		Fr char(2),	
		Sa char(2),	
		Su char(2)
	)
as
begin
	declare @Days int = dbo.DaysOfMonthOfYear(@Year, @Month);
	declare @count int = 1;
	declare @Mo char(2) = '';
	declare @Tu char(2) = '';
	declare @We char(2) = '';
	declare @Th char(2) = '';
	declare @Fr char(2) = '';
	declare @Sa char(2) = '';
	declare @Su char(2) = '';
	
	while @count <= @Days
	begin
		if datepart(Weekday, datefromparts(@Year, @Month, @count)) = 1
			set @Mo = @count
		if datepart(Weekday, datefromparts(@Year, @Month, @count)) = 2
			set @Tu = @count
		if datepart(Weekday, datefromparts(@Year, @Month, @count)) = 3
			set @We = @count
		if datepart(Weekday, datefromparts(@Year, @Month, @count)) = 4
			set @Th = @count
		if datepart(Weekday, datefromparts(@Year, @Month, @count)) = 5
			set @Fr = @count
		if datepart(Weekday, datefromparts(@Year, @Month, @count)) = 6
			set @Sa = @count
		if datepart(Weekday, datefromparts(@Year, @Month, @count)) = 7
		begin
			set @Su = @count;
			insert into @Calendar
				(Mo, Tu, We, Th, Fr, Sa, Su)
			values 
				(@Mo, @Tu, @We, @Th, @Fr, @Sa, @Su);

			set @Mo = '';
			set @Tu = '';
			set @We = '';
			set @Th = '';
			set @Fr = '';
			set @Sa = '';
			set @Su = '';
		end
		set @count = @count + 1;
	end
	if @Su = ''
		insert into @Calendar
				(Mo, Tu, We, Th, Fr, Sa, Su)
			values 
				(@Mo, @Tu, @We, @Th, @Fr, @Sa, @Su);
	return
end
go


--Mein Geburtsmonat
--s20170616
select *
  from dbo.Calendar(2022, 11);
go


--Schleife die alle Monate durchläuft
declare @Month int = 1;
while (@Month < 13)
	begin 
		select *, datename(year, datefromparts(2022, @Month, 1))
				, datename(month, datefromparts(2022, @Month, 1))
		  from dbo.Calendar(2022, @Month);
		set @Month += 1;
	end
go
--Winkler Lara
--Aufgabe 15


--Übung 4
create database happysushi;
go

use master;
go

drop table if exists Untersteht;
drop table if exists Arbeitet;
drop table if exists Filiale;
drop table if exists Angestellter;
go

create table Angestellter (
  SVN		varchar(20) not null primary key
, Vorname	varchar(20) not null 
, Nachname	varchar(20) not null
, Telefon	varchar(20) not null
, Gehalt	varchar(20) not null
);
go

create table Filiale (
  FilialNr	int		    not null primary key
, Strasse	varchar(64) not null 
, Ort		varchar(20) not null
, PLZ		varchar(20) not null
, Telefon	varchar(20) not null
, Leiter	varchar(20) not null
, foreign key (Leiter) references Angestellter(SVN)
);
go

create table Untersteht (
  SVNa		varchar(20) not null 
, SVNb		varchar(20) not null 
, primary key (SVNa, SVNb)
, foreign key (SVNa) references Angestellter(SVN)
, foreign key (SVNb) references Angestellter(SVN)
);
go

create table Arbeitet (
  FilialNr	int			not null 
, SVN		varchar(20)	not null 
, primary key (FilialNr, SVN)
, foreign key (FilialNr) references Filiale(FilialNr)
, foreign key (SVN) references Angestellter(SVN)
);
go

insert into Angestellter 
  (SVN			, Vorname		, Nachname	 , Telefon		 , Gehalt )
values
  ('2072980526'	, 'Carina'		, 'Aschauer' , '0664 / 12072', 2072.00)
, ('2075980809'	, 'Hans-Peter'	, 'Enser'	 , '0664 / 12075', 2075.00)
, ('2076970925'	, 'Michael'		, 'Ernst'	 , '0664 / 12076', 2076.00)
, ('2079980221'	, 'Marcel'		, 'Fortin'	 , '0664 / 12079', 2079.00)
, ('1073970812'	, 'Michael'		, 'Frankolin', '0664 / 11073', 1073.00)
;
go

insert into Filiale
  (FilialNr	, Strasse						, Ort			, PLZ	, Telefon		  , Leiter)
values
  (1		, 'Burggasse 71'				, 'Wien' 		, '1070', '01 / 522 91 03', '2072980526')
, (2		, 'Prokopigasse 4'				, 'Graz'		, '8010', '0316 / 852 285', '2076970925')
, (3		, 'Matthias Corvinus-Straße 15' , 'St. Pölten'	, '3100', '02742 / 51 510', '2079980221')
;
go

--s20170616
--Teil 4.7
insert into Filiale
  (FilialNr	, Strasse						, Ort			, PLZ	, Telefon		  , Leiter)
values
  (4		, 'Altstadt 10'					, 'Linz' 		, '4020', '0732 / 786 611', '2345678')
;
go

--s20170616
--Teil 4.8
insert into Filiale
  (FilialNr	, Strasse						, Ort			, PLZ	, Telefon		  , Leiter)
values
  (4		, 'Altstadt 10'					, 'Linz' 		, '4020', '0732 / 786 611', '2072980526')
;
go

--s20170616
--Teil 4.9
select Nachname, Vorname, f.Ort, a.Telefon "TelPrivat", f.Telefon "TelFiliale"
  from Angestellter a
 join Filiale f on f.Leiter = a.SVN
 order by Nachname, Vorname asc
;
go

--s20170616
--Teil 4.10
select Strasse, Ort, PLZ, f.Telefon, a.Vorname, a.Nachname
  from Filiale f
 join Angestellter a on a.SVN = f.Leiter
 order by PLZ asc
;
go


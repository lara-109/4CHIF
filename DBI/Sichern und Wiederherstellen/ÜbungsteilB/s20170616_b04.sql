use testdb;
go

drop table if exists dbo.LogTest;
go

select top 1000000 
       identity(int, 1, 1) SomeID 
     , abs(checksum(newid())) % 50000 + 1 SomeInt 
     , char(abs(checksum(newid())) % 26 + 65) + 
       char(abs(checksum(newid())) % 26 + 65) SomeLetters2 
     , cast(abs(checksum(newid())) % 10000 / 100.0 as money) SomeMoney 
     , cast(rand(checksum(newid())) * 3653.0 + 36524.0 as datetime) SomeDate 
     , right(newid(), 12) SomeHex12 
  into dbo.LogTest
  from sys.all_columns ac1 cross join sys.all_columns ac2
; 
go

/*
a. Wofür ist die INTO-Klausel? 
	Steht für das einfügen von Daten in Tabellen
b. Welchen Zweck hat CROSS JOIN?
	Steht für das bildent eines Kreuzproduktes von Datensätzen
c. Was bewirkt TOP?
	Steht für das nutzen der ersten x Zeilen
d. Wozu dient IDENTITY?
	Steht dafür das jeder Datensatz in der Spalte eine Identität bekommt
e. Was ist CHECKSUM, was NEWID()?
	Checksum erstellt einen HashIndex
	NewId erstellt einen einzigartigen Wert
f. Welche Auswirkung hat das Kommando?
	Steht dafür das dbo.LogTest erstellt wird und die ersten 1000000 Zeilen mit Daten gefüllt werden
*/
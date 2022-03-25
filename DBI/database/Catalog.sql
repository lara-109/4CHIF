create database Catalog;
go

use Catalog;
go

drop table SupplierParts;
drop table Suppliers;
drop table Parts;
go

create table Suppliers (
  SupplierID       varchar(2) not null primary key
, SupplierName     varchar(6) not null
, SupplierCity     varchar(6) not null
, SupplierDiscount decimal(2) not null  
 );
go

create table Parts (
  PartID    varchar(2) primary key
, PartName  varchar(8) not null
, PartColor varchar(5) not null
, PartPrice integer    not null
, PartCity  varchar(6) not null
);
go

create table SupplierParts (
  SupplierID varchar(2) not null references Suppliers
, PartID     varchar(2) not null references Parts
, Amount     decimal(4) not null
, primary key (SupplierID, PartID)
);
go

-- DML

set nocount on;
go

begin transaction;

delete from SupplierParts;
delete from Suppliers;
delete from Parts;
go

insert into Suppliers
  (SupplierID, SupplierName, SupplierCity, SupplierDiscount)
values
  (      'L1',     'Schmid',      'London',              20)
, (      'L2',      'Jonas',       'Paris',              10)
, (      'L3',     'Berger',       'Paris',              30)
, (      'L4',      'Klein',      'London',              20)
, (      'L5',       'Adam',       'Athen',              30)
;
go

insert into Parts
  (PartID, PartName  , PartColor, PartPrice, PartCity)
values
  (  'T1',   'Mutter',     'rot',        12, 'London')
, (  'T2',   'Bolzen',    'gelb',        17,  'Paris')
, (  'T3', 'Schraube',    'blau',        17,    'Rom')
, (  'T4', 'Schraube',     'rot',        14, 'London')
, (  'T5',    'Welle',    'blau',        12,  'Paris')
, (  'T6',  'Zahnrad',     'rot',        19, 'London')
;
go

insert into SupplierParts
  (SupplierID, PartID, Amount)
values
  (      'L1',   'T1',    300)
, (      'L1',   'T2',    200)
, (      'L1',   'T3',    400)
, (      'L1',   'T4',    200)
, (      'L1',   'T5',    100)
, (      'L1',   'T6',    100)
, (      'L2',   'T1',    300)
, (      'L2',   'T2',    400)
, (      'L3',   'T2',    200)
, (      'L4',   'T2',    200)
, (      'L4',   'T4',    300)
, (      'L4',   'T5',    400)
;
go

commit;
go

create index IDX_SupplierParts_SupplierID
    on SupplierParts(SupplierID)
;
go

create index IDX_SupplierParts_PartID
    on SupplierParts(PartID)
;
go
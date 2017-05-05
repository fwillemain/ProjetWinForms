
drop type if exists TypeTableTachesProd2
go
create type TypeTableTachesProd2 as table
(
	IdTache UNIQUEIDENTIFIER primary key,
	DureePrevue FLOAT (5) not null,
	DureeRestanteEstimee FLOAT (5) not null,
	CodeModule VARCHAR (20) not null,
	CodeLogicieModule VARCHAR (20) not null,
	NumeroVersion FLOAT (4) not null,
	CodeLogicielVersion VARCHAR (20) not null,
	Libelle NVARCHAR (40) not null,
	Annexe BIT not null,
	CodeActivite VARCHAR (20) not null,
	Login VARCHAR (20) not null,
	DateTravail DATE not null,
	Heures FLOAT not null,
	TauxProductivite FLOAT not null
	
)
go

drop type if exists TypeTableTachesAnx
go
create type TypeTableTachesAnx as table
(
	IdTache UNIQUEIDENTIFIER primary key,
	Libelle NVARCHAR (40) not null,
	Annexe BIT not null,
	CodeActivite VARCHAR (20) not null,
	Login VARCHAR (20) not null
)
go

drop type if exists TypeTableTachesProdSansTravail
go
create type TypeTableTachesProdSansTravail as table(
	IdTache UNIQUEIDENTIFIER primary key,
	DureePrevue FLOAT (5) not null,
	DureeRestanteEstimee FLOAT (5) not null,
	CodeModule VARCHAR (20) not null,
	CodeLogicieModule VARCHAR (20) not null,
	NumeroVersion FLOAT (4) not null,
	CodeLogicielVersion VARCHAR (20) not null,
	Libelle NVARCHAR (40) not null,
	Annexe BIT not null,
	CodeActivite VARCHAR (20) not null,
	Login VARCHAR (20) not null,
	Description	NVARCHAR(1000)
)
go

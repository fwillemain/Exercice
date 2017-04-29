-- Suppression des contraintes de clés étrangères
if exists(select 1 from INFORMATION_SCHEMA.TABLE_CONSTRAINTS
		where CONSTRAINT_SCHEMA = 'anx' and CONSTRAINT_NAME = 'Batiment_Lieu_FK')
alter table anx.Batiment drop constraint Batiment_Lieu_FK
go

if exists(select 1 from INFORMATION_SCHEMA.TABLE_CONSTRAINTS
		where CONSTRAINT_SCHEMA = 'anx' and CONSTRAINT_NAME = 'Box_Batiment_FK')
alter table anx.Box drop constraint Box_Batiment_FK
go

if exists(select 1 from INFORMATION_SCHEMA.TABLE_CONSTRAINTS
		where CONSTRAINT_SCHEMA = 'anx' and CONSTRAINT_NAME = 'Box_Lieu_FK')
alter table anx.Box drop constraint Box_Lieu_FK
go

if exists(select 1 from INFORMATION_SCHEMA.TABLE_CONSTRAINTS
		where CONSTRAINT_SCHEMA = 'anx' and CONSTRAINT_NAME = 'HistoriqueLieu_Lieu_FK')
alter table anx.HistoriqueLieu drop constraint HistoriqueLieu_Lieu_FK
go

if exists(select 1 from INFORMATION_SCHEMA.TABLE_CONSTRAINTS
		where CONSTRAINT_SCHEMA = 'anx' and CONSTRAINT_NAME = 'HistoriqueLieu_Lieu_FKv2')
alter table anx.HistoriqueLieu drop constraint HistoriqueLieu_Lieu_FKv2
go

if exists(select 1 from INFORMATION_SCHEMA.TABLE_CONSTRAINTS
		where CONSTRAINT_SCHEMA = 'anx' and CONSTRAINT_NAME = 'HistoriqueLieu_Vache_FK')
alter table anx.HistoriqueLieu drop constraint HistoriqueLieu_Vache_FK
go

--------------------------------------------------------------------------
-- Création des tables

if exists(select 1 from INFORMATION_SCHEMA.TABLES
		where TABLE_SCHEMA = 'anx' and TABLE_NAME = 'Batiment')
drop table anx.Batiment
go
CREATE TABLE anx.Batiment
  (
    Id               INTEGER NOT NULL ,
    QuantitéFourrage SMALLINT NOT NULL ,
    NombreAllées     TINYINT NOT NULL
  )
GO
ALTER TABLE anx.Batiment ADD CONSTRAINT Batiment_PK PRIMARY KEY CLUSTERED (Id)
GO

if exists(select 1 from INFORMATION_SCHEMA.TABLES
		where TABLE_SCHEMA = 'anx' and TABLE_NAME = 'Box')
drop table anx.Box
go
CREATE TABLE anx.Box
  (
    Id           INTEGER NOT NULL ,
    Batiment_Id  INTEGER NOT NULL ,
    NombrePlaces SMALLINT NOT NULL
  )
GO
ALTER TABLE anx.Box ADD CONSTRAINT Box_PK PRIMARY KEY CLUSTERED (Id,
Batiment_Id)
GO

if exists(select 1 from INFORMATION_SCHEMA.TABLES
		where TABLE_SCHEMA = 'anx' and TABLE_NAME = 'HistoriqueLieu')
drop table anx.HistoriqueLieu
go
CREATE TABLE anx.HistoriqueLieu
  (
    Id                     INTEGER NOT NULL ,
    DateDébut              DATE NOT NULL ,
    DateFin                DATE ,
    HeuresParJourPrincipal TINYINT NOT NULL ,
    LieuPrinc_Id           INTEGER NOT NULL ,
    LieuSecond_Id          INTEGER ,
    Vache_Id               INTEGER NOT NULL
  )
GO
ALTER TABLE anx.HistoriqueLieu ADD CONSTRAINT HistoriqueLieu_PK PRIMARY KEY
CLUSTERED (Id)
GO

if exists(select 1 from INFORMATION_SCHEMA.TABLES
		where TABLE_SCHEMA = 'anx' and TABLE_NAME = 'Lieu')
drop table anx.Lieu
go
CREATE TABLE anx.Lieu
  (
    Id INTEGER NOT NULL IDENTITY NOT FOR REPLICATION ,
    Nom NVARCHAR (40) NOT NULL ,
    Surface  INTEGER NOT NULL ,
    TypeLieu TINYINT NOT NULL DEFAULT 1
  )
GO
ALTER TABLE anx.Lieu
ADD CHECK ( TypeLieu IN (1, 2, 3) )
GO
ALTER TABLE anx.Lieu ADD CONSTRAINT Lieu_PK PRIMARY KEY CLUSTERED (Id)
GO

if exists(select 1 from INFORMATION_SCHEMA.TABLES
		where TABLE_SCHEMA = 'anx' and TABLE_NAME = 'Vache')
drop table anx.Vache
go
CREATE TABLE anx.Vache
  (
    Id INTEGER NOT NULL ,
    Nom NVARCHAR (40)
  )
GO
ALTER TABLE anx.Vache ADD CONSTRAINT Vache_PK PRIMARY KEY CLUSTERED (Id)
GO

------------------------------------------------------------------------
-- Ajout des contraintes de clés étrangères

ALTER TABLE anx.Batiment
ADD CONSTRAINT Batiment_Lieu_FK FOREIGN KEY( Id )
REFERENCES anx.Lieu (Id)
GO

ALTER TABLE anx.Box
ADD CONSTRAINT Box_Batiment_FK FOREIGN KEY (Batiment_Id)
REFERENCES anx.Batiment(Id)
GO

ALTER TABLE anx.Box
ADD CONSTRAINT Box_Lieu_FK FOREIGN KEY(Id)
REFERENCES anx.Lieu(Id)
GO

ALTER TABLE anx.HistoriqueLieu
ADD CONSTRAINT HistoriqueLieu_Lieu_FK FOREIGN KEY(LieuPrinc_Id)
REFERENCES anx.Lieu(Id)
GO

ALTER TABLE anx.HistoriqueLieu
ADD CONSTRAINT HistoriqueLieu_Lieu_FKv2 FOREIGN KEY(LieuSecond_Id)
REFERENCES anx.Lieu(Id)
GO

ALTER TABLE anx.HistoriqueLieu
ADD CONSTRAINT HistoriqueLieu_Vache_FK FOREIGN KEY(Vache_Id)
REFERENCES anx.Vache(Id)
GO


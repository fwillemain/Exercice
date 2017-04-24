--AJOUT VACHES
--insert amx.Vache(Id,Nom) values(2, 'Nova')
--insert amx.Vache(Id,Nom) values(3, 'Paquerette')
--insert amx.Vache(Id,Nom) values(4, 'Vache4'), (5, 'Vache5')

--LISTE COMMANDE
--select *
--from amx.Vache

--delete from amx.Vache
--where id=8

--select ID from amx.Vache

--delete from amx.Vache
--where id in (3,4)

--update amx.Vache set Nom = 'Rose' where id = 4

--update amx.HistoriqueLieu set DateDébut = '2017-01-15', DateFin = '2017-03-01' where id = 1

--select *
--from amx.HistoriqueLieu

--AJOUT DONNEE DANS BATIMENT
--insert amx.Batiment(Id, NombreAllées,QuantitéFourrage) values(2,10,100), (3,2,10)

--AJOUT DONNE DANS CASE
--insert amx."Case"(Id, NombrePlaces, Batiment_Id) values(1,10,2)

--insert amx."Case"(Id, NombrePlaces, Batiment_Id) values(2,10,3)

--AJOUT D'UN LIEU
--insert amx.Lieu(Nom,Surface,TypeLieu) values('Batiment2', 20000, 1)

--MAJ  d'un champs
--update amx.Lieu set Nom = 'Batiment3' where id = 4

select *
from amx."Case"

select *
from amx.Batiment

select *
from amx.HistoriqueLieu

select *
from amx.Lieu

select *
from amx.Vache
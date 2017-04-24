-- Création d'une procédure stockée
drop procedure if exists AppliquerRabais
go
create procedure AppliquerRabais @taux real, @montantMin money
as
begin
	Update Order_Details set Discount = @taux
	where Quantity * UnitPrice >= @montantMin
end
go

-- Appel de la procédure
exec AppliquerRabais 0.20, 200

-- On peut affecter des valeurs par défaut aux paramètres
drop procedure if exists AppliquerRabais
go
create procedure AppliquerRabais
@taux real = 0.20, @montantMin money = 100
as
begin
	Update Order_Details set Discount = @taux
	where Quantity * UnitPrice >= @montantMin
end
go

-- Une procédure peut être utilisée comme une vue 
-- pour regrouper les informations de plusieurs tables
-- avec l'avantage de pouvoir prendre des paramètres en entrée,
-- et avec l'inconvénient qu'on ne peut pas faire de jointure dessus
drop procedure if exists usp_TerritoiresDuSalarie
go
create procedure usp_TerritoiresDuSalarie @IdSalarie int
as
select R.RegionID, R.RegionDescription,
		T.TerritoryID, T.TerritoryDescription
from EmployeeTerritories ET
	inner join Territories T on ET.TerritoryID = T.TerritoryID
	inner join Region R on T.RegionID = R.RegionID
	where ET.EmployeeId = @IdSalarie
order by 1, 3
go

exec usp_TerritoiresDuSalarie 5
go

-- Création d'une fonction
drop function if exists ufn_Add
go
create function ufn_Add (@a int, @b int)
returns int
as
begin
	return @a + @b
end
go

-- Appel de la fonction
select dbo.ufn_Add(5, 9)


-- Création d'une fonction retournant un résultat de type table
drop function if exists ufn_ClientsDuPays
go
create function ufn_ClientsDuPays(@pays nvarchar(40))
returns @TableClients table
(
	Id nvarchar(10) primary key,
	Nom nvarchar(40) not null
)
as
begin
	insert @TableClients
	select CustomerID, CompanyName
	from Customers
	where country = @pays

	return
end
go

-- Appel de la fonction
select * from ufn_ClientsDuPays('France')

-- On peut même faire des jointures dessus
select c.Id, count(*) NbCommandes
from ufn_ClientsDuPays('France') c
inner join orders o on c.Id = o.CustomerID
group by c.Id


-- Création d'un type défini par l'utilisateur
drop type if exists TypeTablePersonne
go
create type TypeTablePersonne as table
(
	Id nvarchar(10) primary key,
	Nom nvarchar(40) not null
)
go

-- Récupération du résultat de la fonction dans une variable de ce type
declare @clients TypeTablePersonne
insert @clients
select Id, Nom from ufn_ClientsDuPays('France')



-- Fonction avec un paramètre de type table défini par nous
create type TypeTableId as table
(
	Id int primary key
)
go

-- drop function ufn_Compter
create function ufn_Compter(@Ids TypeTableId readonly)
returns int
as
begin
	return (select COUNT(*) from @Ids)
end
go

-- Appel de la fonction en lui fournissant une table
declare @Ids TypeTableId
insert @Ids values (123), (5421), (854)
select dbo.ufn_Compter(@Ids)
go

-- Fonction avec un paramètre et un retour de type table
-- Le type du retour ne peut pas être un type défini par nous
-- Il faut spécifier les colonnes de la table

-- drop function ufn_Oppposes
create function ufn_Oppposes(@Ids TypeTableId readonly)
returns @TableIds table (Id int)
as
begin
	insert @TableIds select -Id from @Ids
	return
end
go

-- Appel de la fonction en lui fournissant une table
declare @Ids TypeTableId
insert @Ids values (123), (5421), (854)
select * from dbo.ufn_Oppposes(@Ids)
go


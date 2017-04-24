-- 1. Cr�er une fonction MinDate qui renvoie la valeur minimale entre 2 dates
-- Si l'une des dates est nulle, renvoyer l'autre
-- si le 2 sont nulles, renvoyer arbitrairement la seconde
-- Tester cette fonction dans les diff�rents cas

drop function if exists MinDate
GO

Create FUNCTION MinDate
(	
	@v1 DateTime,
    @v2 DateTime
)
RETURNS DateTime
AS
BEGIN
	RETURN
	(Select Case 
	   when @v1 is null THEN @v2
	   when @v2 is null THEN @v1
	   when @v1 < @v2 THEN @v1
	   ELSE @v2
	   END)
END
GO

-- 2. Cr�er une proc�dure usp_ProductInfos qui regroupe les informations principales d'un produit
-- avec sa cat�gorie, et le nom et le pays de son fournisseur
-- Tester la proc�dure sur le produit 58

--drop procedure usp_ProductInfos
--go
create procedure usp_ProductInfos @IdProduit integer
as
begin
	select p.ProductName,p.UnitPrice, p.UnitsInStock, p.UnitsOnOrder,
		s.CompanyName Supplier, s.Country SupplierCountry, c.CategoryName
	from Products p
	inner join Suppliers s on p.SupplierID = s.SupplierID
	inner join Categories c on p.CategoryID = c.CategoryID
	where p.ProductID = @IdProduit
end
go

-- 3. Cr�er une proc�dure stock�e usp_OrderInfos qui rassemble les infos des lignes de commandes
-- et les infos principales d'une commande (diff�rentes dates, id client, id du livreur, frais de livraison)
-- Tester la proc�dure sur la commande 10986

--drop procedure usp_OrderInfos
--go

create procedure usp_OrderInfos @IdCmde integer
as
begin
	select c.CustomerID, od.UnitPrice, od.Quantity, od.Discount,
	o.OrderDate, o.RequiredDate, o.ShippedDate,
	s.ShipperID, s.CompanyName ShipperName, o.Freight
	from Order_Details od
	inner join orders o on od.OrderID = o.OrderID
	inner join Customers c on o.CustomerID = c.CustomerID
	inner join Shippers s on o.ShipVia = s.ShipperID
	where o.OrderID = @IdCmde
end
go

-- 4. Cr�er une proc�dure usp_DeleteProductsAndOrdersForSupplier permettant de supprimer :
-- * tous les produits provenant d'un forunisseur
-- * toutes les lignes de commandes r�f�ran�ant ces produits
-- * toutes les commandes contenant ces lignes, si elles ne contiennent plus aucune ligne
-- Utiliser pour cela au moins un curseur
-- Tester la proc�dure sur le fournisseur d'id 7 (� l'int�rieur d'une transaction pour pouvoir annuler)
-- en v�rifiant notamment que la commande 10265 est bien supprim�e

-- 5. Faire une nouvelle version de cette proc�dure, en utilisant cette fois des variables de type table
-- � la place des curseurs
--drop type TypeTableId
--go
ccreate type TypeTableId as table
(
	Id int primary key
)
go

-- drop procedure usp_DeleteProductsAndOrdersForSupplier
create procedure usp_DeleteProductsAndOrdersForSupplier @SuppId int
as
begin
	-- R�cup�ration des id des lignes de commandes
	declare @Commandes TypeTableId

	insert @Commandes
	select distinct od.OrderID
	from Order_Details od
		inner join products p on od.ProductID = p.ProductID
	where SupplierID = @SuppId
	
	-- Suppression des lignes de commandes
	delete from Order_Details
	where OrderID in (select Id from @Commandes)
	
	-- R�cup�ration des commandes sans lignes
	declare @CommandesVides TypeTableId
	insert @CommandesVides
	select o.OrderId
	 from Orders o
		left outer join Order_Details od on od.OrderID = o.OrderId
	group by o.OrderId
	having count(od.ProductID) = 0
	
	-- Suppression des commandes sans lignes
	delete from orders
	where OrderID in (select Id from @CommandesVides)

	-- Suppression des produits
	delete from Products where SupplierID = @SuppId
end
go

-- Test
begin tran
exec usp_DeleteProductsAndOrdersForSupplier 7
select * from orders where OrderID = 10265
rollback

-- 6. Faire une derni�re version utilisant cette fois des delete de masse, sans curseur ni variable table
-- (Bien plus efficace !!)
--drop procedure usp_DeleteProductsAndOrdersForSupplier
go
create procedure usp_DeleteProductsAndOrdersForSupplier @SuppId int
as
begin
	-- Suppression des lignes de commandes
	delete od
	from Order_Details od
	inner join products p on od.ProductID = p.ProductID
	where p.SupplierID = @SuppId

	-- Suppression des commandes sans lignes
	delete o
	from orders o
	where not exists (select OrderId from Order_Details where OrderID = o.OrderID)

	-- Suppression des produits
	delete from Products where SupplierID = @SuppId
end

-- Test
begin tran
exec usp_DeleteProductsAndOrdersForSupplier 7
rollback


-- 7. Cr�er une proc�dure stock�e de type table renvoyant les id des
-- commandes qui ne comportent que des produits issus d'un m�me fournisseur
create procedure usp_CommandesProduitsMemeFournisseur
as
begin
	select od.OrderID
	from order_details od
	inner join products p on od.ProductID = p.ProductID
	group by od.OrderID
	having count(distinct p.SupplierId) = 1
end
go	

-- Pour le fun : commandes pour lesquels il y a au moins 2 produits du m�me fournisseur
-- select od.OrderID, count(*) nbLignes, count(distinct p.SupplierId) nbFournisseurs
-- from order_details od
-- inner join products p on od.ProductID = p.ProductID
-- group by OrderID
-- having count(*) > 1 and count(distinct p.SupplierId) = 1

-- 8. r�cup�rer les id et noms des clients qui ont pass� les commandes
-- dont les id sont renvoy�s par la proc�dure cr��e pr�c�demment

-- On ne peut pas faire de requ�te directement sur le r�sultat d'une proc�dure stock�e
-- Il faut r�cup�rer le r�sultat dans une table au moyen de la syntaxe suivante :
declare @TableId table (
	Id int primary key)

insert @TableId exec usp_CommandesProduitsMemeFournisseur

-- On peut ensuite faire ce qu'on veut avec cette table
select c.CustomerID, c.CompanyName
from @TableId t
inner join Orders o on o.OrderID = t.Id
inner join Customers c on c.CustomerID = o.CustomerID

-- S'il n'y a pas d'insert/update/delete dans la proc�dure, il vaut mieux cr�er
-- une fonction � la place, car son r�sultat sera directement manipulable
-- dans une requ�te : select * from ufn_CommandesProduitsMemeFournisseur


--9 Faire une fonction qui retourne le m�me r�sultat que la proc�dure pr�c�dente
create function ufn_CommandesProduitsMemeFournisseur ()
returns @TableId table
(
	Id int primary key
)
as
begin
	insert @TableId
	select od.OrderID
	from order_details od
	inner join products p on od.ProductID = p.ProductID
	group by od.OrderID
	having count(distinct p.SupplierId) = 1
	
	return
end
go

-- L'exploitation du r�sultat de la fonction est plus simple que celui de la proc�dure
select * from ufn_CommandesProduitsMemeFournisseur()



-- 9. faire une fonction qui prend en param�tre une liste de personnes d�crites
-- par leur id, nom et date de naissance, et qui renvoie une liste de cha�nes de la forme
-- "412 - Toto, 25 ans"
-- Tester la fonction
create type TypeTablePersonne as table 
(
	Id int primary key,
	Nom nvarchar(40),
	DateNais date
)


drop function ufn_ListePersonne

create function ufn_ListePersonne(@Liste TypeTablePersonne readonly)
returns @Table table (Info nvarchar(40))
as
begin
	insert @Table select (cast(Id as nvarchar(10)) + ' - ' + Nom + ', ' + cast(DATEDIFF(year, DateNais, getdate()) as nvarchar(10))+ ' ans')
				  from @Liste
	return
end
go

declare @IDS TypeTablePersonnes
insert @IDS values (412, 'Toto', '10-04-1992'), (452,'Virginie', '10-14-1984')
select* from dbo.ufn_Function (@Ids)
go



declare @ListePersonne TypeTablePersonne
insert @ListePersonne
select EmployeeID, LastName, BirthDate
from Employees

select * from dbo.ufn_ListePersonne(@ListePersonne)



-- 1. Créer une fonction MinDate qui renvoie la valeur minimale entre 2 dates
-- Si l'une des dates est nulle, renvoyer l'autre
-- si le 2 sont nulles, renvoyer arbitrairement la seconde
-- Tester cette fonction dans les différents cas
drop function ufn_MinDate
go

create function ufn_MinDate(@Date1 date, @Date2 date)
returns date
as
begin
	declare @res date = @Date2
	
	if @Date1 < @Date2
		set @res = @Date1
	
	return @res
end
go


-- 2. Créer une procédure usp_ProductInfos qui regroupe les informations principales d'un produit
-- avec sa catégorie, et le nom et le pays de son fournisseur
-- Tester la procédure sur le produit 58
drop procedure usp_ProductInfos
go

create procedure usp_ProductInfos @ProductId int
as
begin
	select P.ProductName, P.UnitPrice, C.CategoryName, S.CompanyName, S.Country
	from Products P
	inner join Suppliers S on P.SupplierID = S.SupplierID
	inner join Categories C on C.CategoryID = P.CategoryID
	where P.ProductID = @ProductId
end
go


-- 3. Créer une procédure stockée usp_OrderInfos qui rassemble les infos des lignes de commandes
-- et les infos principales d'une commande (différentes dates, id client, id du livreur, frais de livraison)
-- Tester la procédure sur la commande 10986
drop procedure usp_OrdersInfos
go

create procedure usp_OrdersInfos @OrderId int
as
begin
	select O.OrderID, O.OrderDate, O.RequiredDate, O.ShippedDate, O.CustomerID, O.ShipVia, O.Freight
			 ,OD.*
	from Orders O
	inner join Order_Details OD on O.OrderID = OD.OrderID
	where O.OrderID = @OrderId
end
go

-- 4. Créer une procédure usp_DeleteProductsAndOrdersForSupplier permettant de supprimer :
-- * tous les produits provenant d'un forunisseur
-- * toutes les lignes de commandes référançant ces produits
-- * toutes les commandes contenant ces lignes, si elles ne contiennent plus aucune ligne
-- Utiliser pour cela au moins un curseur
-- Tester la procédure sur le fournisseur d'id 7 (à l'intérieur d'une transaction pour pouvoir annuler)
-- en vérifiant notamment que la commande 10265 est bien supprimée




-- 5. Faire une nouvelle version de cette procédure, en utilisant cette fois des variables de type table
-- à la place des curseurs




-- 6. Faire une dernière version utilisant cette fois des delete de masse, sans curseur ni variable table
-- (Bien plus efficace !!)

drop procedure usp_DeleteProductsAndOrdersForSupplier 
go

create procedure usp_DeleteProductsAndOrdersForSupplier @SupplierId int
as
begin

	delete Order_Details
	from Order_Details OD 
	inner join Products P on OD.ProductID = P.ProductID
	where P.SupplierID = @SupplierId
	
	delete
	from Products 
	where SupplierID = @SupplierId
	
	delete O
	from Orders O
	where not exists (select OrderID from Order_Details where OrderID = O.OrderID)
	
end
go

-- 7. Créer une procédure stockée de type table renvoyant les id des
-- commandes qui ne comportent que des produits issus d'un même fournisseur
drop procedure usp_CommandesProduitsFournisseurUnique
go

create procedure usp_CommandesProduitsFournisseurUnique
as
begin
	select OD.OrderID
	from Order_Details OD 
	inner join Products P on P.ProductID = OD.ProductID
	group by OD.OrderID
	having COUNT(distinct P.SupplierID) = 1		
end
go

drop function ufn_CommandesProduitsFournisseurUnique
go

-- Pareil mais en fonction
create function ufn_CommandesProduitsFournisseurUnique()
returns @Commandes table
(
	Id int primary key
)
as
begin
	insert @Commandes
	select OD.OrderID
	from Order_Details OD 
	inner join Products P on P.ProductID = OD.ProductID
	group by OD.OrderID
	having COUNT(distinct P.SupplierID) = 1		
	
	return
end
go


-- 8. récupérer les id et noms des clients qui ont passé les commandes
-- dont les id sont renvoyés par la procédure créée précédemment
drop procedure usp_InfosClientCommandesProduitsFournisseurUnique
go

create procedure usp_InfosClientCommandesProduitsFournisseurUnique
as
begin
	declare @CommandePFU table (OrderId int)
	
	insert @CommandePFU
	exec usp_CommandesProduitsFournisseurUnique
	
	select C.CustomerID, C.CompanyName 
	from Orders O
	inner join @CommandePFU PFU on O.OrderId = PFU.OrderId
	inner join Customers C on C.CustomerID = O.CustomerID
end
go

-- Pareil mais avec la fonction du 7
drop procedure usp_InfosClientCommandesProduitsFournisseurUnique2
go

create procedure usp_InfosClientCommandesProduitsFournisseurUnique2
as
begin
	
	select C.CustomerID, C.CompanyName 
	from Orders O
	inner join ufn_CommandesProduitsFournisseurUnique() PFU on O.OrderId = PFU.Id
	inner join Customers C on C.CustomerID = O.CustomerID
	
end
go

-- 9. faire une fonction qui prend en paramètre une liste de personnes décrites
-- par leur id, nom et date de naissance, et qui renvoie une liste de chaînes de la forme
-- "412 - Toto, 25 ans"
-- Tester la fonction

drop type TabPersonne
go

create type TabPersonne as table(
	Id int primary key,
	Prénom nvarchar(20),
	DateN date
)
go

drop function ufn_AfficherPersonne
go

create function ufn_AfficherPersonne(@Tab TabPersonne readonly)
returns nvarchar(100)
as
begin
	declare @res nvarchar(100)
	set @res = ''	
	
	select @res = @res + (CONVERT(varchar(5), Id) + ' - ' + Prénom + ', ' + 
				CONVERT(varchar(5), floor(DATEDIFF(day, DateN, getDate())/365.25)) + ' ans') + CHAR(13)
	from @Tab

	return @res
end
go

declare @Test TabPersonne

insert @Test values (1, 'Toto', '2007-10-10'), (2, 'Florian', '1986-10-13'), (3, 'Irène', '1992-10-01')
print dbo.ufn_AfficherPersonne(@Test)
go

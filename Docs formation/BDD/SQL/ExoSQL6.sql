-- 1. Liste des commandes contenant au moins un produit de la cat�gorie 7
-- Faire cette requ�te de 2 fa�ons diff�rentes

select a.OrderID
from Orders a
inner join Order_Details b on a.OrderID = b.OrderID
inner join Products c on b.ProductID = c.ProductID
inner join Categories d on c.CategoryID = d.CategoryID
where d.CategoryID = 7
Group by a.OrderID

select  O.Orderid, O.CustomerID
from Orders O
where exists (
select OD.ProductID
from Order_Details OD
inner join Products P on OD.ProductID = P.ProductID
where P.CategoryID = 7 and OD.OrderID = O.OrderID)





-- 2. Id des commandes qui contiennent plusieurs lignes de produits de m�me cat�gorie
-- (Faire la requ�te de 2 fa�ons diff�rentes, dont l'une qui utilise OVER)

select distinct OrderId
from(
	select OrderID, P.CategoryID, COUNT(*) nbLignes
	from Order_Details OD
	inner join Products P on OD.ProductID = P.ProductID
	group by OrderID, P.CategoryID
	having COUNT(*) > 1
	) R

select distinct OrderID
from Order_Details OD
inner join Products P on OD.ProductID = P.ProductID
group by OrderID, P.CategoryID
having COUNT (CategoryID) > 1

-- 3. Nombre de salari�s couvrant chaque r�gion

--select [1],[2],[3],[4]
--from (
--	select RegionID, a.EmployeeID from Employees a
--	inner join EmployeeTerritories b on a.EmployeeID = b.EmployeeID
--	inner join Territories c on b.TerritoryID = c.TerritoryID	
--) as Source
--pivot (
--	count(EmployeeID)
--	for RegionID in ([1],[2],[3],[4])
--) as Pays


select d.RegionID, COUNT(a.EmployeeID)
from Employees a
inner join EmployeeTerritories b on a.EmployeeID = b.EmployeeID
inner join Territories c on b.TerritoryID = c.TerritoryID
inner join Region d on c.RegionID = d.RegionID
group by d.RegionID


-- 4. Afficher le m�me r�sultat avec les id de r�gions en colonne

select [1],[2],[3],[4]
from (
	select RegionID, a.EmployeeID from Employees a
	inner join EmployeeTerritories b on a.EmployeeID = b.EmployeeID
	inner join Territories c on b.TerritoryID = c.TerritoryID	
) as Source
pivot (
	count(EmployeeID)
	for RegionID in ([1],[2],[3],[4])
) as Pays

 --5. Nombre de territoires couverts par chaque salari� dans chaque r�gion
-- avec affichage des nom des salari�s en ligne et des id de r�gions en colonnes

select d.RegionDescription, a.FirstName, COUNT(c.TerritoryID)as NbTerritoryCouvert
from Employees a
inner join EmployeeTerritories b on a.EmployeeID = b.EmployeeID
inner join Territories c on b.TerritoryID = c.TerritoryID
inner join Region d on c.RegionID = d.RegionID
group by d.RegionDescription, a.EmployeeID, a.FirstName


-- 6. Il serait bon de v�rifier que la requ�te pr�c�dente fonctionne
-- si un salari� couvre des territoires de r�gions diff�rentes.
-- Pour cela, faire les �tapes suivantes :

-- 6.1 Afficher le nombre de territoires couverts par personne pour chaque r�gion
-- (tri� selon les personnes)


-- 6.2 Faire en sorte que le salari� d'id 1 couvre aussi le territoire 48084
-- puis ex�cuter de nouveau la requ�te pr�c�dente pour v�rifier le r�sultat

-- 6.3 Ex�cuter de nouveau la requ�te 5 pour v�rifier le r�sultat

-- 7
-- 7.1 Cr�er une vue qui repr�sente un catalogue des produits avec leurs cat�gories
-- et les noms et pays de leurs fournisseurs
GO
create view cps as (

select ProductID, ProductName, CategoryName, CompanyName, Region
from Suppliers a
inner join Products b on a.SupplierID = b.SupplierID
inner join Categories c on b.CategoryID = c.CategoryID)
GO

-- 7.2 Cr�er une vue qui rassemble les infos des lignes de commandes
-- et les infos principales des commandes (diff�rentes dates, id client, id du livreur, frais de livraison)
GO
create view oo as (

select a.OrderID, ProductID, UnitPrice, Quantity, Discount, OrderDate, RequiredDate, ShippedDate, CustomerID, ShipVia, Freight
from Order_Details a
inner join Orders b on a.OrderID = b.OrderID)
GO
-- 7.3 Utiliser ces 2 vues pour afficher les d�tails de la commande 10531 du client OCEAN

select *
from cps a
inner join oo b on a.ProductID = b.ProductID
where OrderID = 10531
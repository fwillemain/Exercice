-- 1. Liste des commandes contenant au moins un produit de la cat�gorie 7
-- Faire cette requ�te de 2 fa�ons diff�rentes
select distinct OrderID 
from Order_Details OD
where exists(
	select OD.ProductID
	from Products P
	where P.CategoryID = 7 and P.ProductID = OD.ProductID)

select distinct OD.OrderID
from Products P
inner join Order_Details OD on P.ProductID = OD.ProductID
where P.CategoryID = 7

-- 2. Id des commandes qui contiennent plusieurs lignes de produits de m�me cat�gorie
-- (Faire la requ�te de 2 fa�ons diff�rentes, dont l'une qui utilise OVER)
select distinct OD.OrderID
from Products P
inner join Order_Details OD on P.ProductID = OD.ProductID
group by OD.OrderID, P.CategoryID
having COUNT(*) > 1

select distinct OrderID from(
	select OrderID, COUNT(*) over(partition by P.CategoryID, OD.OrderID) as B
	from Products P
	inner join Order_Details OD on P.ProductID = OD.ProductID) as A
where B > 1

-- 3. Nombre de salari�s couvrant chaque r�gion
select RegionID, COUNT(*) NbSal
from Territories T
inner join EmployeeTerritories ET on T.TerritoryID = ET.TerritoryID
group by T.RegionID

-- 4. Afficher le m�me r�sultat avec les id de r�gions en colonne

select [1] 'Region 1',[2] 'Region 2',[3] 'Region 3',[4] 'Region 4'
from (
	select RegionID, EmployeeID
	from Territories T
	inner join EmployeeTerritories ET on T.TerritoryID = ET.TerritoryID
) as Source
pivot (
	COUNT(EmployeeID)
	for RegionId in ([1],[2],[3],[4])
) as ProdParCat

-- 5. Nombre de territoires couverts par chaque salari� dans chaque r�gion
-- avec affichage des nom des salari�s en ligne et des id de r�gions en colonnes

select *
from (
	select T.RegionID, LastName as LN, FirstName as FN
	from Territories T
	inner join EmployeeTerritories ET on T.TerritoryID = ET.TerritoryID
	inner join Employees E on ET.EmployeeID = E.EmployeeID
) as Source
pivot (
	COUNT(RegionID)
	for RegionId in ([1],[2],[3],[4])
) as ProdParCat


-- 6. Il serait bon de v�rifier que la requ�te pr�c�dente fonctionne
-- si un salari� couvre des territoires de r�gions diff�rentes.
-- Pour cela, faire les �tapes suivantes :

-- 6.1 Afficher le nombre de territoires couverts par personne pour chaque r�gion
-- (tri� selon les personnes)

select T.RegionID, E.LastName, E.FirstName, COUNT(T.TerritoryID) NbTerr
from Territories T
inner join EmployeeTerritories ET on T.TerritoryID = ET.TerritoryID
inner join Employees E on ET.EmployeeID = E.EmployeeID
group by E.LastName, E.FirstName, T.RegionID
order by T.RegionID

-- 6.2 Faire en sorte que le salari� d'id 1 couvre aussi le territoire 48084
-- puis ex�cuter de nouveau la requ�te pr�c�dente pour v�rifier le r�sultat

select * from EmployeeTerritories where EmployeeID = 1

insert EmployeeTerritories values (1, '48084')

-- 6.3 Ex�cuter de nouveau la requ�te 5 pour v�rifier le r�sultat

-- C'est good!!!

-- 7
-- 7.1 Cr�er une vue qui repr�sente un catalogue des produits avec leurs cat�gories
-- et les noms et pays de leurs fournisseurs
GO
create view CatProd as (
	select P.ProductID, P.ProductName, P.QuantityPerUnit, P.UnitPrice, P.UnitsInStock, P.UnitsOnOrder, P.ReorderLevel, P.Discontinued,
		C.CategoryID, C.CategoryName, C.Description, C.Picture,
		S.SupplierID, S.CompanyName, S.Country
	from Products P
	inner join Categories C on P.CategoryID = C.CategoryID
	inner join Suppliers S on P.SupplierID = S.SupplierID)
GO

-- 7.2 Cr�er une vue qui rassemble les infos des lignes de commandes
-- et les infos principales des commandes (diff�rentes dates, id client, id du livreur, frais de livraison)
GO
create view InfoCom as (
	select OD.OrderID, OD.ProductID, OD.Quantity, OD.UnitPrice, OD.Discount,
		O.OrderDate, O.RequiredDate, O.ShippedDate, O.CustomerID, O.ShipVia, O.Freight
	from Order_Details OD
	inner join Orders O on O.OrderID = OD.OrderID)
GO
-- 7.3 Utiliser ces 2 vues pour afficher les d�tails de la commande 10531 du client OCEAN

select * 
from CatProd C
inner join InfoCom I on C.ProductID = I.ProductID
where I.OrderID = 10531 and I.CustomerID = 'OCEAN'

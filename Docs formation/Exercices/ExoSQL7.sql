-- 1. Liste des clients (id, nom d'entreprise) qui n'ont jamais command� un produit de la cat�gorie Condiments

select CustomerID, CompanyName
from Customers
where CompanyName not in (
	-- Liste des clients ayant command� des condiments
	select distinct CU.CompanyName
	from Categories CA
	inner join Products P on CA.CategoryID = P.CategoryID
	inner join Order_Details OD on OD.ProductID = P.ProductID
	inner join Orders O on O.OrderID = OD.OrderID
	inner join Customers CU on O.CustomerID = CU.CustomerID
	where CA.CategoryName = 'Condiments')

-- 2. Liste des pays pour lesquels il n'existe aucun fournisseur de produits de la cat�gorie Condiments

select distinct Country
from Suppliers
where Country not in (
	-- Liste des pays ayant au moins un fournisseur de Condiments
	select distinct S.Country
	from Categories CA
	inner join Products P on CA.CategoryID = P.CategoryID
	inner join Suppliers S on S.SupplierID = P.SupplierID
	where CA.CategoryName = 'Condiments')

-- 3. D�lai moyen de livraison des commandes de chaque livreur

select S.CompanyName, AVG(DATEDIFF(DAY, O.OrderDate, O.ShippedDate))
from Orders O
inner join Shippers S on O.ShipVia = S.ShipperID
group by S.CompanyName

-- 4. Liste des commandes qui contiennent le produit le plus vendu, c'est � dire
-- dont la quantit� totale vendue est la plus grande 

-- Id du produit le plus vendu
;with PPV as (
select top 1 OD.ProductID
from Order_Details OD
group by OD.ProductID
order by SUM(OD.Quantity) desc)


select * from Orders O
inner join Order_Details OD on O.OrderID = OD.OrderID, 
PPV
where OD.ProductID = PPV.ProductID

-- 5. Commandes comportant au moins un produit fourni par un fournisseur fran�ais

-- liste des produits fournis par un fournisseur fran�ais
; with ProdFR as (select ProductID
from Products P
inner join Suppliers S on P.SupplierID = S.SupplierID
where S.Country = 'France')

select distinct O.OrderID 
from Orders O
inner join Order_Details OD on O.OrderID = OD.OrderID,
ProdFR
where OD.ProductID = ProdFR.ProductID

-- 6. CA r�alis� par chaque �quipe repr�sent�e par son manager (une �quipe = 1 manager + ses manag�s directs)
GO
create view CAPersonne as (select E.EmployeeID, E.ReportsTo, SUM(OD.Quantity * OD.UnitPrice * (1 - OD.Discount)) CA
from Order_Details OD
inner join Orders O on OD.OrderID = O.OrderID
inner join Employees E on E.EmployeeID = O.EmployeeID
group by E.EmployeeID, E.ReportsTo)
GO

with CTE as (select CAPersonne.ReportsTo, SUM(CAPersonne.CA) CAEquipe
from CAPersonne
inner join Employees E on E.EmployeeID = CAPersonne.ReportsTo
group by CAPersonne.ReportsTo)

select CAEquipe + CAPersonne.CA from
CTE
inner join CAPersonne on CTE.ReportsTo = CAPersonne.EmployeeID








-- 1. Ins�rer un nouveau produit en sp�cifiant juste son nom
insert Products (ProductName) values ('Nouveau produit')

-- 2. Ins�rer un nouveau client fran�ais (pays = 'France') � votre nom
insert Customers (CustomerID, CompanyName, Country)
values ('CYRIL', 'Cyril Seguenot', 'France')

-- 3. Liste des r�gions et de leurs territoires (descriptions des r�gions et territoires)
select R.RegionID, R.RegionDescription, T.TerritoryDescription
from Region R
inner join Territories T on R.RegionID = T.RegionID


-- 4. Liste des livreurs (id et nom) qui ont livr� des produits au Canada
select distinct S.ShipperID, S.CompanyName
from Shippers S
inner join Orders O on S.ShipperID = O.ShipVia
where O.ShipCountry = 'Canada'

-- 5. Nombre total de livraisons r�alis�es par chaque livreur (id, nom)
select shipvia, CompanyName, count(OrderID)
from orders O
inner join Shippers S on S.ShipperID = o.ShipVia
group by ShipVia, CompanyName

-- 6. Nombre de livraisons r�alis�es par le livreur Speedy Express
-- dans chaque pays o� il a livr�
select O.shipcountry, count(orderid) NbLivraisons
from Orders O
inner join Shippers S on S.ShipperID = o.ShipVia
where S.CompanyName = 'Speedy Express'
group by O.shipcountry

-- 7. Montant des ventes r�alis�es pour chaque produit
-- (Pour les produits sans vente associ�e, le montant des ventes vaut 0)
select  P.ProductID, P.ProductName, isnull(sum (OD.unitPrice * OD.Quantity * (1 - Discount)), 0)
from Products P
left outer join Order_Details OD on P.ProductID = OD.ProductID
group by P.ProductID, P.ProductName

-- 8. Liste des commandes livr�es en 1998 (id, date de livraison) avec leurs sous-totaux,
-- tri�es par date de livraison
select O.OrderId, O.ShippedDate, sum(UnitPrice * Quantity * (1 - Discount))
 from orders O
inner join Order_Details OD on (O.OrderID = OD.OrderID)
where year(O.ShippedDate) = 1998
group by O.OrderId, O.ShippedDate
order by O.ShippedDate;

-- 9. Chiffre d'affaire r�alis� par chaque salari�
select E.EmployeeID, E.FirstName, E.LastName, sum(UnitPrice * Quantity * (1-Discount))
from Employees E
inner join Orders O on E.EmployeeID = O.EmployeeID
inner join Order_Details OD on O.OrderID = OD.OrderID
group by E.EmployeeID, E.FirstName, E.LastName
order by 1 

-- 10. Montant des ventes de chaque salari� pour chacun des pays
select E.EmployeeID, E.FirstName, E.LastName, O.shipcountry,
	 floor(sum(UnitPrice * Quantity * (1-Discount)))
from Employees E
inner join Orders O on E.EmployeeID = O.EmployeeID
inner join Order_Details OD on O.OrderID = OD.OrderID
group by E.EmployeeID, E.FirstName, E.LastName, O.shipcountry
order by 1 

-- 11. Chiffre d'affaire r�alis� pour chaque client fran�ais (m�me si = 0, et arrondi � l'entier <)
select C.CustomerID, C.CompanyName,
	isnull(FLOOR(sum(UnitPrice * Quantity * (1 - Discount))), 0) CA
 from Customers C
left outer join orders O on (O.CustomerID = C.CustomerID)
left outer join Order_Details OD on (O.OrderID = OD.OrderID)
where Country = 'France'
group by C.CustomerID, C.CompanyName
order by 2

-- 12. chiffre d'affaire par cat�gorie de produit et par trimestre sur l'ann�e 1997
select distinct C.CategoryName, 
    DATEPART(quarter, O.ShippedDate) as Trimestre,
    sum(OD.UnitPrice * OD.Quantity * (1 - OD.Discount)) as Ventes
from Categories C
inner join Products P on C.CategoryID = P.CategoryID
inner join Order_Details OD on P.ProductID = OD.ProductID
inner join Orders O on O.OrderID = OD.OrderID
where year(O.ShippedDate) = 1997
group by C.CategoryName, DATEPART(quarter, O.ShippedDate)
order by C.CategoryName, Trimestre
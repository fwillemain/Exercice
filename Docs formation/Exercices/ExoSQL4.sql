-- 1. Ins�rer un nouveau produit en sp�cifiant juste son nom
begin tran
insert into Products(ProductName) values ('Nutella')
commit

select * from Products

-- 2. Ins�rer un nouveau client fran�ais (pays = 'France') � votre nom
insert into Customers(CustomerID, CompanyName, ContactName, Country) values ('FLORI', 'Ferrero', 'Florian', 'France') 

select * from Customers

-- 3. Liste des r�gions et de leurs territoires (descriptions des r�gions et territoires)
select distinct R.RegionDescription, T.TerritoryDescription
from Territories T
inner join Region R on T.RegionID = R.RegionID

-- 4. Liste des livreurs (id et nom) qui ont livr� des produits au Canada
select distinct S.ShipperID, S.CompanyName
from Orders O
inner join Shippers S on O.ShipVia = S.ShipperID
where O.ShipCountry = 'Canada'

-- 5. Nombre total de livraisons r�alis�es par chaque livreur (id, nom)
select O.ShipVia, S.CompanyName, COUNT(*) NBbLivraisons
from Orders O
inner join Shippers S on O.ShipVia = S.ShipperID
group by O.ShipVia, S.CompanyName

-- 6. Nombre de livraisons r�alis�es par le livreur Speedy Express
-- dans chaque pays o� il a livr�
select S.CompanyName, O.ShipCountry, COUNT(*) NbLivraisons
from Orders O
inner join Shippers S on O.ShipVia = S.ShipperID
where S.CompanyName = 'Speedy Express'
group by S.CompanyName, O.ShipCountry

-- 7. Montant des ventes r�alis�es pour chaque produit
-- (Pour les produits sans vente associ�e, le montant des ventes vaut 0)
select P.ProductName, round(isnull(convert(money, (SUM(OD.Quantity * OD.UnitPrice * (1 - OD.Discount)))), 0), 2) as CA
from Products P
left outer join Order_Details OD on P.ProductID = OD.ProductID
group by P.ProductName


-- 8. Liste des commandes livr�es en 1998 (id, date de livraison) avec leurs sous-totaux,
-- tri�es par date de livraison
select O.OrderID, OD.ProductID, P.ProductName, convert(varchar, O.ShippedDate, 101) DateL, convert(money, OD.Quantity * OD.UnitPrice * (1 - OD.Discount)) as SousTot
from Orders O
inner join Order_Details OD on O.OrderID = OD.OrderID
inner join Products P on P.ProductID = OD.ProductID
where YEAR(O.ShippedDate) = 1998
order by 1, 2

-- 9. Chiffre d'affaire r�alis� par chaque salari�
select E.LastName, E.FirstName, round(convert(money, SUM(OD.Quantity * OD.UnitPrice * (1 - OD.Discount))), 2) as CA
from Employees E
inner join Orders O on E.EmployeeID = O.EmployeeID
inner join Order_Details OD on O.OrderID = OD.OrderID
group by E.LastName, E.FirstName
order by 3 desc

-- 10. Chiffre d'affaire r�alis� par chaque salari� pour chacune de ses r�gions
select E.LastName Nom, E.FirstName Prenom, isnull(O.ShipRegion, 'UNKNOWN') Region, round(convert(money, SUM(OD.Quantity * OD.UnitPrice * (1 - OD.Discount))),2) as CA
from Employees E
inner join Orders O on E.EmployeeID = O.EmployeeID
inner join Order_Details OD on O.OrderID = OD.OrderID
group by E.LastName, E.FirstName, O.ShipRegion
order by 1, 2 desc

-- 11. Chiffre d'affaire r�alis� pour chaque client fran�ais (m�me si = 0, et arrondi � l'entier <)
select C.CompanyName, floor(isnull(SUM(OD.Quantity * OD.UnitPrice * (1 - OD.Discount)), 0)) as CA
from Customers C
left outer join Orders O on C.CustomerID = O.CustomerID
left outer join Order_Details OD on OD.OrderID = O.OrderID
where C.Country like 'France'
group by C.CompanyName

-- 12. Chiffre d'affaire par cat�gorie de produit et par trimestre sur l'ann�e 1997
select C.CategoryName, DATEPART(Q, O.OrderDate) Trimestre97, round(convert(money, SUM(OD.Quantity * OD.UnitPrice * (1 - OD.Discount))), 2) as CA
from Categories C
inner join Products P on C.CategoryID = P.CategoryID
inner join Order_Details OD on P.ProductID = OD.ProductID
inner join Orders O on OD.OrderID = O.OrderID 
where YEAR(O.OrderDate) = 1997
group by C.CategoryName, DATEPART(Q, O.OrderDate)
order by 1, 2




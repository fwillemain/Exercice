-- 1. Insérer un nouveau produit en spécifiant juste son nom
begin tran
insert into Products(ProductName) values ('Nutella')
commit

select * from Products

-- 2. Insérer un nouveau client français (pays = 'France') à votre nom
insert into Customers(CustomerID, CompanyName, ContactName, Country) values ('FLORI', 'Ferrero', 'Florian', 'France') 

select * from Customers

-- 3. Liste des régions et de leurs territoires (descriptions des régions et territoires)
select distinct R.RegionDescription, T.TerritoryDescription
from Territories T
inner join Region R on T.RegionID = R.RegionID

-- 4. Liste des livreurs (id et nom) qui ont livré des produits au Canada
select distinct S.ShipperID, S.CompanyName
from Orders O
inner join Shippers S on O.ShipVia = S.ShipperID
where O.ShipCountry = 'Canada'

-- 5. Nombre total de livraisons réalisées par chaque livreur (id, nom)
select O.ShipVia, S.CompanyName, COUNT(*) NBbLivraisons
from Orders O
inner join Shippers S on O.ShipVia = S.ShipperID
group by O.ShipVia, S.CompanyName

-- 6. Nombre de livraisons réalisées par le livreur Speedy Express
-- dans chaque pays où il a livré
select S.CompanyName, O.ShipCountry, COUNT(*) NbLivraisons
from Orders O
inner join Shippers S on O.ShipVia = S.ShipperID
where S.CompanyName = 'Speedy Express'
group by S.CompanyName, O.ShipCountry

-- 7. Montant des ventes réalisées pour chaque produit
-- (Pour les produits sans vente associée, le montant des ventes vaut 0)
select P.ProductName, round(isnull(convert(money, (SUM(OD.Quantity * OD.UnitPrice * (1 - OD.Discount)))), 0), 2) as CA
from Products P
left outer join Order_Details OD on P.ProductID = OD.ProductID
group by P.ProductName


-- 8. Liste des commandes livrées en 1998 (id, date de livraison) avec leurs sous-totaux,
-- triées par date de livraison
select O.OrderID, OD.ProductID, P.ProductName, convert(varchar, O.ShippedDate, 101) DateL, convert(money, OD.Quantity * OD.UnitPrice * (1 - OD.Discount)) as SousTot
from Orders O
inner join Order_Details OD on O.OrderID = OD.OrderID
inner join Products P on P.ProductID = OD.ProductID
where YEAR(O.ShippedDate) = 1998
order by 1, 2

-- 9. Chiffre d'affaire réalisé par chaque salarié
select E.LastName, E.FirstName, round(convert(money, SUM(OD.Quantity * OD.UnitPrice * (1 - OD.Discount))), 2) as CA
from Employees E
inner join Orders O on E.EmployeeID = O.EmployeeID
inner join Order_Details OD on O.OrderID = OD.OrderID
group by E.LastName, E.FirstName
order by 3 desc

-- 10. Chiffre d'affaire réalisé par chaque salarié pour chacune de ses régions
select E.LastName Nom, E.FirstName Prenom, isnull(O.ShipRegion, 'UNKNOWN') Region, round(convert(money, SUM(OD.Quantity * OD.UnitPrice * (1 - OD.Discount))),2) as CA
from Employees E
inner join Orders O on E.EmployeeID = O.EmployeeID
inner join Order_Details OD on O.OrderID = OD.OrderID
group by E.LastName, E.FirstName, O.ShipRegion
order by 1, 2 desc

-- 11. Chiffre d'affaire réalisé pour chaque client français (même si = 0, et arrondi à l'entier <)
select C.CompanyName, floor(isnull(SUM(OD.Quantity * OD.UnitPrice * (1 - OD.Discount)), 0)) as CA
from Customers C
left outer join Orders O on C.CustomerID = O.CustomerID
left outer join Order_Details OD on OD.OrderID = O.OrderID
where C.Country like 'France'
group by C.CompanyName

-- 12. Chiffre d'affaire par catégorie de produit et par trimestre sur l'année 1997
select C.CategoryName, DATEPART(Q, O.OrderDate) Trimestre97, round(convert(money, SUM(OD.Quantity * OD.UnitPrice * (1 - OD.Discount))), 2) as CA
from Categories C
inner join Products P on C.CategoryID = P.CategoryID
inner join Order_Details OD on P.ProductID = OD.ProductID
inner join Orders O on OD.OrderID = O.OrderID 
where YEAR(O.OrderDate) = 1997
group by C.CategoryName, DATEPART(Q, O.OrderDate)
order by 1, 2




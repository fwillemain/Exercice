-- 1. Ins�rer un nouveau produit en sp�cifiant juste son nom
insert Products(ProductName)
values ('Pepito')
select * from Products

-- 2. Ins�rer un nouveau client fran�ais (pays = 'France') � votre nom
insert Customers(CustomerID, CompanyName, Country)
values ('MOI', 'Moi', 'France')
select * from Customers

-- 3. Liste des r�gions et de leurs territoires (descriptions des r�gions et territoires)
select distinct r.RegionDescription, t.TerritoryDescription
from Region r
inner join Territories t
on t.RegionID=r.RegionID

-- 4. Liste des livreurs (id et nom) qui ont livr� des produits au Canada
select distinct s.ShipperID, s.CompanyName, o.ShipCountry
from Shippers s
inner join Orders o
on o.ShipVia=s.ShipperID
where o.ShipCountry='Canada'

-- 5. Nombre total de livraisons r�alis�es par chaque livreur (id, nom)
select s.ShipperID, s.CompanyName, COUNT(o.OrderID)
from Shippers s
inner join Orders o
on o.ShipVia=s.ShipperID
group by s.ShipperID, s.CompanyName

-- 6. Nombre de livraisons r�alis�es par le livreur Speedy Express
-- dans chaque pays o� il a livr�

select shipCountry, COUNT(OrderID)
from Shippers a
inner join Orders b on a.ShipperID = b.ShipVia
where CompanyName='Speedy Express'
group by ShipCountry

-- 7. Montant des ventes r�alis�es pour chaque produit
-- (Pour les produits sans vente associ�e, le montant des ventes vaut 0)

select a.ProductName, isnull(sum(b.UnitPrice*Quantity*(1-Discount)), 0)
from Products a
left outer join Order_Details b on a.ProductID = b.ProductID
group by a.ProductName
order by a.ProductName


-- 8. Liste des commandes livr�es en 1998 (id, date de livraison) avec leurs sous-totaux,
-- tri�es par date de livraison

select distinct a.OrderID, ProductName, ShippedDate, b.UnitPrice*Quantity
from Orders a
inner join Order_Details b on a.OrderID = b.OrderID
inner join Products c on b.ProductID = c.ProductID
where YEAR(ShippedDate)='1998'
Order by ShippedDate


-- 9. Chiffre d'affaire r�alis� par chaque salari�

select sum(c.UnitPrice*Quantity*(1-Discount)), FirstName
from Employees a
inner join Orders b on b.EmployeeID = a.EmployeeID
inner join Order_Details c on c.OrderID = b.OrderID
group by Firstname, a.EmployeeID
order by a.EmployeeID desc

-- 10. Chiffre d'affaire r�alis� par chaque salari� pour chacun des pays

select FirstName, ShipCountry, sum(c.UnitPrice*Quantity*(1-Discount))
from Employees a
inner join Orders b on b.EmployeeID = a.EmployeeID
inner join Order_Details c on c.OrderID = b.OrderID
group by Firstname, a.EmployeeID, ShipCountry
order by a.EmployeeID desc, ShipCountry

-- 11. Chiffre d'affaire r�alis� pour chaque client fran�ais (m�me si = 0, et arrondi � l'entier <)

select Country, CompanyName, floor(sum(c.UnitPrice*Quantity*(1-Discount))) as CA
from Customers a
inner join Orders b on b.CustomerID = a.CustomerID
inner join Order_Details c on c.OrderID = b.OrderID
where Country='France'
Group by Country, CompanyName


-- 12. Chiffre d'affaire par cat�gorie de produit et par trimestre sur l'ann�e 1997

select sum(a.UnitPrice*Quantity*(1-Discount)) as CA, CategoryName, DATEPART(quarter, OrderDate)
from Order_Details a
inner join Products b on b.ProductID = a.ProductID
inner join Categories c on c.CategoryID = b.CategoryID
inner join Orders d on d.OrderID = a.OrderID
Where YEAR(OrderDate)='1997'
group by c.CategoryID, CategoryName, DATEPART(quarter, OrderDate)
/* Base Northwind - écrire les requêtes produisant les résultats demandés */
 
-- 1. Nombre de produits obsolètes
select COUNT(*)
from Products
where Discontinued =1

-- 2. Liste des produits (nom et prix) dont le prix est > la moyenne

select ProductName, UnitPrice
from Products
where UnitPrice> (select AVG(UnitPrice)from Products)
order by UnitPrice


-- 3. âge moyen des salariés à l'embauche

select avg(DATEDIFF(YEAR, BirthDate, HireDate))
from Employees

-- 4. Liste des commandes livrées en retard (id commande, id client, nb jours de retard)

select OrderID, CustomerID, DATEDIFF(DAY, ShippedDate, RequiredDate)
from Orders
Where DATEDIFF(DAY, ShippedDate, RequiredDate)< 0

-- 5. Liste des commandes passées pendant le week-end (id et jour de la semaine)

select OrderID, DATEPART(WEEKDAY,OrderDate)
from Orders
where (DATEPART(WEEKDAY,OrderDate))=1 or (DATEPART(WEEKDAY,OrderDate))=7


-- 6. Nombres de commandes par mois de l'année (c-à-d 12 lignes attendues)

select  MONTH(OrderDate)as Mois,COUNT(OrderID) as NbCommande
from Orders
group by MONTH(OrderDate)


-- 7. Mois de l'année durant lequel il y a eu le plus de commandes toutes années confondues
-- (mois et nombre total de commandes)

select Top (1)COUNT(*) as nbCommande, MONTH(OrderDate)as MoisCommande
from Orders
group by MONTH(OrderDate)
Order by nbCommande desc


-- 8. Délai de livraison moyen des commandes de l'année 1998

--select year(OrderDate)as année, AVG(DateDiff(day, OrderDate, ShippedDate))as délaisdelivraisonMoyen
--from Orders
--group by YEAR(OrderDate)
--having YEAR (OrderDate)=1998

select year(OrderDate)as année, AVG(DateDiff(day, OrderDate, ShippedDate))as délaisdelivraisonMoyen
from Orders
where YEAR(OrderDate) = 1998
group by year(OrderDate)


-- 9. Montant total de chaque commande, en tenant compte du % de réduction

select * from Order_Details
select orderId, SUM((unitPrice*Quantity)- (unitPrice*Quantity)*Discount)as MontantCommande
from Order_Details
group by OrderID
Order by OrderID

-- 10. Nombre de commandes par pays et par année

select COUNT(OrderID)as Commande, ShipCountry, YEAR (OrderDate)
from Orders
group by ShipCountry, year(OrderDate)
order by year(OrderDate)

-- 11. Délai de livraison moyen par pays, du plus grand au plus petit

select ShipCountry as pays, AVG(DateDiff(day, OrderDate, ShippedDate))as délaisdelivraisonMoyen
from Orders
group by ShipCountry
order by AVG(DateDiff(day, OrderDate, ShippedDate)) desc

-- 12. Liste des pays distincts dans lesquels ont été passées des commandes
select distinct ShipCountry
from Orders
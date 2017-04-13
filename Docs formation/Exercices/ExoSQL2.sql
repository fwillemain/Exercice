/* Base Northwind - écrire les requêtes produisant les résultats demandés */
 
-- 1. Nombre de produits obsolètes
select count(*)
from Products
where Discontinued = 1

-- 2. Liste des produits (nom et prix) dont le prix est > la moyenne
select ProductName, UnitPrice 
from Products
where UnitPrice > AVG(UnitPrice)

-- 3. âge moyen des salariés à l'embauche 

select AVG(DATEDIFF(year, BirthDate, HireDate) )
from Employees

-- 4. Liste des commandes livrées en retard (id commande, id client, nb jours de retard)
select OrderId, CustomerId, DATEDIFF(DAY, RequiredDate, ShippedDate) as NbJoursRetard
from Orders
where DATEDIFF(DAY, RequiredDate, ShippedDate) > 1

-- 5. Liste des commandes passées pendant le week-end (id et jour de la semaine)
select OrderID, DATEPART(WEEKDAY, OrderDate) as JourCom
from Orders
where DATEPART(WEEKDAY, OrderDate) in (1, 7)

-- 6. Nombres de commandes par mois de l'année (c-à-d 12 lignes attendues)
select MONTH(OrderDate) as Mois, COUNT(*) as NbComMois
from Orders
group by MONTH(OrderDate)
order by 1

-- 7. Mois de l'année durant lequel il y a eu le plus de commandes toutes années confondues
-- (mois et nombre total de commandes)
select top 1 COUNT(*) as NbCom
from Orders
group by MONTH(OrderDate) 
order by NbCom desc

-- 8. Délai de livraison moyen des commandes de l'année 1998
select AVG(DATEDIFF(Day, OrderDate, ShippedDate))
from Orders
where YEAR(OrderDate) = 1998

-- 9. Montant total de chaque commande, en tenant compte du % de réduction
select OrderId, SUM(Quantity * UnitPrice * (1 - Discount)) as MontantTotalReduit
from Order_Details
group by OrderID

-- 10. Nombre de commandes par pays et par année
select ShipCountry, YEAR(OrderDate) as AnnéeCom, Count(*) as NbCom
from Orders
group by ShipCountry, YEAR(OrderDate)

-- 11. Délai de livraison moyen par pays, du plus grand au plus petit
select ShipCountry, AVG(DATEDIFF(Day, OrderDate, ShippedDate)) as DélaiLivraisonMoyen
from Orders
group by ShipCountry
order by 2 desc

-- 12. Liste des pays distincts dans lesquels ont été passées des commandes
select distinct ShipCountry
from Orders
order by 1


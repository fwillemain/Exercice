-- 1. Nombre de produits obsolètes
select count(*)
from Products
where Discontinued = 1

-- 2. Liste des produits (nom et prix) dont le prix est > la moyenne
SELECT DISTINCT ProductName, UnitPrice  
FROM Products  
WHERE UnitPrice > (SELECT avg(UnitPrice) FROM Products)  
ORDER BY UnitPrice; 

-- 3. âge moyen des salariés à l'embauche 
select avg(datediff(year, BirthDate, hiredate))
from Employees

-- 4. Liste des commandes livrées en retard (id commande, id client, nb jours de retard)
select orderid, customerid, DATEDIFF(day, RequiredDate, ShippedDate)
 from orders
where RequiredDate < ShippedDate
order by 3

-- 5. Liste des commandes passées pendant le week-end (id et jour de la semaine)
select orderid, datepart(weekday, orderdate)
from orders
where datepart(weekday, orderdate) in (6, 7)

-- 6. Nombres de commandes par mois de l'année (c-à-d 12 lignes attendues)
select month(orderdate) as mois, count(OrderID) as NbCommandes
from orders
group by month(orderdate)
order by 1

-- 7. Mois de l'année durant lequel il y a eu le plus de commandes toutes années confondues
-- (mois et nombre total de commandes)
select top(1) month(orderdate) as mois, count(OrderID) as NbCommandes
from orders
group by month(orderdate)
order by NbCommandes desc

-- 8. Délai de livraison moyen des commandes de l'année 1998
select avg(DATEDIFF(day, OrderDate, ShippedDate))
from orders
where year(orderdate) = 1998

-- 9. Montant total de chaque commande, en tenant compte du % de réduction
select OrderID, 
    sum(UnitPrice * Quantity * (1 - Discount)) as Subtotal
from [order details]
group by OrderID
order by OrderID;

-- 10. Nombre de commandes par pays et par année
select shipcountry, year(orderdate), count(OrderID) as NbCommandes
from orders
group by shipcountry, year(orderdate)
order by 1, 2

-- 11. Délai de livraison moyen par pays, du plus grand au plus petit
select shipcountry, avg(DATEDIFF(day, OrderDate, ShippedDate))
from orders
group by ShipCountry
order by 2 desc

-- 12. Liste des pays distincts dans lesquels ont été passées des commandes
select distinct(shipcountry)
from orders
order by 1
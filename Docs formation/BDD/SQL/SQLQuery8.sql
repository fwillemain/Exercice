--Nombre de commandes par produits
select ProductID, SUM(Quantity)
from Order_Details
group by ProductID
Order by 2

--Top 10 des produit qui ont généré le plus de CA
select Top(10)sum (Quantity*UnitPrice) as CA
from Order_Details
group by ProductID
order by CA desc

--Nombre de commandes par pays et par ville
select ShipCountry, ShipCity, COUNT(*) as nbCommandes
from Orders
group by ShipCountry, ShipCity
order by 1, 2

--Nombre de commandes par apys et villes, uniquement pour les couples pays/villes avec plus de 30 commandes
select ShipCountry, ShipCity, COUNT(*) as nbCommandes
from Orders
group by ShipCountry, ShipCity
having COUNT(*) >= 30
order by 1, 2

select GETDATE()

select CONVERT(varchar,getdate(), 101)

select YEAR('2017-02-21')
select Month('2017-02-21')
select Day('2017-02-21')

Select DATEPART(WEEKDAY,GETDATE())

set language french

select EmployeeID, FirstName, datediff (year, BirthDate, GETDATE())
from Employees


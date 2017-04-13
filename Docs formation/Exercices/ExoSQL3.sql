-- 1. Nombre de salariés regroupés par la première lettre de leur nom
select LEFT(LastName, 1), Count(*)
from Employees
group by LEFT(LastName, 1)

-- 2. Compter le nombre d'espaces dans le nom de chaque produit
select ProductName, LEN(ProductName) - LEN(REPLACE(ProductName, ' ', '')) as NbEspaces
from Products

-- 3. Liste des mois qui n'ont aucune commande pour le produit 'Tofu'
select distinct MONTH(OrderDate), YEAR(OrderDate) 
from Orders 
where (LEFT(convert(nvarchar, OrderDate, 102), 7)) 
					not in (				
select distinct LEFT(convert(nvarchar, OrderDate, 102), 7)
from (Products P 
inner join Order_Details OD on P.ProductID = OD.ProductID
inner join Orders O on OD.OrderID = O.OrderID)
where ProductName = 'Tofu')
order by YEAR(OrderDate)

--group by MONTH(OrderDate), YEAR(OrderDate) à éviter si pas d'opération sur les éléments du group by car pas performant


-- 4. Produits qui ont fait l'objet de plus de 50 commandes (id du produit et nb commandes)
select ProductID, COUNT(*)
from Order_Details
group by ProductID
having COUNT(*) > 50

-- 5. Clients qui ont fait plus de 5 commandes au cours de l'année 1997 (id du client et nb commandes)
select CustomerID, COUNT(*) as NbCom1997
from Orders
where YEAR(OrderDate) = 1997
group by CustomerID
having COUNT(*)> 5

-- 6. Liste des employés qui ont au moins 2 supérieurs hiérarchiques
select LastName
from Employees, (select EmployeeID from Employees where ReportsTo is not null) as tmp
where ReportsTo = tmp.EmployeeID

-- ou 

select EmployeeID, ReportsTo
from Employees e
where(select ReportsTo from Employees where EmployeeID = e.ReportsTo) is not null
-- is not null sur les ReportsTo qui sont renvoyés
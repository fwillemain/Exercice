-- 1. Nombre de salariés regroupés par la première lettre de leur nom
select LEFT(LastName, 1), COUNT(*)
from Employees
group by LEFT(LastName, 1)

-- 2. Compter le nombre d'espaces dans le nom de chaque produit
select ProductName, (LEN(ProductName) - LEN(replace(ProductName, ' ', ''))) as nb_espaces
from Products

-- 3. Liste des mois qui n'ont aucune commande pour le produit 'Tofu'
-- On récupère l'id du produit Tofu
declare @pid int
select @pid = ProductID from Products where ProductName = 'Tofu'

select distinct left(convert(nvarchar, OrderDate, 102), 7)
from Orders
where left(convert(nvarchar, OrderDate, 102), 7) not in
	-- sous requête qui ramène les mois des commandes avec Tofu
	(select distinct left(convert(nvarchar, OrderDate, 102), 7)
	from Orders O
		inner join Order_Details OD on (O.OrderID = OD.OrderID)
	where ProductID = @pid)

-- 4. Produits qui ont fait l'objet de plus de 50 commandes (id du produit et nb commandes)
select ProductID, COUNT(OrderID)
from Order_Details
group by ProductID
having COUNT(OrderID) > 50

-- 5. Clients qui ont fait plus de 5 commandes au cours de l'année 1997 (id du client et nb commandes)
select CustomerID, COUNT(OrderID)
from Orders
where year(OrderDate) = 1997
group by CustomerID
having COUNT(OrderID) > 5

-- 6. Liste des employés qui ont au moins 2 supérieurs hiérarchiques
select EmployeeID, ReportsTo
from Employees e
where
(select ReportsTo from Employees where EmployeeID = e.ReportsTo) is not null


-- 1. Liste des clients (id, nom d'entreprise) qui n'ont jamais commandé un produit de la catégorie Condiments
select CustomerID, CompanyName
from Customers C
where not exists (
	select O.OrderID
	from Orders O
	inner join Order_Details OD on OD.OrderID = O.OrderID
	inner join Products P on OD.ProductID = P.ProductID
	where CategoryId = 2 and CustomerID = C.CustomerID
)
-- Etapes : on récupère toutes les commandes qui contiennent un produit de la catégorie 2
-- puis on récupère les clients pour lesquels le résultat précédente est vide (avec not exists)
-- le lien entre la requête principale et la sous-requête se fait sur le CustomerId

-- 2. Liste des pays pour lesquels il n'existe aucun fournisseur de produits de la catégorie Condiments
select distinct S.Country
from Suppliers S
where not exists(
	select P.ProductID
	from  Products P
	where P.SupplierID = S.SupplierID and P.CategoryID = 2
)

-- 3. Délai moyen de livraison des commandes de chaque livreur
select o.ShipVia, avg(DATEDIFF(day, o.OrderDate, o.ShippedDate)) 'Delai liv moyen'
from orders o
group by o.shipvia
order by 1

-- 4. Liste des commandes qui contiennent le produit le plus vendu, c'est à dire
-- dont la quantité totale vendue est la plus grande 
select o.OrderID, o.OrderDate
from Orders o
inner join Order_Details od on od.OrderID = o.OrderID
inner join 
(
	select top(1) SUM(Quantity) SOMME, ProductID
	from Order_Details
	group by ProductID
	order by 1 desc
) R on (R.ProductID = od.ProductID)

-- 5. Commandes comportant au moins un produit fourni par un fournisseur français
select distinct o.OrderID, o.OrderDate
from Order_Details od
inner join Products p on p.ProductID = od.ProductID
inner join Suppliers s on s.SupplierID = p.SupplierID
inner join Orders o on od.OrderID = o.OrderID
where s.Country = 'France'

-- 6. CA réalisé par chaque équipe représentée par son manager (une équipe = 1 manager + ses managés directs)
select ReportsTo as Manager, SUM(CA) as CA from
(
	(
		-- CA des salariés d'une même équipe, sans leur manager
		SELECT distinct E.ReportsTo, E.EmployeeID
				,FLOOR(SUM(Quantity * UnitPrice * (1-Discount)) OVER(PARTITION BY E.EmployeeID)) AS CA
		FROM Order_Details OD
		inner join Orders O on OD.OrderID = O.OrderID 
		inner join Employees E on O.EmployeeID = E.EmployeeID
		where ReportsTo is not null
	)
	UNION
	(
		-- CA des managers
		select MAN.EmployeeID, MAN.EmployeeID
				,FLOOR(SUM(Quantity * UnitPrice * (1-Discount)))
		FROM Order_Details OD
		inner join Orders O on OD.OrderID = O.OrderID 
		inner join Employees MAN on O.EmployeeID = MAN.EmployeeID
		where exists
		(select EmployeeID from Employees where ReportsTo = MAN.EmployeeID)
		group by MAN.EmployeeID
	)	
) R
group by ReportsTo

-- Solution plus élégante :
select emplo , SUM(ca)
from(
	select e1.ReportsTo mana, e1.ReportsTo emplo, SUM(od.Quantity*od.UnitPrice*(1-od.Discount)) ca
	from Employees e1
	inner join Orders o on o.EmployeeID=e1.EmployeeID
	inner join Order_Details od on od.OrderID=o.OrderID
	group by e1.ReportsTo
	union
	select e1.ReportsTo, e1.EmployeeID, SUM(od.Quantity*od.UnitPrice*(1-od.Discount))
	from Employees e1
	inner join Orders o on o.EmployeeID=e1.EmployeeID
	inner join Order_Details od on od.OrderID=o.OrderID
	group by e1.ReportsTo,e1.EmployeeID
	) emp
group by emplo
having COUNT(ca)>1
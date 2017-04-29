-- 1. Liste des clients (id, nom d'entreprise) qui n'ont jamais command� un produit de la cat�gorie Condiments
select CustomerID, CompanyName
from Customers C
where not exists (
	select O.OrderID
	from Orders O
	inner join Order_Details OD on OD.OrderID = O.OrderID
	inner join Products P on OD.ProductID = P.ProductID
	where CategoryId = 2 and CustomerID = C.CustomerID
)
-- Etapes : on r�cup�re toutes les commandes qui contiennent un produit de la cat�gorie 2
-- puis on r�cup�re les clients pour lesquels le r�sultat pr�c�dente est vide (avec not exists)
-- le lien entre la requ�te principale et la sous-requ�te se fait sur le CustomerId

-- 2. Liste des pays pour lesquels il n'existe aucun fournisseur de produits de la cat�gorie Condiments
select distinct S.Country
from Suppliers S
where not exists(
	select P.ProductID
	from  Products P
	where P.SupplierID = S.SupplierID and P.CategoryID = 2
)

-- 3. D�lai moyen de livraison des commandes de chaque livreur
select o.ShipVia, avg(DATEDIFF(day, o.OrderDate, o.ShippedDate)) 'Delai liv moyen'
from orders o
group by o.shipvia
order by 1

-- 4. Liste des commandes qui contiennent le produit le plus vendu, c'est � dire
-- dont la quantit� totale vendue est la plus grande 
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

-- 5. Commandes comportant au moins un produit fourni par un fournisseur fran�ais
select distinct o.OrderID, o.OrderDate
from Order_Details od
inner join Products p on p.ProductID = od.ProductID
inner join Suppliers s on s.SupplierID = p.SupplierID
inner join Orders o on od.OrderID = o.OrderID
where s.Country = 'France'

-- 6. CA r�alis� par chaque �quipe repr�sent�e par son manager (une �quipe = 1 manager + ses manag�s directs)
select ReportsTo as Manager, SUM(CA) as CA from
(
	(
		-- CA des salari�s d'une m�me �quipe, sans leur manager
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

-- Solution plus �l�gante :
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
-- 1. Nombre de salariés regroupés par la première lettre de leur nom

select LEFT (lastName,1 )as initiale, COUNT(*)as nbPersonne
from Employees
group by LEFT (lastName,1)

-- 2. Compter le nombre d'espaces dans le nom de chaque produit

select ProductName, (len (productname) - len(replace(ProductName,' ','')))
from Products
group by ProductName

-- 3. Liste des mois qui n'ont aucune commande pour le produit 'Tofu'

-- 4. Produits qui ont fait l'objet de plus de 50 commandes (id du produit et nb commandes)

select ProductID, COUNT(*)as nbCommande
from Order_Details
group by ProductID
having COUNT(*)>50


-- 5. Clients qui ont fait plus de 5 commandes au cours de l'année 1997 (id du client et nb commandes)

select CustomerID, COUNT(OrderID)as NbCommande
from Orders
where YEAR (OrderDate)=1997
group by CustomerID
having COUNT (*)> 5


-- 6. Liste des employés qui ont au moins 2 supérieurs hiérarchiques
select LastName, emp.EmployeeID
from (select EmployeeID
from Employees
where ReportsTo is not NULL) as tmp, Employees as emp
where emp.ReportsTo = tmp.employeeID

-- Jointure simple entre produits et cat�gries
-- La jointure se fait entre la cl� �trang�re de la 1�re table et la cl� primaire de la 2�me table
-- Cette requ�te permet de r�cup�rer en m�me temps le nom de chaque produit et celui de sa cat�gorie.
select P.ProductID, P.ProductName, C.CategoryID, C.CategoryName
from Products P
inner join Categories C on (P.CategoryID = C.CategoryID)

-- Cr�ation d'un nouveau produit sans cat�gorie associ�e
insert Products(ProductName) values ('Confiture')
-- La requ�te select pr�c�dente ne ram�ne pas ce nouveau produit
-- car son champ CategoryID vaut NULL

-- Si on veut r�cup�rer tous les produits, m�me ceux qui n'ont pas de cat�gorie,
-- il faut faire une jointure externe :
select P.ProductID, P.ProductName, C.CategoryID, C.CategoryName
from Products P
left outer join Categories C on (P.CategoryID = C.CategoryID)

-- La m�me requ�te en faisant la jointure dans l'autre sens :
select P.ProductID, P.ProductName, C.CategoryID, C.CategoryName
from Categories C
right outer join Products P on (P.CategoryID = C.CategoryID)

-- Jointures avec plusieurs tables
-- Cette requ�te ram�ne toutes les associations salari�s / territoires
select E.FirstName, E.LastName, T.TerritoryDescription
from EmployeeTerritories ET
inner join Employees E on (ET.EmployeeID = E.EmployeeID)
inner join Territories T on (ET.TerritoryID = T.TerritoryID)

-- Autre exemple avec jointures externes :
select P.ProductID, P.ProductName, C.CategoryID, C.CategoryName
from Products P
left outer join Categories C on (P.CategoryID = C.CategoryID)
left outer join Suppliers S on (P.SupplierID = s.SupplierID)
-- NB/ Les jointures externes sont � utiliser � bon escient, car
-- elles sont plus couteuses (moins performantes) que les jointures internes

-- sous-requetes
select R.Pays, R.NbVentes
from (
select shipcountry Pays, count(*) NbVentes
from Orders
group by ShipCountry
) R

-- Union
select CompanyName from Customers where country = 'France'
union
select CompanyName from Suppliers where country = 'France'

-- Intersection
select CompanyName from customers where Country = 'France'
intersect
select CompanyName from customers where CompanyName like '%monde%'

-- Merge

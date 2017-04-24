-- Jointure simple entre produits et catégries
-- La jointure se fait entre la clé étrangère de la 1ère table et la clé primaire de la 2ème table
-- Cette requête permet de récupérer en même temps le nom de chaque produit et celui de sa catégorie.
select P.ProductID, P.ProductName, C.CategoryID, C.CategoryName
from Products P
inner join Categories C on (P.CategoryID = C.CategoryID)

-- Création d'un nouveau produit sans catégorie associée
insert Products(ProductName) values ('Confiture')
-- La requête select précédente ne ramène pas ce nouveau produit
-- car son champ CategoryID vaut NULL

-- Si on veut récupérer tous les produits, même ceux qui n'ont pas de catégorie,
-- il faut faire une jointure externe :
select P.ProductID, P.ProductName, C.CategoryID, C.CategoryName
from Products P
left outer join Categories C on (P.CategoryID = C.CategoryID)

-- La même requête en faisant la jointure dans l'autre sens :
select P.ProductID, P.ProductName, C.CategoryID, C.CategoryName
from Categories C
right outer join Products P on (P.CategoryID = C.CategoryID)

-- Jointures avec plusieurs tables
-- Cette requête ramène toutes les associations salariés / territoires
select E.FirstName, E.LastName, T.TerritoryDescription
from EmployeeTerritories ET
inner join Employees E on (ET.EmployeeID = E.EmployeeID)
inner join Territories T on (ET.TerritoryID = T.TerritoryID)

-- Autre exemple avec jointures externes :
select P.ProductID, P.ProductName, C.CategoryID, C.CategoryName
from Products P
left outer join Categories C on (P.CategoryID = C.CategoryID)
left outer join Suppliers S on (P.SupplierID = s.SupplierID)
-- NB/ Les jointures externes sont à utiliser à bon escient, car
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

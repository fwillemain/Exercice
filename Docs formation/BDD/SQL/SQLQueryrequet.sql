--Permet d'afficher la liste de tous les employ�s avec le champs voulus
select EmployeeID, TitleOfCourtesy, FirstName, LastName, Country from Employees

--Permte d'afficher uniquement les dames et demoiselles
select EmployeeID, TitleOfCourtesy, FirstName, LastName 
from Employees
where TitleOfCourtesy in ('Ms.', 'Mrs.')

--Toutes les femmes aux USA
select EmployeeID, TitleOfCourtesy, FirstName, LastName, Country 
from Employees
where TitleOfCourtesy in ('Ms.', 'Mrs.') and Country = 'USA'

--Toutes les employ�es qui sont soit des femmes soit aux USA
select EmployeeID, TitleOfCourtesy, FirstName, LastName, Country 
from Employees
where TitleOfCourtesy in ('Ms.', 'Mrs.') or Country = 'USA'

--Personne qui n'a pas de superieur
select EmployeeID, TitleOfCourtesy, FirstName, LastName
from Employees
where ReportsTo is NULL

--tous les employ�e embauch� apr�s une date donn�e
select EmployeeID, TitleOfCourtesy, FirstName, LastName, HireDate, Country
from Employees
where HireDate >= '1994-01-01' and Country != 'USA'

--tous les employ�e embauch� en 1993
select EmployeeID, TitleOfCourtesy, FirstName, LastName, HireDate
from Employees
where HireDate between '1993-01-01' and '1993-12-31'

--tous les employ�e dont le nom commence par k
select EmployeeID, TitleOfCourtesy, FirstName, LastName
from Employees
where LastName like ('k%')

--tous les employ�e dont le nom contient un v
select EmployeeID, TitleOfCourtesy, FirstName, LastName
from Employees
where LastName like ('%v%')

--tous les employ�e dont la troisi�me lettre du nom contient un v
select EmployeeID, TitleOfCourtesy, FirstName, LastName
from Employees
where LastName like ('__v%')

--tous les employ�e dont le nom se termine par une voyelle
select EmployeeID, TitleOfCourtesy, FirstName, LastName
from Employees
where LastName like '%[aeiouy]'

--tous les employ�e dont le nom se termine par une consonne
select EmployeeID, TitleOfCourtesy, FirstName, LastName
from Employees
where LastName like '%[^aeiouy]'

--tous les employ�e tri� par nom de famille
select EmployeeID, TitleOfCourtesy, FirstName, LastName
from Employees
order by LastName

--tous les employ�e tri� par nom de famille(2)
select EmployeeID, TitleOfCourtesy, FirstName, LastName
from Employees
order by LastName desc

--tous les employ�e tri� par oays et ville (2)
select EmployeeID, TitleOfCourtesy, FirstName, LastName, Country, City
from Employees
order by Country,City

--tous les employ�e tri� par oays et ville (2)
select EmployeeID, TitleOfCourtesy, FirstName, LastName, Country, City
from Employees
order by 5,6

--tous les employ�e tri� par age (plus jeune au plus vieux)
select EmployeeID, TitleOfCourtesy, FirstName, LastName, BirthDate
from Employees
order by BirthDate desc

--tous les employ�e tri� par age (plus jeune au plus vieux) (les 3 plus jeunes)
select top(3) EmployeeID, TitleOfCourtesy, FirstName, LastName, BirthDate
from Employees
order by BirthDate desc

--Requete n�1
select ProductID, ProductName QuantityPerUnit
from Products
order by QuantityPerUnit Desc

--Requete n�2
select ProductID, ProductName
from Products
where Discontinued = 1

--requet n�3
select ProductID, UnitPrice
from Products
order by UnitPrice desc

--requet n�4
select ProductID,ProductName, UnitPrice
from Products
where UnitPrice <20 and Discontinued =0
order by UnitPrice desc

--Requet n�5
select ProductName, UnitPrice
from Products
where Discontinued =1 and UnitPrice between '15' and '25'

--Requet n�6
select Top(10) ProductID,ProductName, UnitPrice
from Products
order by UnitPrice desc

--Requet n�7 Liste des produits actifs (nom, nombres en stock et en cours de commande)
-- dont le nombre en stock est < nombre en cours de commande
select ProductName,UnitsInStock, UnitsOnOrder
from Products
where UnitsInStock < UnitsOnOrder and Discontinued =0


select * from Products


SELECT * from Employees
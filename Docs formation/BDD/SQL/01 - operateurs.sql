-- Requ�te simple pour r�cup�rer toutes les lignes de la table
-- Dans SSMS le r�sultat est affich�, mais si la requ�te est ex�cut�e dans une appli,
-- on peut r�cup�rer les lignes dans une collection d'objets ou dans un Dataset (objet sp�cialis�)
-- pour manipuler ensuite les donn�es dans l'appli
select EmployeeID, FirstName, LastName
from Employees

-- r�cup�ration des valeurs de tous les champs
select *
from Employees

--------------------------------------------------------
-- Filtrage
select *
from Employees
where TitleOfCourtesy = 'Ms.'

-- Filtrage sur plusieurs valeurs
select *
from Employees
where TitleOfCourtesy in ('Ms.', 'Mrs.')

-- Filtrage sur plusieurs crit�res diff�rents
select EmployeeID, TitleOfCourtesy, FirstName, LastName, Country
from Employees
where TitleOfCourtesy = 'Ms.' and Country = 'USA' 

select EmployeeID, TitleOfCourtesy, FirstName, LastName, Country
from Employees
where TitleOfCourtesy = 'Ms.' or Country = 'USA'

-- Filtrage sur la valeur NULL
select EmployeeID, FirstName, LastName
from Employees
where ReportsTo is null

--------------------------------------------------------------
-- Op�rateurs de comparaison (>=, !=, between...)
select EmployeeID, FirstName, LastName, HireDate
from Employees
where HireDate >= '1994-01-01'

select EmployeeID, FirstName, LastName, HireDate, Country
from Employees
where HireDate >= '1994-01-01' and Country != 'USA'

select EmployeeID, FirstName, LastName, HireDate, Country
from Employees
where HireDate between '1993-01-01' and '1993-12-31'

--------------------------------------------
-- Op�rateur like

-- salari�s dont le nom commence par K
select EmployeeID, FirstName, LastName
from Employees
where LastName like ('K%')

-- salari�s dont le nom contient un v
select EmployeeID, FirstName, LastName
from Employees
where LastName like ('%v%')

-- salari�s dont le nom se termine par une voyelle
select EmployeeID, FirstName, LastName
from Employees
where LastName like ('%[aeiouy]')

--------------------------------------------
-- Tri
select EmployeeID, FirstName, LastName
from Employees
order by LastName

select EmployeeID, FirstName, LastName
from Employees
order by LastName desc

select EmployeeID, FirstName, LastName, Country, City
from Employees
order by Country, City

select EmployeeID, FirstName, LastName, Country, City
from Employees
order by 4, 5 

-- les 3 salari�s les plus jeunes
select top(3) EmployeeID, lastname, BirthDate
from Employees
order by BirthDate desc
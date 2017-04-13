select EmployeeID, TitleOfCourtesy, LastName, FirstName from Employees

-- Toutes les salariées
select EmployeeID, TitleOfCourtesy, LastName, FirstName 
from Employees
where TitleOfCourtesy in ('Ms.', 'Mrs.')

-- Toutes les salariées aux USA
select EmployeeID, TitleOfCourtesy, LastName, FirstName, Country 
from Employees
where TitleOfCourtesy in ('Ms.', 'Mrs.') and Country = 'USA'

-- Tous les salariés qui n'ont pas de supérieur
select EmployeeID, TitleOfCourtesy, LastName, FirstName 
from Employees
where ReportsTo is NULL

-- Tous les salariés embauchés après une date donnée et aux USA
select EmployeeID, TitleOfCourtesy, LastName, FirstName, Country, HireDate
from Employees
where HireDate >= '1994-01-02' and Country != 'USA'

-- Tous les employés embauchés sur l'année 1993
select EmployeeID, TitleOfCourtesy, LastName, FirstName,  HireDate
from Employees
where HireDate  between '1993-01-01' and '1993-12-31'

-- Touts les salariés dont le nom commence par 'K'
select EmployeeID, TitleOfCourtesy, LastName, FirstName
from Employees
where LastName like 'K%' 

-- Tous les salariés dont la troisième lettre du nom est un 'V'
select EmployeeID, TitleOfCourtesy, LastName, FirstName
from Employees
where LastName like '__V%' 

-- Touts les salariés dont le nom fini par une voyelle'
select EmployeeID, TitleOfCourtesy, LastName, FirstName
from Employees
where LastName like '%[aeiouy]'

-- Touts les salariés dont le nom fini par une consonne'
select EmployeeID, TitleOfCourtesy, LastName, FirstName
from Employees
where LastName like '%[^aeiouy]'

-- Tous les salariés triés via leur nom
select EmployeeID, TitleOfCourtesy, LastName, FirstName
from Employees
order by LastName

-- Tous les salariés triés via leur nom inversé
select EmployeeID, TitleOfCourtesy, LastName, FirstName
from Employees
order by LastName desc

-- Tous les salariés triés via le pays et la ville
select EmployeeID, TitleOfCourtesy, LastName, FirstName, Country, City
from Employees
order by Country, City
-- Pareil
select EmployeeID, TitleOfCourtesy, LastName, FirstName, Country, City
from Employees
order by 5, 6

-- Les 3 salariés les plus jeunes
select top 3 EmployeeID, TitleOfCourtesy, LastName, FirstName, CONVERT(VARCHAR, BirthDate, 103) 
from Employees
order by BirthDate desc



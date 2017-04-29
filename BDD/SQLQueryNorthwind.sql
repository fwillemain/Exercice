select EmployeeID, TitleOfCourtesy, LastName, FirstName from Employees

-- Toutes les salari�es
select EmployeeID, TitleOfCourtesy, LastName, FirstName 
from Employees
where TitleOfCourtesy in ('Ms.', 'Mrs.')

-- Toutes les salari�es aux USA
select EmployeeID, TitleOfCourtesy, LastName, FirstName, Country 
from Employees
where TitleOfCourtesy in ('Ms.', 'Mrs.') and Country = 'USA'

-- Tous les salari�s qui n'ont pas de sup�rieur
select EmployeeID, TitleOfCourtesy, LastName, FirstName 
from Employees
where ReportsTo is NULL

-- Tous les salari�s embauch�s apr�s une date donn�e et aux USA
select EmployeeID, TitleOfCourtesy, LastName, FirstName, Country, HireDate
from Employees
where HireDate >= '1994-01-02' and Country != 'USA'

-- Tous les employ�s embauch�s sur l'ann�e 1993
select EmployeeID, TitleOfCourtesy, LastName, FirstName,  HireDate
from Employees
where HireDate  between '1993-01-01' and '1993-12-31'

-- Touts les salari�s dont le nom commence par 'K'
select EmployeeID, TitleOfCourtesy, LastName, FirstName
from Employees
where LastName like 'K%' 

-- Tous les salari�s dont la troisi�me lettre du nom est un 'V'
select EmployeeID, TitleOfCourtesy, LastName, FirstName
from Employees
where LastName like '__V%' 

-- Touts les salari�s dont le nom fini par une voyelle'
select EmployeeID, TitleOfCourtesy, LastName, FirstName
from Employees
where LastName like '%[aeiouy]'

-- Touts les salari�s dont le nom fini par une consonne'
select EmployeeID, TitleOfCourtesy, LastName, FirstName
from Employees
where LastName like '%[^aeiouy]'

-- Tous les salari�s tri�s via leur nom
select EmployeeID, TitleOfCourtesy, LastName, FirstName
from Employees
order by LastName

-- Tous les salari�s tri�s via leur nom invers�
select EmployeeID, TitleOfCourtesy, LastName, FirstName
from Employees
order by LastName desc

-- Tous les salari�s tri�s via le pays et la ville
select EmployeeID, TitleOfCourtesy, LastName, FirstName, Country, City
from Employees
order by Country, City
-- Pareil
select EmployeeID, TitleOfCourtesy, LastName, FirstName, Country, City
from Employees
order by 5, 6

-- Les 3 salari�s les plus jeunes
select top 3 EmployeeID, TitleOfCourtesy, LastName, FirstName, CONVERT(VARCHAR, BirthDate, 103) 
from Employees
order by BirthDate desc



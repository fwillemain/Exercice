-- Date et heure courante
select GETDATE() --SYSDATETIME()

-- Jour du mois
select day(getdate())

-- D�composition de la date du jour
declare @d datetime
set @d = getdate();
select day(@d) as jour, month(@d) as mois, year(@d) as ann�e

-- N� du jour de la semaine
select DATEPART(weekday, getdate())

-- Ann�e de naissance des salari�s
select employeeid, firstname, lastname, year(BirthDate) as Ann�eNaissance
from Employees

-- Age des salari�s
select employeeid, firstname, lastname, datediff(year, BirthDate, getdate()) as age
from Employees

-- Construction d'une date
select DATEFROMPARTS(2012, 02, 28)

-- Dernier jour du mois de la date pass�e en param�tre
select EOMONTH (getdate())
select EOMONTH(DATEFROMPARTS(2012, 02, 01))

-- Formatage de la date pour la France
-- Les formats sont les m�mes qu'en .net
select format(getdate(), 'G', 'fr')
select format(getdate(), 'd MMMM yyyy', 'fr')
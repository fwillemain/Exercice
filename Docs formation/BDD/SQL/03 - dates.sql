-- Date et heure courante
select GETDATE() --SYSDATETIME()

-- Jour du mois
select day(getdate())

-- Décomposition de la date du jour
declare @d datetime
set @d = getdate();
select day(@d) as jour, month(@d) as mois, year(@d) as année

-- N° du jour de la semaine
select DATEPART(weekday, getdate())

-- Année de naissance des salariés
select employeeid, firstname, lastname, year(BirthDate) as AnnéeNaissance
from Employees

-- Age des salariés
select employeeid, firstname, lastname, datediff(year, BirthDate, getdate()) as age
from Employees

-- Construction d'une date
select DATEFROMPARTS(2012, 02, 28)

-- Dernier jour du mois de la date passée en paramètre
select EOMONTH (getdate())
select EOMONTH(DATEFROMPARTS(2012, 02, 01))

-- Formatage de la date pour la France
-- Les formats sont les mêmes qu'en .net
select format(getdate(), 'G', 'fr')
select format(getdate(), 'd MMMM yyyy', 'fr')
-- Compter le nombre de caractères dans le nom de mes employés
select LastName, LEN(LastName)
from Employees

-- ToUpper()
select LastName, UPPER(LastName)
from Employees

-- 2 premières lettres des noms
select LastName, LEFT(LastName, 2)
from Employees

-- 2 dernières lettres des noms
select LastName, RIGHT(LastName, 2)
from Employees


select UPPER(LEFT(FirstName, 1) + LEFT(LastName, 2)) as Code, FirstName, LastName
from Employees

-- Extrait les 3 caractères à partir de la 2ème lettre
select SUBSTRING(LastName, 2, 3)
from Employees

-- Première position d'un caractère dans une chaine
select CHARINDEX('h', LastName, 0)
from Employees

-- Remplacer d'une sous-chaine à l'intérieur d'une chaine
select Title, REPLACE(Title, ' ', '_')
from Employees

-- Créer une chaine avec 3 z'6'
select REPLICATE('6', 3)
from Employees


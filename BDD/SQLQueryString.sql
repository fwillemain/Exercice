-- Compter le nombre de caract�res dans le nom de mes employ�s
select LastName, LEN(LastName)
from Employees

-- ToUpper()
select LastName, UPPER(LastName)
from Employees

-- 2 premi�res lettres des noms
select LastName, LEFT(LastName, 2)
from Employees

-- 2 derni�res lettres des noms
select LastName, RIGHT(LastName, 2)
from Employees


select UPPER(LEFT(FirstName, 1) + LEFT(LastName, 2)) as Code, FirstName, LastName
from Employees

-- Extrait les 3 caract�res � partir de la 2�me lettre
select SUBSTRING(LastName, 2, 3)
from Employees

-- Premi�re position d'un caract�re dans une chaine
select CHARINDEX('h', LastName, 0)
from Employees

-- Remplacer d'une sous-chaine � l'int�rieur d'une chaine
select Title, REPLACE(Title, ' ', '_')
from Employees

-- Cr�er une chaine avec 3 z'6'
select REPLICATE('6', 3)
from Employees


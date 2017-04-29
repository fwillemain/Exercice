-- Longeur d'une cha�ne
select firstname, len(firstname)
from Employees

-- Mise en minuscules, majuscules
select lower(firstname), upper(lastname)
from Employees

-- Cr�ation d'une cha�ne par r�plication de N caract�res 
select replicate('z', 5)

-- cr�ation d'un code � partir de la premi�re lettre du pr�nom
-- et des 2 premi�res lettre du nom (en majuscules)
select firstname, lastname,
left(firstname, 1) + left(upper(lastname), 2) as code
from Employees

-- position d'un caract�re dans une cha�ne
select charindex('h', LastName)
from Employees
where EmployeeID = 5

-- renvoie les 2 caract�res du nom � partir de l'indice 3
select substring(LastName, 3, 2)
 from Employees
where EmployeeID = 5

-- remplacement d'une sous-chaine par une autre dans une chaine
select EmployeeId, Lastname, replace(title, ' ', '_') 
from Employees


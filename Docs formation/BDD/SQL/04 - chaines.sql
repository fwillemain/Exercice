-- Longeur d'une chaîne
select firstname, len(firstname)
from Employees

-- Mise en minuscules, majuscules
select lower(firstname), upper(lastname)
from Employees

-- Création d'une chaîne par réplication de N caractères 
select replicate('z', 5)

-- création d'un code à partir de la première lettre du prénom
-- et des 2 premières lettre du nom (en majuscules)
select firstname, lastname,
left(firstname, 1) + left(upper(lastname), 2) as code
from Employees

-- position d'un caractère dans une chaîne
select charindex('h', LastName)
from Employees
where EmployeeID = 5

-- renvoie les 2 caractères du nom à partir de l'indice 3
select substring(LastName, 3, 2)
 from Employees
where EmployeeID = 5

-- remplacement d'une sous-chaine par une autre dans une chaine
select EmployeeId, Lastname, replace(title, ' ', '_') 
from Employees


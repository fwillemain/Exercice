--compter le nombre de lettre dans le noms des employés
select LastName, LEN(LastName)asNbCaractères
from Employees

select LastName, Upper(LastName)
from Employees

--2 première lettres du nom (right = les dernière)(Left=Les premières)
select LastName, RIGHT(LastName, 2)
from Employees

--Création d'un code constitué des deux 1ère lettre du prénom et des deux première lettre du nom
select LEFT(UPPER(FirstName), 2) + LEFT(UPPER(LastName), 2)
from Employees

--Extraction de caractère au milieu de la chaine
select SUBSTRING(Lastname, 2, 3)
from Employees

--Position d'un caractère dans une chaine
select CHARINDEX('h', lastname)
from Employees

-- Remplacement d'une sous-chaine à l'interieur d'une chaine
select LastName, REPLACE(title, ' ', '_')
from Employees

select isnull(DATEDIFF(day, OrderDate, ShippedDate), 30)
from Orders

select OrderID, ShippedDate
From Orders
Where ShippedDate is not null

select CAST('12.56' as money)
select Convert(money, '12.56')

declare @ident as uniqueidentifier
Select @ident = NEWID()

 /*
   _
 ('_') 
 \ | /
  ---
  / \
  
  
  */
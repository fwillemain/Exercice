--compter le nombre de lettre dans le noms des employ�s
select LastName, LEN(LastName)asNbCaract�res
from Employees

select LastName, Upper(LastName)
from Employees

--2 premi�re lettres du nom (right = les derni�re)(Left=Les premi�res)
select LastName, RIGHT(LastName, 2)
from Employees

--Cr�ation d'un code constitu� des deux 1�re lettre du pr�nom et des deux premi�re lettre du nom
select LEFT(UPPER(FirstName), 2) + LEFT(UPPER(LastName), 2)
from Employees

--Extraction de caract�re au milieu de la chaine
select SUBSTRING(Lastname, 2, 3)
from Employees

--Position d'un caract�re dans une chaine
select CHARINDEX('h', lastname)
from Employees

-- Remplacement d'une sous-chaine � l'interieur d'une chaine
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
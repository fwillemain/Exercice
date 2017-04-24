-- 1. Cr�er des variables pour stocker vos pr�nom, nom, date de naissance et age
-- puis afficher � l'�cran la phrase ci-dessous en utilisant ces variables :
-- 'Je m'appelle Luc Arnes, je suis n� le 03 d�c. 2000 et j'ai 17 ans'
declare @nom nvarchar(40) = 'Willemain'
declare @prenom nvarchar(40) = 'Florian'
declare @datenaiss date = '1986-10-13'
declare @age int = floor(datediff(day, @datenaiss, getdate())/365.25)

print 'Je m''appelle ' + @prenom + ' ' + @nom + ', je suis n� le ' + 
		convert(nvarchar, @datenaiss, 106) + ' et j''ai ' + 
		convert(nvarchar, @age) + ' ans.'

-- 2. Cr�er une variable de type table avec cl� primaire, permettant de r�cup�rer
-- les id et date de commandes
-- Remplir cette table avec une requ�te
-- Puis faire une requ�te permettant de r�cup�rer les clients qui ont pass� ces commandes 
declare @commande table
(
	Id int primary key,
	DateCom date,
	IdClient char(5)
)

insert @commande(Id, DateCom, IdClient)
select OrderID, OrderDate, CustomerID
from Orders

--select IdClient
--from @commande

-- 3. S'il existe parmi les clients pr�c�dents, des clients dont le code postal n'est pas renseign�,
-- afficher � l'�cran � l'�cran un message d'alerte avec le nombre de clients concern�s
-- sinon, afficher le message 'Code postaux OK'

declare @cpt int = (select distinct Count(*)
		from Customers
		where PostalCode is null)
		
if @cpt > 0
	print 'Attention! ' + convert(nvarchar, @cpt) + ' clients n''ont pas de code postal renseign�!' 
else
	print 'Code postaux OK'

-- 4. Faire une requ�te renvoyant le nombre de clients d'Am�rique du nord, d'Am�rique du sud
-- et des autres continents


select R.Continent, COUNT(*)
from (
	select distinct CustomerID, Country, 
		(case
			when Country in ('USA', 'Canada') then 'Am�rique du nord'
			when Country in ('Mexico', 'Argentina', 'Brazil', 'Venezuela') then 'Am�rique du sud'
			else 'autre'
		end ) Continent
		from Customers) R
group by R.Continent

select distinct CustomerID from Customers

-- 5. Noter la quantit� en stock et le prix des produits d'id 72, 73 et 74
-- Augmenter les prix de tous les produits, selon leur tranche de quantit� en stock :
--   * Moins de 10 : + 20%
--   * de 10 � 99 : + 10%
--   * 100 ou plus : + 3%
-- V�rifier les prix de

begin tran
update Products set UnitPrice = (
	case
		when UnitsInStock < 10 then UnitPrice * 1.2
		when UnitsInStock > 9 and UnitsInStock < 100 then UnitPrice * 1.1
		else UnitPrice * 1.03
	end )
rollback

select * from Products
where ProductID between 72 and 74


-- 6. Classer les salari�s selon 4 tranches de chiffre d'affaire r�alis�
-- Affecter les salari�s de chaque tranche � une r�gion diff�rente
-- NB/ Dans chaque r�gion, ils seront tous affect�s � un territoire choisi arbitrairement
GO
declare @EmployeeCA table (
	EmployeeID int primary key, 
	CA real
) 

insert @EmployeeCA select distinct O.EmployeeID, 
							SUM(OD.Quantity * OD.UnitPrice * (1 - OD.Discount)) over(partition by O.EmployeeID)
from Orders O
	inner join Order_Details OD on O.OrderID = OD.OrderID


begin tran
delete from EmployeeTerritories

insert EmployeeTerritories(EmployeeID, TerritoryID) 
select EmployeeID,
	case
		when CA < 30000 then '01581'
		when CA < 70000 then '80202'
		when CA < 125000 then '44122'
		else '29202'
	end
from @EmployeeCA
GO

rollback

select * from EmployeeTerritories


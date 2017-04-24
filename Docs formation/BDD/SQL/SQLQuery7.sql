select COUNT(*)
from Order_Details
where ProductID = 5

--Nombre total d'examplaires command�s pour le produit 5
select SUM(Quantity)
from Order_Details
where ProductID = 5

--CA g�n�r� par le produit (floor et ceiling arrondie)
select floor (SUM(Quantity*UnitPrice))
from Order_Details
where ProductID = 5

select ceiling (SUM(Quantity*UnitPrice))
from Order_Details
where ProductID = 5

--Moyenne des quantit�s command�es pour l'article 5
select avg(Quantity)
from Order_Details
where ProductID = 5

--Prix de la ligne de commande la plus cher
select MAX(Quantity*UnitPrice)
from Order_Details

-- Nombre de produits diff�rents command�s
select count (distinct productID)
from Order_Details order by 1

--Frais de livraison moyens des commandes
select AVG(Freight)
from Orders

--
select OrderID, customerID, Freight
from Orders
where Freight > (select AVG(Freight) from Orders)
Order by Freight

--D�claration d'une variable
--declare @moy money
--select @moy = ...........
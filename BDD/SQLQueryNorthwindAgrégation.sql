-- Calculer le nombre de lignes o� Product Id = 5
select count(*)
from Order_Details
where ProductID = 5

-- Calculer la somme de toutes les quantit�s command�es du produit 5
select sum(Quantity)
from Order_Details
where ProductID = 5

-- Le chiffre d'affaire g�n�r� par le produit 5 (arrondi � l'entier inf�rieur)
select floor(sum(Quantity * UnitPrice))
from Order_Details
where ProductID = 5
-- ceiling pour l'entier sup�rieur

-- Moyenne des quantit�s command�es du produit 5
select avg(Quantity)
from Order_Details
where ProductID = 5

-- Prix de la ligne de commande la plus ch�re
select max(Quantity * UnitPrice)
from Order_Details

-- Tous les produits distincts command�s
select distinct ProductID
from Order_Details
order by 1

-- Le nombre de produits diff�rents command�s
select count(distinct ProductID)
from Order_Details

-- Les frais de livraison moyen des commandes
select AVG(Freight)
from Orders

-- Les livraisons dont les frais de livraison sont sup � la moyenne
declare @avg_freight money
select @avg_freight = AVG(Freight) from Orders

select OrderID, CustomerID, Freight
from Orders
where Freight > @avg_freight
order by Freight

-- Le nombre de commande par produit
select ProductId, count(*) as NbrCom
from Order_Details
group by ProductID

-- Le nombre total d'exemplaire command� par produit tri� par total
select ProductId, sum(Quantity)
from Order_Details
group by ProductID
order by 2

-- Le top 10 des produits qui ont g�n�r� le plus de chiffre d'affaire
select top 10 ProductId, sum(Quantity * UnitPrice) as CA
from Order_Details
group by ProductID
order by CA desc

-- Le nombre de commandes par pays et ville
select ShipCountry, ShipCity, COUNT(*) as NbCom
from Orders
group by ShipCountry, ShipCity
order by 1, 2

-- Le nombre de commandes par pays et ville 
-- uniquement pour les lignes qui ont plus de 30 commandes
select ShipCountry, ShipCity, COUNT(*) as NbCom
from Orders
group by ShipCountry, ShipCity
having COUNT(*) >= 30 -- Toujours apr�s un groupe by
order by 1, 2


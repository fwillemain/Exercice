-- Calculer le nombre de lignes où Product Id = 5
select count(*)
from Order_Details
where ProductID = 5

-- Calculer la somme de toutes les quantités commandées du produit 5
select sum(Quantity)
from Order_Details
where ProductID = 5

-- Le chiffre d'affaire généré par le produit 5 (arrondi à l'entier inférieur)
select floor(sum(Quantity * UnitPrice))
from Order_Details
where ProductID = 5
-- ceiling pour l'entier supérieur

-- Moyenne des quantités commandées du produit 5
select avg(Quantity)
from Order_Details
where ProductID = 5

-- Prix de la ligne de commande la plus chère
select max(Quantity * UnitPrice)
from Order_Details

-- Tous les produits distincts commandés
select distinct ProductID
from Order_Details
order by 1

-- Le nombre de produits différents commandés
select count(distinct ProductID)
from Order_Details

-- Les frais de livraison moyen des commandes
select AVG(Freight)
from Orders

-- Les livraisons dont les frais de livraison sont sup à la moyenne
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

-- Le nombre total d'exemplaire commandé par produit trié par total
select ProductId, sum(Quantity)
from Order_Details
group by ProductID
order by 2

-- Le top 10 des produits qui ont généré le plus de chiffre d'affaire
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
having COUNT(*) >= 30 -- Toujours après un groupe by
order by 1, 2


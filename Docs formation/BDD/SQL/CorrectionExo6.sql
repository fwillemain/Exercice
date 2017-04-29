-- 1. Liste des commandes contenant au moins un produit de la cat�gorie 7
-- Faire cette requ�te de 2 fa�ons diff�rentes
select O.orderid, O.CustomerID
from Orders O where exists(
	select OD.ProductID
	from Order_Details OD
	inner join Products P on OD.ProductID = P.ProductID
	where P.CategoryID = 7 and OD.OrderID = O.OrderId
	)
order by OrderID

-- La requ�te ci-dessous est plus performante
-- Le distinct est n�cessaire, car une m�me commande peut contenir
-- plusieurs produits de la m�me cat�gorie
select distinct O.OrderID, O.CustomerID
from Order_Details OD
inner join Products P on OD.ProductID = P.ProductID
inner join Orders O on OD.OrderID = O.OrderID
where P.CategoryID = 7

-- 2. Id des commandes qui contiennent plusieurs lignes de produits de m�me cat�gorie
-- (Faire la requ�te de 2 fa�ons diff�rentes, dont l'une qui utilise OVER)
select distinct OrderId
from (
	select OrderID, P.CategoryID, count(*) nbLignes
	from Order_Details OD
	inner join Products P on OD.ProductID = P.ProductID
	group by OrderID, P.CategoryID
	having count(*) > 1
) R

select distinct OrderID from (
SELECT OrderID
	   ,count(*) OVER(PARTITION BY OD.OrderId, P.CategoryId) as NbLignes
from Order_Details OD
	inner join Products P on OD.ProductID = P.ProductID
) R
where NbLignes > 1

-- Solution la plus simple
select distinct OrderID
from Order_Details OD
inner join Products P on OD.ProductID = P.ProductID
group by OrderID, P.CategoryID
having count(*) > 1
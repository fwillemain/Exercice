-------------- 
-- 1. Liste des produits avec leur quantité par unité
select productname, QuantityPerUnit
from Products

-- 2. Liste des produits (id et nom) qui sont obsolètes
select ProductID, ProductName
 from Products where Discontinued = 1

-- 3. Liste des produits (noms et prix) triés par prix décroissant
 SELECT ProductName, UnitPrice   
FROM Products   
ORDER BY UnitPrice DESC;

-- 4. Liste des produits (id, nom et prix) qui coutent moins de $20
-- et qui ne sont pas obsolètes (triés du plus cher au moins cher)
SELECT ProductID, ProductName, UnitPrice  
FROM Products  
WHERE (UnitPrice<20 AND Discontinued=0)  
ORDER BY UnitPrice DESC; 

-- 5. Liste des produits (nom et prix) non obsolètes compris entre $15 et $25
SELECT ProductName, UnitPrice  
FROM Products  
WHERE (UnitPrice between 15 and 25)

-- 6. Liste des 10 produits les plus chers (id, nom et prix)
select top(10) ProductID, ProductName, unitprice
from Products
order by UnitPrice desc

-- 7. liste des produits actifs (nom, nombres en stock et en cours de commande)
-- dont le nombre en stock est < nombre en cours de commande
SELECT ProductName,  UnitsOnOrder , UnitsInStock  
FROM Products  
WHERE Discontinued=0 AND UnitsInStock < UnitsOnOrder; 

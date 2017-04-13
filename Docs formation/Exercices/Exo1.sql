/* Base Northwind - écrire les requêtes produisant les résultats demandés */
 
-- 1. Liste des produits avec leur quantité par unité
select ProductName, QuantityPerUnit  from Products

-- 2. Liste des produits (id et nom) qui sont obsolètes
select ProductID, ProductName 
from Products
where Discontinued = 1

-- 3. Liste des produits (noms et prix) triés par prix décroissant
select ProductName, UnitPrice
from Products
order by UnitPrice desc

-- 4. Liste des produits (id, nom et prix) qui coutent moins de $20
-- et qui ne sont pas obsolètes (triés du plus cher au moins cher)
select ProductID, ProductName, UnitPrice
from Products
where UnitPrice < 20 and Discontinued != 1
order by UnitPrice desc

-- 5. Liste des produits (nom et prix) non obsolètes compris entre $15 et $25
select ProductName, UnitPrice
from Products
where Discontinued != 1 and UnitPrice between 15 and 25

-- 6. Liste des 10 produits les plus chers (id, nom et prix)
select top 10 ProductID, ProductName, UnitPrice
from Products
order by UnitPrice desc

-- 7. Liste des produits actifs (nom, nombres en stock et en cours de commande)
-- dont le nombre en stock est < nombre en cours de commande
select ProductName, UnitsInStock, UnitsOnOrder
from Products
where UnitsInStock < UnitsOnOrder and Discontinued = 0



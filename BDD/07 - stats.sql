------------------ EXISTS -----------------------------
-- Salariés qui sont managers
select * from Employees E
where exists
(select EmployeeID from Employees where ReportsTo = E.EmployeeID)

-- Salariés qui ne sont pas managers
select * from Employees E
where not exists
(select EmployeeID from Employees where ReportsTo = E.EmployeeID)

------------------ OVER -----------------------------
-- Permet entre autres de faire des calculs d'agrégat sur chaque ligne

-- Lignes de la commande 10248 avec leurs montants
-- et le pourcentage de ces montants par rapport au total de la commande 
SELECT ProductID
		,Quantity * UnitPrice as Montant
	    ,Quantity * UnitPrice /
			(select SUM(OD.Quantity * OD.UnitPrice)
			from Order_Details OD
			where OD.OrderID = 10248) AS [% montant commande]  
FROM Order_Details
WHERE OrderID = 10248

-- Même résultat avec OVER :
SELECT ProductID
		,Quantity * UnitPrice as Montant
	    ,Quantity * UnitPrice * 100 /
		(SUM(Quantity * UnitPrice) OVER(PARTITION BY OrderID)) AS [% montant commande]  
FROM Order_Details
WHERE OrderID = 10248;  

-- Lignes de la commande 10248 avec leurs montants, leur quantités de produits
-- et les pourcentages de ces montants et quantités par rapport au total de la commande 
SELECT ProductID
		,Quantity * UnitPrice as Montant
	    ,Quantity * UnitPrice * 100 /
		SUM(Quantity * UnitPrice) OVER(PARTITION BY OrderID) AS [% montant commande]
		,Quantity as Quantité
		,Quantity * 100.0 / SUM(Quantity) OVER(PARTITION BY OrderID) AS [% qté totale]  
FROM Order_Details
WHERE OrderID = 10248; 

------------------------- PIVOT ---------------------------
-- Nombre de produits par catégorie
select P.CategoryID, count(ProductID) NbProduits
from Products P
group by P.CategoryID

-- Même résultat affiché en ligne
select [1],[2],[3],[4],[5],[6],[7],[8]
from (
	select CategoryID, ProductID from Products
) as Source
pivot (
	count(ProductId)
	for CategoryID in ([1],[2],[3],[4],[5],[6],[7],[8])
) as ProdParCat

-- Nombre de produits de chaque catégorie pour chaque fournisseur
select ProdParCat.CompanyName, [1],[2],[3],[4],[5],[6],[7],[8]
from (
	select CategoryID, ProductID, S.SupplierID, S.CompanyName
	from Products P
	inner join Suppliers S on P.SupplierID = S.SupplierID
) as Source
pivot (
	count(ProductId)
	for CategoryID in ([1],[2],[3],[4],[5],[6],[7],[8])
) as ProdParCat
inner join Suppliers S on S.SupplierID = ProdParCat.SupplierID

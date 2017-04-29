
-- 1. Nombre d'entreprises par pays et par type (client ou fournisseur)
--Voir correction

select country, 'supplier' as type, Count(SupplierID)as NombredeFournisseurs
from Suppliers
group by Country
union
select country, 'costumer' as type, Count(CustomerID)as Nombredeclient
From Customers
group by Country



-- 2. Cr�er une table temporaire #Produits avec les champs (id, nom, prix unitaire, qt� en stock)
-- Ins�rer 5 produits dans cette table, dont 2 qui ont des Id d�j� pr�sents dans la table Products, et 3 nouveaux
-- Faire une requ�te qui met � jour la table Products � partir de la table #Produits, en :
-- * mettant � jour le nom, le prix unitaire et la qt� en stock si l'Id du produit existe d�j�
-- * ajoutant les produits qui n'existent pas d�j�

CREATE TABLE #Produits (
ID int,
ProductName nvarchar(40),
UnitPrice money,
UnitsInStock smallint)


insert #Produits (ID, ProductName, UnitPrice, UnitsInStock) values
(1, 'Truc', 10, 50),
(2, 'bidule', 20, 60),
(80,'machin',30, 70),
(90,'Muche',40,80),
(100,'chouette',50,90)

begin tran

MERGE Products AS Cible
USING (SELECT ID, ProductName, UnitPrice, UnitsInStock FROM #Produits) AS Source
ON (Cible.ProductID = Source.ID)
WHEN MATCHED THEN
    UPDATE SET Cible.ProductName = Source.ProductName, Cible.UnitPrice = Source.UnitPrice, Cible.UnitsInStock = Source.UnitsInStock
WHEN NOT MATCHED BY TARGET THEN
    INSERT (ProductName, UnitPrice, UnitsInStock)
    VALUES (Source.ProductName, Source.UnitPrice, source.UnitsInStock)
OUTPUT $action, Inserted.*;


select * from #Produits


-- 3. Supprimer les lignes de commandes qui portent sur des produits
-- livr�s par le fournisseur 'Ma maison'
-- (A faire dans une transaction pour pouvoir annuler la suppresion)

begin tran

delete Order_Details from Order_Details a
inner join Products b on a.productID = b.ProductID
inner join Suppliers c on b.SupplierID = c.SupplierID
where CompanyName='Ma maison'



rollback


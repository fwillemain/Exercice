-- 1. Nombre d'entreprises par pays et par type (client ou fournisseur)
select Country, 'C' Kind, count(*) Nb from Customers group by country 
union
select Country, 'S', count(*) from Suppliers group by country 

-- select v.Country, v.Kind, count(Name) as Nb
-- from (
-- select 'C' as Kind, Country, CompanyName as Name from Customers
-- union
-- select 'S' as Kind, Country, CompanyName as Name from Suppliers
-- ) v
-- group by Kind, country

-- 2. Créer une table temporaire #Produits avec les champs (id, nom, prix unitaire, qté en stock)
-- Insérer 5 produits dans cette table, dont 2 qui ont des Id déjà présents dans la table Products, et 3 nouveaux
-- Faire une requête qui met à jour la table Products à partir de la table #Produits, en :
-- * mettant à jour le nom, le prix unitaire et la qté en stock si l'Id du produit existe déjà
-- * ajoutant les produits qui n'existent pas déjà
select * from Products order by ProductID

CREATE TABLE #SaisieProduit (
ProdId int,
Nom nvarchar(40),
PU money,
PU money,
Stock smallint,
CONSTRAINT SaisieProduit_PK PRIMARY KEY(ProdId)
);

insert #SaisieProduit (ProdId, Nom, PU, Stock) values
(76, 'Boisson gazeuse', 5.49, 20),
(77, 'Paquet de gateaux', 10.00, 40),
(81, 'Nouveau Produit 1', 4.60, 100),
(82, 'Nouveau Produit 2', 19.90, 100),
(83, 'Nouveau Produit 3', 35.50, 100)

begin tran
MERGE Products AS Cible
USING (SELECT ProdId, Nom, PU, Stock FROM #SaisieProduit) AS Source
ON (Cible.ProductId = Source.ProdId)
WHEN MATCHED THEN
    UPDATE SET
    Cible.ProductName = Source.Nom,
    Cible.UnitPrice = Source.PU,
    Cible.UnitsInStock = Source.Stock
WHEN NOT MATCHED BY TARGET THEN
    INSERT (ProductName, UnitPrice, UnitsInStock) -- Le productId est en auto-incrément
    VALUES (Source.Nom, Source.PU, Source.Stock)
OUTPUT $action, Inserted.*; 
rollback tran

drop table #SaisieProduit

-- 3. Supprimer les lignes de commandes qui portent sur des produits
-- livrés par le fournisseur 'Ma maison'
-- (A faire dans une transaction pour pouvoir annuler la suppresion)
begin tran
select COUNT(*) from Order_Details

delete Order_Details
from Order_Details OD
inner join Products P on P.ProductID = OD.ProductID
inner join Suppliers S on S.SupplierId = P.SupplierID 
where S.CompanyName = 'Ma maison'

select COUNT(*) from Order_Details
rollback
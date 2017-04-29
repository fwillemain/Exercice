-- isnull : montrer la diff�rence entre les 2 requ�tes suivantes
select datediff(day, orderdate, ShippedDate)
from orders

select isnull(datediff(day, orderdate, ShippedDate), 30)
from orders

-- Cast et convert
select CAST('2017-02-29' as date)	-- Plante

-- G�n�ration d'un identifiant unique global
select newid()

-- Table temporaire cr��e � partir d'une requ�te
select CustomerID, CompanyName, City, Country
into #CoordClient
from Customers
-- Suppprimer la table lorsqu'elle n'est plus utile
drop table #CoordClient


-- CTE
;with ClientFrance as (
select CustomerID, CompanyName, City, Country
from Customers
)
select CompanyName from ClientFrance where City = 'Paris'

-- Update de masse
-- Correction des prix des lignes de commandes qui font r�f�rence
-- � des produits obsol�tes
update Order_Details
set UnitPrice = P.UnitPrice
from Order_Details OD
inner join Products P on P.ProductID = OD.ProductID 
where Discontinued = 1

-- Merge pour faire de la MAJ si les donn�es existent d�j� dans la table
-- et de l'insertion sinon
select * from Territories order by TerritoryID

drop table #SaisieTerritoire

CREATE TABLE #SaisieTerritoire (
TerId nvarchar(20),
TerDesc nvarchar(50),
RegionId int,
CONSTRAINT SaisieTerritoire_PK PRIMARY KEY(TerId)
);

insert #SaisieTerritoire (TerId, TerDesc, RegionId) values
('98052', 'Beauvais', 1),
('98104', 'Amiens', 1),
('99001', 'Nouveau territoire 1', 1),
('99002', 'Nouveau territoire 2', 1),
('99003', 'Nouveau territoire 3', 1)

MERGE Territories AS Cible
USING (SELECT TerId, TerDesc, RegionId FROM #SaisieTerritoire) AS Source
ON (Cible.TerritoryId = Source.TerId)
WHEN MATCHED THEN
    UPDATE SET Cible.TerritoryDescription = Source.TerDesc, Cible.RegionId = Source.RegionId
WHEN NOT MATCHED BY TARGET THEN
    INSERT (TerritoryId, TerritoryDescription, RegionId)
    VALUES (Source.TerId, Source.TerDesc, Source.RegionId)
OUTPUT $action, Inserted.*; 


--------- instructions apparues apr�s SQL Server 2008 --------------

-- iif
select orderid, iif(ShippedDate <= RequiredDate, 'OK', 'Retard')
from Orders
where ShipCountry = 'France'

-- choose
select distinct categoryid FROM Categories; 
SELECT CategoryID, CHOOSE (CategoryID, 'A','B','C','D','E', 'F', 'G', 'H')
FROM Categories; 

-- try_cat et try_convert
select TRY_CAST('2017-02-29' as date) -- renvoie NULL


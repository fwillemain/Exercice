-- Délais de livraison des commandes (peut être nul)
select DATEDIFF(day, OrderDate, ShippedDate) as DelaiLivraison
from Orders

-- Pareil mais remplace les NULL par la valeur 30
select isnull(DATEDIFF(day, OrderDate, ShippedDate), 30) as DelaiLivraison
from Orders

-- Pour convertir
select CAST('12.56' as money)
select CONVERT(money, '12.56')

-- Permet de générer un identifiant unique - Global Unique Identifier (GUId)
declare @id as uniqueidentifier
select @id = NEWID()
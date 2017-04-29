
-- 1. Nombre d'entreprises par pays et par type (client ou fournisseur)
select Country, 'F' TypeCF, Count(*)NbEntreprises from Suppliers group by Country
Union
select Country, 'C', Count(*) from Customers group by Country
order by Country

-- 2. Cr�er une table temporaire #Produits avec les champs (id, nom, prix unitaire, qt� en stock)
-- Ins�rer 5 produits dans cette table, dont 2 qui ont des Id d�j� pr�sents dans la table Products, et 3 nouveaux
-- Faire une requ�te qui met � jour la table Products � partir de la table #Produits, en :
-- * mettant � jour le nom, le prix unitaire et la qt� en stock si l'Id du produit existe d�j�
-- * ajoutant les produits qui n'existent pas d�j�

begin tran
create table #Produits (
Id int,
Nom nvarchar(40),
PU money,
QtyStock smallint
)

insert #Produits values
(1, 'Produit 1', 10.50, 10),
(2, 'Produit 2', 20.50, 5),
(80, 'Produit 80', 10.00, 5),
(81, 'Produit 81', 10.00, 5),
(82, 'Produit 82', 10.00, 5)

begin tran 
merge Products as C
using (select Id, Nom, PU, QtyStock from #Produits) as source
on (C.ProductID = source.Id)
when matched then 
	update set 
	C.ProductName = source.Nom, 
	C.UnitsInStock = source.QtyStock, 
	C.UnitPrice = source.PU
when not matched by target then 
	insert(ProductName, UnitsInStock, UnitPrice)	
	values (source.Nom, source.QtyStock, source.PU)
output $action, Inserted.*;
rollback tran

drop table #Produits

-- 3. Supprimer les lignes de commandes qui portent sur des produits
-- livr�s par le fournisseur 'Ma maison'
-- (A faire dans une transaction pour pouvoir annuler la suppresion)

begin tran
delete Order_Details
from Suppliers S
inner join Products P on S.SupplierID = P.SupplierID
inner join Order_Details OD on P.ProductID = OD.ProductID
where S.CompanyName = 'Ma maison'

rollback


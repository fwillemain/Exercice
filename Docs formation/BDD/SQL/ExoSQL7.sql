-- 1. Liste des clients (id, nom d'entreprise) qui n'ont jamais command� un produit de la cat�gorie Condiments

select a.CustomerID, CompanyName
from Customers a
inner join Orders b on a.CustomerID = b.CustomerID
inner join Order_Details c on b.OrderID = c.OrderID
inner join Products d on c.ProductID = d.ProductID
inner join Categories e on d.CategoryID = e.CategoryID


-- 2. Liste des pays pour lesquels il n'existe aucun fournisseur de produits de la cat�gorie Condiments

-- 3. D�lai moyen de livraison des commandes de chaque livreur

-- 4. Liste des commandes qui contiennent le produit le plus vendu, c'est � dire
-- dont la quantit� totale vendue est la plus grande 

-- 5. Commandes comportant au moins un produit fourni par un fournisseur fran�ais

-- 6. CA r�alis� par chaque �quipe repr�sent�e par son manager (une �quipe = 1 manager + ses manag�s directs)
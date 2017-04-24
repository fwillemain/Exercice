-- 1. Liste des clients (id, nom d'entreprise) qui n'ont jamais commandé un produit de la catégorie Condiments

select a.CustomerID, CompanyName
from Customers a
inner join Orders b on a.CustomerID = b.CustomerID
inner join Order_Details c on b.OrderID = c.OrderID
inner join Products d on c.ProductID = d.ProductID
inner join Categories e on d.CategoryID = e.CategoryID


-- 2. Liste des pays pour lesquels il n'existe aucun fournisseur de produits de la catégorie Condiments

-- 3. Délai moyen de livraison des commandes de chaque livreur

-- 4. Liste des commandes qui contiennent le produit le plus vendu, c'est à dire
-- dont la quantité totale vendue est la plus grande 

-- 5. Commandes comportant au moins un produit fourni par un fournisseur français

-- 6. CA réalisé par chaque équipe représentée par son manager (une équipe = 1 manager + ses managés directs)
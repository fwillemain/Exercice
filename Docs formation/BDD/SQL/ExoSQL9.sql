-- 1. Créer une fonction MinDate qui renvoie la valeur minimale entre 2 dates
-- Si l'une des dates est nulle, renvoyer l'autre
-- si le 2 sont nulles, renvoyer arbitrairement la seconde
-- Tester cette fonction dans les différents cas


-- 2. Créer une procédure usp_ProductInfos qui regroupe les informations principales d'un produit
-- avec sa catégorie, et le nom et le pays de son fournisseur
-- Tester la procédure sur le produit 58


-- 3. Créer une procédure stockée usp_OrderInfos qui rassemble les infos des lignes de commandes
-- et les infos principales d'une commande (différentes dates, id client, id du livreur, frais de livraison)
-- Tester la procédure sur la commande 10986


-- 4. Créer une procédure usp_DeleteProductsAndOrdersForSupplier permettant de supprimer :
-- * tous les produits provenant d'un forunisseur
-- * toutes les lignes de commandes référançant ces produits
-- * toutes les commandes contenant ces lignes, si elles ne contiennent plus aucune ligne
-- Utiliser pour cela au moins un curseur
-- Tester la procédure sur le fournisseur d'id 7 (à l'intérieur d'une transaction pour pouvoir annuler)
-- en vérifiant notamment que la commande 10265 est bien supprimée

-- 5. Faire une nouvelle version de cette procédure, en utilisant cette fois des variables de type table
-- à la place des curseurs

-- 6. Faire une dernière version utilisant cette fois des delete de masse, sans curseur ni variable table
-- (Bien plus efficace !!)


-- 7. Créer une procédure stockée de type table renvoyant les id des
-- commandes qui ne comportent que des produits issus d'un même fournisseur


-- 8. récupérer les id et noms des clients qui ont passé les commandes
-- dont les id sont renvoyés par la procédure créée précédemment



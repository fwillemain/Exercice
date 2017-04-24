-- 1. Cr�er une fonction MinDate qui renvoie la valeur minimale entre 2 dates
-- Si l'une des dates est nulle, renvoyer l'autre
-- si le 2 sont nulles, renvoyer arbitrairement la seconde
-- Tester cette fonction dans les diff�rents cas


-- 2. Cr�er une proc�dure usp_ProductInfos qui regroupe les informations principales d'un produit
-- avec sa cat�gorie, et le nom et le pays de son fournisseur
-- Tester la proc�dure sur le produit 58


-- 3. Cr�er une proc�dure stock�e usp_OrderInfos qui rassemble les infos des lignes de commandes
-- et les infos principales d'une commande (diff�rentes dates, id client, id du livreur, frais de livraison)
-- Tester la proc�dure sur la commande 10986


-- 4. Cr�er une proc�dure usp_DeleteProductsAndOrdersForSupplier permettant de supprimer :
-- * tous les produits provenant d'un forunisseur
-- * toutes les lignes de commandes r�f�ran�ant ces produits
-- * toutes les commandes contenant ces lignes, si elles ne contiennent plus aucune ligne
-- Utiliser pour cela au moins un curseur
-- Tester la proc�dure sur le fournisseur d'id 7 (� l'int�rieur d'une transaction pour pouvoir annuler)
-- en v�rifiant notamment que la commande 10265 est bien supprim�e

-- 5. Faire une nouvelle version de cette proc�dure, en utilisant cette fois des variables de type table
-- � la place des curseurs

-- 6. Faire une derni�re version utilisant cette fois des delete de masse, sans curseur ni variable table
-- (Bien plus efficace !!)


-- 7. Cr�er une proc�dure stock�e de type table renvoyant les id des
-- commandes qui ne comportent que des produits issus d'un m�me fournisseur


-- 8. r�cup�rer les id et noms des clients qui ont pass� les commandes
-- dont les id sont renvoy�s par la proc�dure cr��e pr�c�demment



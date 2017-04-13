--insert Personne(Id, Nom, Prenom) values
--(1, 'Nom1', 'Prénom1'),
--(2, 'Nom2', 'Prénom2'),
--(3, 'Nom3', 'Prénom3'),
--(4, 'Nom4', 'Prénom4'),
--(5, 'Nom5', 'Prénom5'),
--(6, 'Nom6', 'Prénom6')

--insert Professeur(Id, DateArrivée) values
--(1, '2017-04-11'),
--(2, '2017-04-11'),
--(3, '2017-04-11')

--insert Classe(Code, Professeur_Id) values
--(1, 1),
--(2, 2),
--(3, 3)

--insert Eleve(Id, Classe_Code, Délégué) values
--(4, 1, 0),
--(5, 1, 1),
--(6, 2, 0)

--insert Matiere(Libellé) values
--('Math'),
--('Français'),
--('Histoire')

--insert Enseignement(Classe_Code, Matière_Id, Professeur_Id) values
--(1, 1, 1),
--(1, 2, 1),
--(1, 3, 2),
--(2, 1, 1),
--(2, 2, 3),
--(2, 3, 3)

--insert Personne(Id, Nom, Prenom) values
--(1, 'Nom1', 'Pr�nom1'),
--(2, 'Nom2', 'Pr�nom2'),
--(3, 'Nom3', 'Pr�nom3'),
--(4, 'Nom4', 'Pr�nom4'),
--(5, 'Nom5', 'Pr�nom5'),
--(6, 'Nom6', 'Pr�nom6')

--insert Professeur(Id, DateArriv�e) values
--(1, '2017-04-11'),
--(2, '2017-04-11'),
--(3, '2017-04-11')

--insert Classe(Code, Professeur_Id) values
--(1, 1),
--(2, 2),
--(3, 3)

--insert Eleve(Id, Classe_Code, D�l�gu�) values
--(4, 1, 0),
--(5, 1, 1),
--(6, 2, 0)

--insert Matiere(Libell�) values
--('Math'),
--('Fran�ais'),
--('Histoire')

--insert Enseignement(Classe_Code, Mati�re_Id, Professeur_Id) values
--(1, 1, 1),
--(1, 2, 1),
--(1, 3, 2),
--(2, 1, 1),
--(2, 2, 3),
--(2, 3, 3)

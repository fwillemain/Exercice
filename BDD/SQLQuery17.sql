insert Lieu(Nom, Surface, TypeLieu) values 
('Pré 1', 50000, 1),
('Bati 1', 1000, 2),
('Case 1', 50, 3)

insert Vache(Id, Nom) values (1, 'Margueritte')

insert HistoriqueLieu(Id, DateDébut, HeuresParJourPrincipal, LieuPrinc_Id, Vache_Id)
values(2, '2017-04-11', 24, 1, 1)
INSERT INTO Ligas (Id,Nombre)
VALUES (1,'Mexicana')
INSERT INTO Ligas (Id,Nombre)
VALUES (2,'Colombiana')

SET IDENTITY_INSERT Equipos ON; 
INSERT INTO Equipos (Id,Nombre,LigaId)
VALUES (1,'Equipo1',1)
INSERT INTO Equipos (Id,Nombre,LigaId)
VALUES (2,'Equipo2',1)
INSERT INTO Equipos (Id,Nombre,LigaId)
VALUES (3,'Equipo3',1)
INSERT INTO Equipos (Id,Nombre,LigaId)
VALUES (4,'Equipo4',1)
SET IDENTITY_INSERT Equipos OFF; 
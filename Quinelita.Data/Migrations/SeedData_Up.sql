--SELECT * FROM Liga

INSERT INTO Liga (Id,Nombre)
VALUES (1,'Mexicana')
INSERT INTO Liga (Id,Nombre)
VALUES (2,'Colombiana')

SET IDENTITY_INSERT Equipo ON; 
INSERT INTO Equipo (Id,Nombre,LigaId)
VALUES (1,'Equipo1',1)
INSERT INTO Equipo (Id,Nombre,LigaId)
VALUES (2,'Equipo2',1)
INSERT INTO Equipo (Id,Nombre,LigaId)
VALUES (3,'Equipo3',1)
INSERT INTO Equipo (Id,Nombre,LigaId)
VALUES (4,'Equipo4',1)
SET IDENTITY_INSERT Equipo OFF; 
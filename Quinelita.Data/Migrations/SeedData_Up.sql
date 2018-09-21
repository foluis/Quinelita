SET IDENTITY_INSERT Usuarios ON; 
INSERT INTO Usuarios (Id,Email)
VALUES (1,'Usuario1@email.com')
INSERT INTO Usuarios (Id,Email)
VALUES (2,'Usuario2@email.com')
INSERT INTO Usuarios (Id,Email)
VALUES (3,'Usuario3@email.com')
INSERT INTO Usuarios (Id,Email)
VALUES (4,'Usuario4@email.com')
INSERT INTO Usuarios (Id,Email)
VALUES (5,'Usuario5@email.com')
INSERT INTO Usuarios (Id,Email)
VALUES (6,'Usuario6@email.com')
SET IDENTITY_INSERT Usuarios OFF; 

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
INSERT INTO Equipos (Id,Nombre,LigaId)
VALUES (5,'Equipo5',1)
INSERT INTO Equipos (Id,Nombre,LigaId)
VALUES (6,'Equipo6',1)
SET IDENTITY_INSERT Equipos OFF; 

INSERT INTO TiposPuntuacion (Id,Nombre)
VALUES (1,'Acertar ganador')
INSERT INTO TiposPuntuacion (Id,Nombre)
VALUES (2,'Acertar marcador')
INSERT INTO TiposPuntuacion (Id,Nombre)
VALUES (3,'Acertar marcador inverso')
INSERT INTO TiposPuntuacion (Id,Nombre)
VALUES (4,'Acertar ganador y marcador')
INSERT INTO TiposPuntuacion (Id,Nombre)
VALUES (99,'No acert�')
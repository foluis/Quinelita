SELECT * FROM [dbo].[Usuarios]

SELECT * FROM [dbo].[Equipos]

SELECT * FROM [dbo].[Partidos]

SELECT * FROM [dbo].[Jornadas]

SELECT * FROM [dbo].[TiposPuntuacion]

-- INSERT INTO Equipos (Nombre,LigaId) VALUES ('Equipo6',1)

SELECT * FROM [dbo].[QuinelasJornada]

SELECT rj.Id,rj.PartidoId,rj.GanadorId,rj.MarcadorLocal,rj.MarcadorVisitante,rj.Fecha,p.MostrarMarcadores FROM [dbo].[ResultadosJornada] rj
INNER JOIN Partidos p ON p.Id = rj.PartidoId

SELECT * FROM [dbo].[ResultadosQuinela] Order By UsuarioId,PartidoId

--DELETE [ResultadosQuinela]
 
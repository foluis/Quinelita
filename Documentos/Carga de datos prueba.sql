
SET IDENTITY_INSERT [dbo].[Jornadas] ON 
GO
INSERT [dbo].[Jornadas] ([Id], [Fecha], [AbiertaAlPublico]) VALUES (1, CAST(N'2018-09-19' AS Date), NULL)
GO
SET IDENTITY_INSERT [dbo].[Jornadas] OFF
GO


SET IDENTITY_INSERT [dbo].[Partidos] ON 
GO
INSERT [dbo].[Partidos] ([Id], [JornadaId], [Fecha], [MostrarMarcadores], [EquipoLocalId], [EquipoVisitanteId]) VALUES (1, 1, CAST(N'2018-09-20T00:00:00.000' AS DateTime), 0, 1, 2)
GO
INSERT [dbo].[Partidos] ([Id], [JornadaId], [Fecha], [MostrarMarcadores], [EquipoLocalId], [EquipoVisitanteId]) VALUES (2, 1, CAST(N'2018-09-20T00:00:00.000' AS DateTime), 0, 3, 4)
GO
INSERT [dbo].[Partidos] ([Id], [JornadaId], [Fecha], [MostrarMarcadores], [EquipoLocalId], [EquipoVisitanteId]) VALUES (3, 1, CAST(N'2018-09-20T00:00:00.000' AS DateTime), 1, 5, 6)
GO
SET IDENTITY_INSERT [dbo].[Partidos] OFF
GO


SET IDENTITY_INSERT [dbo].[QuinelasJornada] ON 
GO
INSERT [dbo].[QuinelasJornada] ([Id], [UsuarioId], [PartidoId], [GanadorId], [MarcadorLocal], [MarcadorVisitante], [Fecha]) VALUES (1, 2, 1, 1, 0, 0, CAST(N'2018-09-20T05:28:00.000' AS DateTime))
GO
INSERT [dbo].[QuinelasJornada] ([Id], [UsuarioId], [PartidoId], [GanadorId], [MarcadorLocal], [MarcadorVisitante], [Fecha]) VALUES (2, 2, 2, NULL, 0, 0, CAST(N'2018-09-20T05:28:00.000' AS DateTime))
GO
INSERT [dbo].[QuinelasJornada] ([Id], [UsuarioId], [PartidoId], [GanadorId], [MarcadorLocal], [MarcadorVisitante], [Fecha]) VALUES (3, 2, 3, NULL, 2, 2, CAST(N'2018-09-20T05:28:00.000' AS DateTime))
GO

INSERT [dbo].[QuinelasJornada] ([Id], [UsuarioId], [PartidoId], [GanadorId], [MarcadorLocal], [MarcadorVisitante], [Fecha]) VALUES (4, 3, 1, 2, 0, 0, CAST(N'2018-09-20T05:28:00.000' AS DateTime))
GO
INSERT [dbo].[QuinelasJornada] ([Id], [UsuarioId], [PartidoId], [GanadorId], [MarcadorLocal], [MarcadorVisitante], [Fecha]) VALUES (5, 3, 2, 3, 0, 0, CAST(N'2018-09-20T05:28:00.000' AS DateTime))
GO
INSERT [dbo].[QuinelasJornada] ([Id], [UsuarioId], [PartidoId], [GanadorId], [MarcadorLocal], [MarcadorVisitante], [Fecha]) VALUES (6, 3, 3, 6, 1, 3, CAST(N'2018-09-20T05:28:00.000' AS DateTime))
GO

SET IDENTITY_INSERT [dbo].[QuinelasJornada] OFF
GO


SET IDENTITY_INSERT [dbo].[ResultadosJornada] ON 
GO
INSERT [dbo].[ResultadosJornada] ([Id], [PartidoId], [GanadorId], [MarcadorLocal], [MarcadorVisitante], [Fecha]) VALUES (1, 1, 2, 3, 0, CAST(N'2018-09-20T05:28:00.000' AS DateTime))
GO
INSERT [dbo].[ResultadosJornada] ([Id], [PartidoId], [GanadorId], [MarcadorLocal], [MarcadorVisitante], [Fecha]) VALUES (2, 2, 3, 2, 1, CAST(N'2018-09-20T13:28:00.000' AS DateTime))
GO
INSERT [dbo].[ResultadosJornada] ([Id], [PartidoId], [GanadorId], [MarcadorLocal], [MarcadorVisitante], [Fecha]) VALUES (3, 3, NULL, 3, 3, CAST(N'2018-09-20T13:28:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[ResultadosJornada] OFF
GO

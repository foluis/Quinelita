USE [Quinelita1]
GO
/****** Object:  Table [dbo].[Equipos]    Script Date: 9/21/2018 9:31:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[LigaId] [int] NOT NULL,
 CONSTRAINT [PK_Equipo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Jornadas]    Script Date: 9/21/2018 9:31:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jornadas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [date] NOT NULL,
	[AbiertaAlPublico] [bit] NULL,
 CONSTRAINT [PK_Jornada] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ligas]    Script Date: 9/21/2018 9:31:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ligas](
	[Id] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Liga] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Partidos]    Script Date: 9/21/2018 9:31:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Partidos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[JornadaId] [int] NOT NULL,
	[Fecha] [datetime] NULL,
	[MostrarMarcadores] [bit] NOT NULL,
	[EquipoLocalId] [int] NOT NULL,
	[EquipoVisitanteId] [int] NOT NULL,
 CONSTRAINT [PK_PartidosJornada] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuinelasJornada]    Script Date: 9/21/2018 9:31:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuinelasJornada](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioId] [int] NOT NULL,
	[PartidoId] [int] NOT NULL,
	[GanadorId] [int] NULL,
	[MarcadorLocal] [int] NULL,
	[MarcadorVisitante] [int] NULL,
	[Fecha] [datetime] NOT NULL,
 CONSTRAINT [PK_QuinelasJornada] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ResultadosJornada]    Script Date: 9/21/2018 9:31:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ResultadosJornada](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PartidoId] [int] NOT NULL,
	[GanadorId] [int] NULL,
	[MarcadorLocal] [int] NULL,
	[MarcadorVisitante] [int] NULL,
	[Fecha] [datetime] NOT NULL,
 CONSTRAINT [PK_ResultadosJornada] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ResultadosQuinela]    Script Date: 9/21/2018 9:31:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ResultadosQuinela](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioId] [int] NOT NULL,
	[PartidoId] [int] NOT NULL,
	[Puntos] [int] NOT NULL,
	[TipoPuntuacionId] [int] NOT NULL,
 CONSTRAINT [PK_ResultadosQuinela] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TiposPuntuacion]    Script Date: 9/21/2018 9:31:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TiposPuntuacion](
	[Id] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TiposPuntuacion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 9/21/2018 9:31:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[QuinelasJornada] ADD  CONSTRAINT [DF_QuinelasJornada_MarcadorLocal]  DEFAULT ((0)) FOR [MarcadorLocal]
GO
ALTER TABLE [dbo].[QuinelasJornada] ADD  CONSTRAINT [DF_QuinelasJornada_MarcadorVisitante]  DEFAULT ((0)) FOR [MarcadorVisitante]
GO
ALTER TABLE [dbo].[Equipos]  WITH CHECK ADD  CONSTRAINT [FK_Equipos_Ligas] FOREIGN KEY([LigaId])
REFERENCES [dbo].[Ligas] ([Id])
GO
ALTER TABLE [dbo].[Equipos] CHECK CONSTRAINT [FK_Equipos_Ligas]
GO
ALTER TABLE [dbo].[Partidos]  WITH CHECK ADD  CONSTRAINT [FK_Partidos_Equipos] FOREIGN KEY([EquipoLocalId])
REFERENCES [dbo].[Equipos] ([Id])
GO
ALTER TABLE [dbo].[Partidos] CHECK CONSTRAINT [FK_Partidos_Equipos]
GO
ALTER TABLE [dbo].[Partidos]  WITH CHECK ADD  CONSTRAINT [FK_Partidos_Equipos1] FOREIGN KEY([EquipoVisitanteId])
REFERENCES [dbo].[Equipos] ([Id])
GO
ALTER TABLE [dbo].[Partidos] CHECK CONSTRAINT [FK_Partidos_Equipos1]
GO
ALTER TABLE [dbo].[Partidos]  WITH CHECK ADD  CONSTRAINT [FK_Partidos_Jornadas] FOREIGN KEY([JornadaId])
REFERENCES [dbo].[Jornadas] ([Id])
GO
ALTER TABLE [dbo].[Partidos] CHECK CONSTRAINT [FK_Partidos_Jornadas]
GO
ALTER TABLE [dbo].[QuinelasJornada]  WITH CHECK ADD  CONSTRAINT [FK_QuinelasJornada_Equipos] FOREIGN KEY([GanadorId])
REFERENCES [dbo].[Equipos] ([Id])
GO
ALTER TABLE [dbo].[QuinelasJornada] CHECK CONSTRAINT [FK_QuinelasJornada_Equipos]
GO
ALTER TABLE [dbo].[QuinelasJornada]  WITH CHECK ADD  CONSTRAINT [FK_QuinelasJornada_Partidos] FOREIGN KEY([PartidoId])
REFERENCES [dbo].[Partidos] ([Id])
GO
ALTER TABLE [dbo].[QuinelasJornada] CHECK CONSTRAINT [FK_QuinelasJornada_Partidos]
GO
ALTER TABLE [dbo].[QuinelasJornada]  WITH CHECK ADD  CONSTRAINT [FK_QuinelasJornada_Usuarios] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuarios] ([Id])
GO
ALTER TABLE [dbo].[QuinelasJornada] CHECK CONSTRAINT [FK_QuinelasJornada_Usuarios]
GO
ALTER TABLE [dbo].[ResultadosJornada]  WITH CHECK ADD  CONSTRAINT [FK_ResultadosJornada_Equipos] FOREIGN KEY([GanadorId])
REFERENCES [dbo].[Equipos] ([Id])
GO
ALTER TABLE [dbo].[ResultadosJornada] CHECK CONSTRAINT [FK_ResultadosJornada_Equipos]
GO
ALTER TABLE [dbo].[ResultadosJornada]  WITH CHECK ADD  CONSTRAINT [FK_ResultadosJornada_Partidos] FOREIGN KEY([PartidoId])
REFERENCES [dbo].[Partidos] ([Id])
GO
ALTER TABLE [dbo].[ResultadosJornada] CHECK CONSTRAINT [FK_ResultadosJornada_Partidos]
GO
ALTER TABLE [dbo].[ResultadosQuinela]  WITH CHECK ADD  CONSTRAINT [FK_ResultadosQuinela_Partidos] FOREIGN KEY([PartidoId])
REFERENCES [dbo].[Partidos] ([Id])
GO
ALTER TABLE [dbo].[ResultadosQuinela] CHECK CONSTRAINT [FK_ResultadosQuinela_Partidos]
GO
ALTER TABLE [dbo].[ResultadosQuinela]  WITH CHECK ADD  CONSTRAINT [FK_ResultadosQuinela_TiposPuntuacion] FOREIGN KEY([TipoPuntuacionId])
REFERENCES [dbo].[TiposPuntuacion] ([Id])
GO
ALTER TABLE [dbo].[ResultadosQuinela] CHECK CONSTRAINT [FK_ResultadosQuinela_TiposPuntuacion]
GO
ALTER TABLE [dbo].[ResultadosQuinela]  WITH CHECK ADD  CONSTRAINT [FK_ResultadosQuinela_Usuarios] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuarios] ([Id])
GO
ALTER TABLE [dbo].[ResultadosQuinela] CHECK CONSTRAINT [FK_ResultadosQuinela_Usuarios]
GO

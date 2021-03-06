DECLARE @dbname nvarchar(128)
SET @dbname = N'Biblioteca'
IF (EXISTS (SELECT name 
FROM master.dbo.sysdatabases 
WHERE ('[' + name + ']' = @dbname 
OR name = @dbname)))
DROP DATABASE Biblioteca
GO
USE master
GO
/****** Object:  Database [Biblioteca]    Script Date: 8/17/2019 1:35:02 PM ******/
CREATE DATABASE [Biblioteca]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Biblioteca', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Biblioteca.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Biblioteca_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Biblioteca_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Biblioteca] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Biblioteca].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Biblioteca] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Biblioteca] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Biblioteca] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Biblioteca] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Biblioteca] SET ARITHABORT OFF 
GO
ALTER DATABASE [Biblioteca] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Biblioteca] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Biblioteca] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Biblioteca] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Biblioteca] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Biblioteca] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Biblioteca] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Biblioteca] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Biblioteca] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Biblioteca] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Biblioteca] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Biblioteca] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Biblioteca] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Biblioteca] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Biblioteca] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Biblioteca] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Biblioteca] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Biblioteca] SET RECOVERY FULL 
GO
ALTER DATABASE [Biblioteca] SET  MULTI_USER 
GO
ALTER DATABASE [Biblioteca] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Biblioteca] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Biblioteca] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Biblioteca] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Biblioteca] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Biblioteca', N'ON'
GO
ALTER DATABASE [Biblioteca] SET QUERY_STORE = OFF
GO
USE [Biblioteca]
GO
/****** Object:  UserDefinedFunction [dbo].[Obtener_Prestamos_Por_Alumno]    Script Date: 8/17/2019 1:35:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[Obtener_Prestamos_Por_Alumno] (@idAlumno INT)
RETURNS @retPrestamosAlumnos TABLE
(
Titulo VARCHAR(200)
,IdLibro INT
,FechaPrestamo DATE
,FechaDevolucion DATE
)
AS
BEGIN
INSERT INTO @retPrestamosAlumnos
SELECT L.Titulo,p.IdLibro,P.FechaPrestamo,P.FechaDevolucion 
FROM Libro l
INNER JOIN Prestamo p ON p.IdLibro=l.IdLibro
INNER JOIN  Estudiante e ON p.IdLector = e.IdLector
WHERE e.IdLector=@idAlumno
RETURN
END
GO
/****** Object:  Table [dbo].[Autor]    Script Date: 8/17/2019 1:35:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Autor](
	[IdAutor] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](200) NOT NULL,
	[Nacionalidad] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Autor] PRIMARY KEY CLUSTERED 
(
	[IdAutor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estudiante]    Script Date: 8/17/2019 1:35:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estudiante](
	[IdLector] [int] IDENTITY(1,1) NOT NULL,
	[CI] [int] NOT NULL,
	[Nombre] [varchar](250) NOT NULL,
	[Direccion] [varchar](500) NULL,
	[Carrera] [varchar](200) NULL,
	[Edad] [int] NOT NULL,
 CONSTRAINT [PK_Estudiante_1] PRIMARY KEY CLUSTERED 
(
	[IdLector] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LibAut]    Script Date: 8/17/2019 1:35:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LibAut](
	[IdAutor] [int] NOT NULL,
	[IdLibro] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Libro]    Script Date: 8/17/2019 1:35:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Libro](
	[IdLibro] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [varchar](200) NOT NULL,
	[Editorial] [varchar](200) NOT NULL,
	[Area] [varchar](200) NOT NULL,
 CONSTRAINT [PK_Libro] PRIMARY KEY CLUSTERED 
(
	[IdLibro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prestamo]    Script Date: 8/17/2019 1:35:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prestamo](
	[IdLector] [int] NOT NULL,
	[IdLibro] [int] NOT NULL,
	[FechaPrestamo] [date] NOT NULL,
	[FechaDevolucion] [date] NOT NULL,
	[Devuelto] [date] NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Autor] ON 

INSERT [dbo].[Autor] ([IdAutor], [Nombre], [Nacionalidad]) VALUES (1, N'Mario Benedetti Farrugia', N'Uruguaya')
INSERT [dbo].[Autor] ([IdAutor], [Nombre], [Nacionalidad]) VALUES (2, N'Abraham Stoker', N'Irlandesa')
INSERT [dbo].[Autor] ([IdAutor], [Nombre], [Nacionalidad]) VALUES (3, N'rancisco Charte', N'Español')
INSERT [dbo].[Autor] ([IdAutor], [Nombre], [Nacionalidad]) VALUES (4, N'Jorge Serrano Pérez', N'Español')
SET IDENTITY_INSERT [dbo].[Autor] OFF
SET IDENTITY_INSERT [dbo].[Estudiante] ON 

INSERT [dbo].[Estudiante] ([IdLector], [CI], [Nombre], [Direccion], [Carrera], [Edad]) VALUES (1, 207100145, N'Cristian Castillo', N'Tres Rios', N'Informatica', 26)
INSERT [dbo].[Estudiante] ([IdLector], [CI], [Nombre], [Direccion], [Carrera], [Edad]) VALUES (2, 207100145, N'Cristian Castillo', N'', N'Informatica', 26)
INSERT [dbo].[Estudiante] ([IdLector], [CI], [Nombre], [Direccion], [Carrera], [Edad]) VALUES (3, 207100144, N'Cristian Gonzales', N'', N'Informatica', 26)
INSERT [dbo].[Estudiante] ([IdLector], [CI], [Nombre], [Direccion], [Carrera], [Edad]) VALUES (4, 1312312, N'Felipe Loayza Beramendi', N'', N'Informatica', 18)
INSERT [dbo].[Estudiante] ([IdLector], [CI], [Nombre], [Direccion], [Carrera], [Edad]) VALUES (5, 12315, N'Felipe  Beramendi', N'', N'Informatica', 16)
INSERT [dbo].[Estudiante] ([IdLector], [CI], [Nombre], [Direccion], [Carrera], [Edad]) VALUES (6, 10236412, N'Sofia Castillo', N'Guanacaste', N'Ingenieria en Sistemas', 18)
SET IDENTITY_INSERT [dbo].[Estudiante] OFF
INSERT [dbo].[LibAut] ([IdAutor], [IdLibro]) VALUES (2, 1)
INSERT [dbo].[LibAut] ([IdAutor], [IdLibro]) VALUES (4, 5)
INSERT [dbo].[LibAut] ([IdAutor], [IdLibro]) VALUES (3, 5)
INSERT [dbo].[LibAut] ([IdAutor], [IdLibro]) VALUES (2, 2)
INSERT [dbo].[LibAut] ([IdAutor], [IdLibro]) VALUES (1, 3)
INSERT [dbo].[LibAut] ([IdAutor], [IdLibro]) VALUES (1, 4)
SET IDENTITY_INSERT [dbo].[Libro] ON 

INSERT [dbo].[Libro] ([IdLibro], [Titulo], [Editorial], [Area]) VALUES (1, N'Dracula', N'Acantilado.', N'Ciencia Ficcion')
INSERT [dbo].[Libro] ([IdLibro], [Titulo], [Editorial], [Area]) VALUES (2, N'La casa del juez', N'Acantilado.', N'Ciencia Ficcion')
INSERT [dbo].[Libro] ([IdLibro], [Titulo], [Editorial], [Area]) VALUES (3, N'Esta mañana', N'Aguilar.', N'Cuento')
INSERT [dbo].[Libro] ([IdLibro], [Titulo], [Editorial], [Area]) VALUES (4, N'Ustedes, por ejemplo', N'Aguilar.', N'Cuento')
INSERT [dbo].[Libro] ([IdLibro], [Titulo], [Editorial], [Area]) VALUES (5, N'ejemplo', N'test', N'dummy')
SET IDENTITY_INSERT [dbo].[Libro] OFF
INSERT [dbo].[Prestamo] ([IdLector], [IdLibro], [FechaPrestamo], [FechaDevolucion], [Devuelto]) VALUES (4, 1, CAST(N'2019-08-17' AS Date), CAST(N'2019-09-17' AS Date), CAST(N'2019-09-20' AS Date))
INSERT [dbo].[Prestamo] ([IdLector], [IdLibro], [FechaPrestamo], [FechaDevolucion], [Devuelto]) VALUES (5, 4, CAST(N'2016-06-01' AS Date), CAST(N'2016-06-30' AS Date), CAST(N'2017-01-01' AS Date))
ALTER TABLE [dbo].[LibAut]  WITH CHECK ADD  CONSTRAINT [FK_idAutor_tblLibAut_idAutor_Autor] FOREIGN KEY([IdAutor])
REFERENCES [dbo].[Autor] ([IdAutor])
GO
ALTER TABLE [dbo].[LibAut] CHECK CONSTRAINT [FK_idAutor_tblLibAut_idAutor_Autor]
GO
ALTER TABLE [dbo].[LibAut]  WITH CHECK ADD  CONSTRAINT [FK_idLibro_tblLibAut_idLibro_tblLibro] FOREIGN KEY([IdLibro])
REFERENCES [dbo].[Libro] ([IdLibro])
GO
ALTER TABLE [dbo].[LibAut] CHECK CONSTRAINT [FK_idLibro_tblLibAut_idLibro_tblLibro]
GO
ALTER TABLE [dbo].[Prestamo]  WITH CHECK ADD  CONSTRAINT [FK_idLector_tblPrestamo_idLector_tblEstudiante] FOREIGN KEY([IdLector])
REFERENCES [dbo].[Estudiante] ([IdLector])
GO
ALTER TABLE [dbo].[Prestamo] CHECK CONSTRAINT [FK_idLector_tblPrestamo_idLector_tblEstudiante]
GO
ALTER TABLE [dbo].[Prestamo]  WITH CHECK ADD  CONSTRAINT [FK_IdLibro_tblPrestamo_idLibro_tblLibro] FOREIGN KEY([IdLibro])
REFERENCES [dbo].[Libro] ([IdLibro])
GO
ALTER TABLE [dbo].[Prestamo] CHECK CONSTRAINT [FK_IdLibro_tblPrestamo_idLibro_tblLibro]
GO
/****** Object:  StoredProcedure [dbo].[Actualizar_Libro]    Script Date: 8/17/2019 1:35:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Actualizar_Libro]
  @idLibro INT,
  @Titulo VARCHAR(200),
  @Editorial varchar(250),
  @Area varchar(500)
  AS
	UPDATE Libro
   SET Titulo =@Titulo
      ,Editorial = @Editorial
	  ,Area = @Area
 WHERE IdLibro=@idLibro
GO
/****** Object:  StoredProcedure [dbo].[Agregar_Estudiante]    Script Date: 8/17/2019 1:35:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Agregar_Estudiante]
  @CI int,
  @Nombre varchar(250),
  @Direccion varchar(500),
  @Carrera varchar(200),
  @Edad int
  AS
	INSERT INTO Estudiante  VALUES(@CI,@Nombre,@Direccion,@Carrera,@Edad)
GO
/****** Object:  StoredProcedure [dbo].[Obtener_Libros_Por_Autor]    Script Date: 8/17/2019 1:35:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Obtener_Libros_Por_Autor] @Autor AS VARCHAR(250)
AS
	SELECT
		l.*
	FROM Autor a
	INNER JOIN LibAut la
		ON a.IdAutor = la.IdAutor
	INNER JOIN Libro l
		ON la.IdLibro = l.IdLibro
	WHERE a.Nombre LIKE '%' +@Autor+''
GO
USE [master]
GO
ALTER DATABASE [Biblioteca] SET  READ_WRITE 
GO

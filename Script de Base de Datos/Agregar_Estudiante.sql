USE Biblioteca
GO
IF OBJECT_ID('Agregar_Estudiante') IS NOT NULL
	DROP PROCEDURE Agregar_Estudiante
GO
CREATE PROCEDURE Agregar_Estudiante
  @CI int,
  @Nombre varchar(250),
  @Direccion varchar(500),
  @Carrera varchar(200),
  @Edad int
  AS
	INSERT INTO Estudiante  VALUES(@CI,@Nombre,@Direccion,@Carrera,@Edad)
GO


--EXEC Agregar_Estudiante @CI = 10236412=,@Nombre = 'Sofia Castillo',@Direccion = 'Guanacaste',@Carrera = 'Ingenieria en Sistemas',@Edad = 18	
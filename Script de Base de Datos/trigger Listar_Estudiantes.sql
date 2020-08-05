USE [Biblioteca]
GO
IF OBJECT_ID('Obtener_Prestamos_Por_Alumno') IS NOT NULL
DROP FUNCTION Obtener_Prestamos_Por_Alumno
GO
CREATE FUNCTION Obtener_Prestamos_Por_Alumno (@idAlumno INT)
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

--SELECT * FROM dbo.Obtener_Prestamos_Por_Alumno(5)
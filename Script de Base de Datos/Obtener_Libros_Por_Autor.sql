USE Biblioteca
GO
IF OBJECT_ID('Obtener_Libros_Por_Autor') IS NOT NULL
	DROP PROCEDURE Obtener_Libros_Por_Autor
GO
CREATE PROCEDURE Obtener_Libros_Por_Autor @Autor AS VARCHAR(250)
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


--EXEC Obtener_Libros_Por_Autor @Autor = 'Abraham Stoker'
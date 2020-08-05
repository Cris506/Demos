
/**************Consulta **************/
	SELECT a.* FROM Autor a 
	INNER JOIN LibAut la ON a.IdAutor = la.IdAutor
	INNER JOIN Libro l ON la.IdLibro = l.IdLibro
GROUP BY a.IdAutor,a.Nombre,a.Nacionalidad
HAVING COUNT(L.IdLibro)>1	
SELECT * FROM Libro
----------------------------------------------

SELECT e.Nombre,e.Edad FROM Estudiante e
------------------------------------------------
SELECT e.Nombre,e.Edad FROM Estudiante e
WHERE e.Carrera='Informatica'
----------------------------------------------
SELECT e.Nombre,e.Edad FROM Estudiante e
WHERE e.Nombre LIKE '%G%'

---------------------------------------------
SELECT a.Nombre FROM Autor a 
INNER JOIN LibAut la ON a.IdAutor = la.IdAutor
INNER JOIN Libro l ON la.IdLibro = l.IdLibro
WHERE  l.Titulo='Visual Studio Net'
------------------------------------------
SELECT a.* FROM Autor a
WHERE a.Nacionalidad='USA'
------------------------------------------
SELECT L.* FROM Autor a 
INNER JOIN LibAut la ON a.IdAutor = la.IdAutor
INNER JOIN Libro l ON la.IdLibro = l.IdLibro
WHERE  NOT l.Area LIKE'%Internet%'
------------------------------------------------
SELECT l.* FROM Libro l
INNER JOIN Prestamo p ON p.IdLibro=l.IdLibro
INNER JOIN  Estudiante e ON p.IdLector = e.IdLector
WHERE e.Nombre ='Felipe Loayza Beramendi'
-------------------------------------------
SELECT e.Nombre FROM Libro l
INNER JOIN Prestamo p ON p.IdLibro=l.IdLibro
INNER JOIN  Estudiante e ON p.IdLector = e.IdLector
WHERE e.Edad<18
--------------------------------------
SELECT e.Nombre FROM Libro l
INNER JOIN Prestamo p ON p.IdLibro=l.IdLibro
INNER JOIN  Estudiante e ON p.IdLector = e.IdLector
WHERE L.Area ='Base de Datos'
-------------------------------
SELECT l.* FROM Libro l 
WHERE l.Editorial='Alfa y Omega'
--------------------------------------
SELECT L.* FROM Autor a 
INNER JOIN LibAut la ON a.IdAutor = la.IdAutor
INNER JOIN Libro l ON la.IdLibro = l.IdLibro
WHERE a.Nombre like '%Mario Benedetti%'
---------------------------------------
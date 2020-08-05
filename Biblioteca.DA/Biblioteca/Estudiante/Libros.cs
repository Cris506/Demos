using Biblioteca.BO.Contratos;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.DA
{
    public class Libros : ILibros
    {
        public void ActualizarLibro(Model.Libros libro)
        {
            using (var context = new Biblioteca.BibliotecaEntities())
            {
                var librosExistente = context.Libroes.Find(libro.IdLibro);
                if (librosExistente != null)
                {
                    librosExistente.Area = libro.Area;
                    librosExistente.Editorial = libro.Editorial;
                    librosExistente.Titulo = libro.Titulo;
                    context.SaveChanges();
                }
            }
        }

        public void AgregarLibro(Model.Libros libro)
        {
            var modelo = ConvertitModeloAEntity(libro);
            using (var context = new Biblioteca.BibliotecaEntities())
            {
                context.Libroes.Add(modelo);
                context.SaveChanges();
            }
        }

        public List<Model.Libros> ConsultarLibros()
        {
            using (var context = new Biblioteca.BibliotecaEntities())
            {
                return ConvertirListaEntityAListaModelo(context.Libroes.ToList());
            }
        }

        public Model.Libros ConsultarLibrosPorId(int id)
        {
            using (var context = new Biblioteca.BibliotecaEntities())
            {
                return ConvertirEntityAModelo(context.Libroes.Find(id));
            }
        }

        public void EliminarLibro(int idLibro)
        {
            using (var context = new Biblioteca.BibliotecaEntities())
            {
                var libro = context.Libroes.Find(idLibro);
                context.Entry(libro).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }

        private Biblioteca.Libro ConvertitModeloAEntity(Model.Libros libro)
        {
            return new Biblioteca.Libro()
            {
                Area = libro.Area,
                Editorial = libro.Editorial,
                Titulo = libro.Titulo
            };
        }
        private List<Model.Libros> ConvertirListaEntityAListaModelo(List<Biblioteca.Libro> libros)
        {
            return libros.Select(x => new Model.Libros
            {
                IdLibro = x.IdLibro,
                Titulo = x.Titulo,
                Editorial = x.Editorial,
                Area = x.Area
            }).ToList();
        }
        private Model.Libros ConvertirEntityAModelo(Biblioteca.Libro libro)
        {
            return new Model.Libros
            {
                IdLibro = libro.IdLibro,
                Area = libro.Area,
                Editorial = libro.Editorial,
                Titulo = libro.Titulo
            };
        }
    }
}

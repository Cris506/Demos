using Biblioteca.BO.Metodos;

using System.Collections.Generic;

namespace Biblioteca.Service.Biblioteca
{
    public class LibroService
    {
        public List<Model.Libros> ConsultarLibro()
        {
            BOLibros  libros = new BOLibros(new DA.Libros());
            return libros.ConsultarLibross();
        }

        public void AgregarLibro(Model.Libros libro)
        {
            BOLibros libros = new BOLibros(new DA.Libros());
            libros.AgregarLibros(libro);
        }
        public void EliminarLibro(int idLibro)
        {
            BOLibros libros = new BOLibros(new DA.Libros());
            libros.EliminarLibros(idLibro);
        }

        public void ActualizarLibro(Model.Libros Libro)
        {
            BOLibros Libros = new BOLibros(new DA.Libros());
            Libros.ActualizarLibros(Libro);
        }

        public Model.Libros ConsultarLibroPorId(int idLibro)
        {
            BOLibros Libros = new BOLibros(new DA.Libros());
            return Libros.ConsultarIdLibros(idLibro);
        }
    }
}

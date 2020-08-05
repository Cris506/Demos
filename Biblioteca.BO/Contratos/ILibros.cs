using System.Collections.Generic;

namespace Biblioteca.BO.Contratos
{
    public interface ILibros
    {
        void AgregarLibro(Model.Libros libro);
        void EliminarLibro(int idLibro);
        void ActualizarLibro(Model.Libros libro);
        List<Model.Libros> ConsultarLibros();
        Model.Libros ConsultarLibrosPorId(int id);
    }
}

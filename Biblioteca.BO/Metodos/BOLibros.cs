using Biblioteca.BO.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.BO.Metodos
{
    public class BOLibros
    {
        private ILibros iLibros;
        public BOLibros(ILibros Libross)
        {
            this.iLibros = Libross;
        }
        public List<Model.Libros> ConsultarLibross()
        {
            return iLibros.ConsultarLibros();
        }

        public void ActualizarLibros(Model.Libros Libros)
        {
            iLibros.ActualizarLibro(Libros);
        }
        public void AgregarLibros(Model.Libros Libros)
        {
            iLibros.AgregarLibro(Libros);
        }
        public void EliminarLibros(int idLibros)
        {
            iLibros.EliminarLibro(idLibros);
        }

        public Model.Libros ConsultarIdLibros(int idLibros)
        {
            return iLibros.ConsultarLibrosPorId(idLibros);
        }
    }
}

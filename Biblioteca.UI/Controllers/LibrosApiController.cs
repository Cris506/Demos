using Biblioteca.Service.Biblioteca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Biblioteca.UI.Controllers
{
    public class LibrosApiController : ApiController
    {
        private LibroService service = new LibroService();
        public IHttpActionResult GetObtenerLibros()
        {
            var listaLibros = service.ConsultarLibro();
            if (listaLibros.Count == 0)
            {
                return NotFound();
            }

            return Ok(listaLibros);
        }
        public IHttpActionResult GetObtenerLibrosPorId(int id)
        {
            var libro = service.ConsultarLibroPorId(id);
            if (libro == null)
            {
                return NotFound();
            }

            return Ok(libro);
        }

        public IHttpActionResult PostAgregarLibro(Model.Libros libro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Modelo No valido");
            }
            service.AgregarLibro(libro);
            return Ok();
        }

        public IHttpActionResult Deletelibro(int id)
        {
            if (id <= 0)
                return BadRequest("El id del libro no es valido");

            service.EliminarLibro(id);
            return Ok();
        }
        public IHttpActionResult PutActualizarLibro(Model.Libros libros)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Modelo No valido");
            }
            service.ActualizarLibro(libros);
            return Ok();
        }
    }
}
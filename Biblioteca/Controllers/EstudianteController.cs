using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Biblioteca.Controllers
{
    public class EstudianteController : ApiController
    {
        private Service.Biblioteca.EstudianteService service = new Service.Biblioteca.EstudianteService();
        // GET api/<controller>
        public IHttpActionResult GetObtenerEstudiantes()
        {
            var listaEstudiantes=service.ConsultarEstudiante();
            if (listaEstudiantes.Count == 0)
            {
                return NotFound();
            }
            return Ok(listaEstudiantes);
        }

    }
}
using Biblioteca.Service.Biblioteca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Biblioteca.UI.Controllers
{
    public class EstudianteApiController : ApiController
    {
        private EstudianteService service = new EstudianteService();
        public IHttpActionResult GetObtenerEstudiantes()
        {
            var listaEstudiantes = service.ConsultarEstudiante();
            if (listaEstudiantes.Count == 0)
            {
                return NotFound();
            }

            return Ok(listaEstudiantes);
        }
        public IHttpActionResult GetObtenerEstudiantesPorId(int id)
        {
            var estudiante = service.ConsultarEstudiantePorId(id);
            if (estudiante==null)
            {
                return NotFound();
            }

            return Ok(estudiante);
        }

        public IHttpActionResult PostAgregarEstudiante(Model.Estudiante estudiante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Modelo No valido");
            }
            service.AgregarEstudiante(estudiante);
            return Ok();
        }

        public IHttpActionResult DeleteEstudiante(int id)
        {
            if (id <= 0)
                return BadRequest("El id del estudiante no es valido");

            service.EliminarEstudiante(id);
            return Ok();
        }
        public IHttpActionResult PutActualizarEstudiante(Model.Estudiante estudiante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Modelo No valido");
            }
            service.ActualizarEstudiante(estudiante);
            return Ok();
        }

    }
}

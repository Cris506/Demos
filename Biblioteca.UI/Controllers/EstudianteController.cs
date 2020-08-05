using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Biblioteca.UI.Controllers
{
    public class EstudianteController : Controller
    {
        // GET: Estudiante
        public ActionResult Index()
        {
            IEnumerable<Model.Estudiante> estudiantes = null;
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri("https://localhost:44373/api/");
                var respuesta = cliente.GetAsync("EstudianteApi");
                respuesta.Wait();
                var resultado = respuesta.Result;
                if (resultado.IsSuccessStatusCode)
                {
                    var leerDatos = resultado.Content.ReadAsAsync<IList<Model.Estudiante>>();
                    leerDatos.Wait();
                    estudiantes = leerDatos.Result;
                }
                else
                {
                    estudiantes = Enumerable.Empty<Model.Estudiante>();
                    ModelState.AddModelError(string.Empty, "Error al procesar los datos.");
                }
            }
            return View(estudiantes);
        }

    
        // GET: Estudiante/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estudiante/Create
        [HttpPost]
        public ActionResult Create(Model.Estudiante estudiante)
        {
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri("https://localhost:44373/api/EstudianteApi/");
                var postTask = cliente.PostAsJsonAsync("AgregarEstudiante", estudiante);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Error al procesar los datos.");
            return View(estudiante);
        }

        // GET: Estudiante/Edit/5
        public ActionResult Edit(int id)
        {
            Model.Estudiante estudiante = null;
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri("https://localhost:44373/api/");
                var respuesta = cliente.GetAsync("EstudianteApi?id="+id.ToString());
                respuesta.Wait();
                var resultado = respuesta.Result;
                if (resultado.IsSuccessStatusCode)
                {
                    var leerDatos = resultado.Content.ReadAsAsync<Model.Estudiante>();
                    leerDatos.Wait();
                    estudiante = leerDatos.Result;
                }
            }
            return View(estudiante);
        }

        // POST: Estudiante/Edit/5
        [HttpPost]
        public ActionResult Edit(Model.Estudiante estudiante)
        {
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri("https://localhost:44373/api/EstudianteApi/");
                var postTask = cliente.PutAsJsonAsync("ActualizarEstudiante", estudiante);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Error al procesar los datos.");
            return View(estudiante);
        }

        // GET: Estudiante/Delete/5
        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44373/api/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("EstudianteApi/" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }
    }
}

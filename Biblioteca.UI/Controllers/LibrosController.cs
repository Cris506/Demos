using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Biblioteca.UI.Controllers
{
    public class LibrosController : Controller
    {
        // GET: Libros
        public ActionResult Index()
        {
            IEnumerable<Model.Libros> libros = null;
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri("https://localhost:44373/api/");
                var respuesta = cliente.GetAsync("LibrosApi");
                respuesta.Wait();
                var resultado = respuesta.Result;
                if (resultado.IsSuccessStatusCode)
                {
                    var leerDatos = resultado.Content.ReadAsAsync<IList<Model.Libros>>();
                    leerDatos.Wait();
                    libros = leerDatos.Result;
                }
                else
                {
                    libros = Enumerable.Empty<Model.Libros>();
                    ModelState.AddModelError(string.Empty, "Error al procesar los datos.");
                }
            }
            return View(libros);
        }

        // GET: Libros/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Libros/Create
        [HttpPost]
        public ActionResult Create(Model.Libros libro)
        {
            {
                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri("https://localhost:44373/api/LibrosApi/");
                    var postTask = cliente.PostAsJsonAsync("AgregarLibro", libro);
                    postTask.Wait();
                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
                ModelState.AddModelError(string.Empty, "Error al procesar los datos.");
                return View(libro);
            }
        }

        // GET: Libros/Edit/5
        public ActionResult Edit(int id)
        {
            Model.Libros libro = null;
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri("https://localhost:44373/api/");
                var respuesta = cliente.GetAsync("LibrosApi?id=" + id.ToString());
                respuesta.Wait();
                var resultado = respuesta.Result;
                if (resultado.IsSuccessStatusCode)
                {
                    var leerDatos = resultado.Content.ReadAsAsync<Model.Libros>();
                    leerDatos.Wait();
                    libro = leerDatos.Result;
                }
            }
            return View(libro);
        }

        // POST: Libros/Edit/5
        [HttpPost]
        public ActionResult Edit(Model.Libros libro)
        {
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri("https://localhost:44373/api/LibrosApi/");
                var postTask = cliente.PutAsJsonAsync("ActualizarLibro", libro);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Error al procesar los datos.");
            return View(libro);
        }

        // GET: Libros/Delete/5
        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44373/api/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("LibrosApi/" + id.ToString());
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

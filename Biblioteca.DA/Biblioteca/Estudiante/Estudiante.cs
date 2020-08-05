using Biblioteca.BO.Contratos;
using Biblioteca.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.DA
{
    public class Estudiante : IEstudiantes
    {
        public void ActualizarEstuidante(Model.Estudiante estudiante)
        {

            using (var context = new Biblioteca.BibliotecaEntities())
            {
                var estudianteExistente = context.Estudiantes.Find(estudiante.IdLector);
                if (estudianteExistente != null)
                {
                    estudianteExistente.Nombre = estudiante.Nombre;
                    estudianteExistente.CI = estudiante.CI;
                    estudianteExistente.Carrera = estudiante.Carrera;
                    estudianteExistente.Edad = estudiante.Edad;
                    estudianteExistente.Direccion = estudiante.Direccion;
                    context.SaveChanges();
                }
            }
        }

        public void AgregarEstudiante(Model.Estudiante estudiante)
        {
            var modelo = ConvertitModeloAEntity(estudiante);
            using (var context = new Biblioteca.BibliotecaEntities())
            {
                context.Estudiantes.Add(modelo);
                context.SaveChanges();
            }
        }

        public Model.Estudiante ConsultarEstudiantePorId(int id)
        {
            using (var context = new Biblioteca.BibliotecaEntities())
            {
                return ConvertirEntityAModelo(context.Estudiantes.Find(id));
            }
        }

        public List<Model.Estudiante> ConsultarEstudiantes()
        {
            using (var context = new Biblioteca.BibliotecaEntities())
            {
                return ConvertirListaEntityAListaModelo(context.Estudiantes.ToList());
            }
        }

        public void EliminarEstudiante(int idEstudiante)
        {
            using (var context = new Biblioteca.BibliotecaEntities())
            {
                var estudiante = context.Estudiantes.Find(idEstudiante);
                context.Entry(estudiante).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }

        private List<Model.Estudiante> ConvertirListaEntityAListaModelo(List<Biblioteca.Estudiante> estudiante)
        {
            return estudiante.Select(x => new Model.Estudiante
            {
                Nombre = x.Nombre,
                Carrera = x.Carrera,
                CI = x.CI,
                Direccion = x.Direccion,
                Edad = x.Edad,
                IdLector = x.IdLector
            }).ToList();
        }

        private Biblioteca.Estudiante ConvertitModeloAEntity(Model.Estudiante estudiante)
        {
            return new Biblioteca.Estudiante
            {
                IdLector = estudiante.IdLector,
                Carrera = estudiante.Carrera,
                CI = estudiante.CI,
                Direccion = estudiante.Direccion,
                Edad = estudiante.Edad,
                Nombre = estudiante.Nombre
            };
        }

        private Model.Estudiante ConvertirEntityAModelo(Biblioteca.Estudiante estudiante)
        {
            return new Model.Estudiante
            {
                Nombre = estudiante.Nombre,
                Carrera = estudiante.Carrera,
                CI = estudiante.CI,
                Direccion = estudiante.Direccion,
                Edad = estudiante.Edad,
                IdLector = estudiante.IdLector
            };
        }
    }
}

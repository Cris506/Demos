using Biblioteca.BO.Metodos;
using System.Collections.Generic;

namespace Biblioteca.Service.Biblioteca
{
    public class EstudianteService
    {
        public List<Model.Estudiante> ConsultarEstudiante()
        {
            BOEstudiantes estudiantes = new BOEstudiantes(new DA.Estudiante());
            return estudiantes.ConsultarEstudiantes();
        }

        public void AgregarEstudiante(Model.Estudiante estudiante)
        {
            BOEstudiantes estudiantes = new BOEstudiantes(new DA.Estudiante());
            estudiantes.AgregarEstudiante(estudiante);
        }
        public void EliminarEstudiante(int idEstudiante)
        {
            BOEstudiantes estudiantes = new BOEstudiantes(new DA.Estudiante());
            estudiantes.EliminarEstudiante(idEstudiante);
        }

        public void ActualizarEstudiante(Model.Estudiante estudiante)
        {
            BOEstudiantes estudiantes = new BOEstudiantes(new DA.Estudiante());
            estudiantes.ActualizarEstudiante(estudiante);
        }

        public Model.Estudiante ConsultarEstudiantePorId(int idEstudiante)
        {
            BOEstudiantes estudiantes = new BOEstudiantes(new DA.Estudiante());
            return estudiantes.ConsultarIdEstudiante(idEstudiante);
        }


    }
}


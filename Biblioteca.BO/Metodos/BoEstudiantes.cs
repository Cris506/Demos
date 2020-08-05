using Biblioteca.BO.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.BO.Metodos
{
    public class BOEstudiantes
    {
        private IEstudiantes iEstudiante;
        public BOEstudiantes(IEstudiantes estudiantes)
        {
            this.iEstudiante = estudiantes;
        }

        public List<Model.Estudiante> ConsultarEstudiantes()
        {
            return iEstudiante.ConsultarEstudiantes();
        }

        public void ActualizarEstudiante(Model.Estudiante estudiante)
        {
            iEstudiante.ActualizarEstuidante(estudiante);
        }
        public void AgregarEstudiante(Model.Estudiante estudiante)
        {
            iEstudiante.AgregarEstudiante(estudiante);
        }
        public void EliminarEstudiante(int idEstudiante)
        {
            iEstudiante.EliminarEstudiante(idEstudiante);
        }

        public Model.Estudiante ConsultarIdEstudiante(int idEstudiante)
        {
            return iEstudiante.ConsultarEstudiantePorId(idEstudiante);
        }
    }
}

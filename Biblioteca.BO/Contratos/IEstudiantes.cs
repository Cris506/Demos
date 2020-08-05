using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.BO.Contratos
{
    public interface IEstudiantes
    {
        void AgregarEstudiante(Model.Estudiante estudiante);
        void EliminarEstudiante(int idEstudiante);
        void ActualizarEstuidante(Model.Estudiante estudiante);
        List<Model.Estudiante> ConsultarEstudiantes();
        Model.Estudiante ConsultarEstudiantePorId(int id);
    }
}

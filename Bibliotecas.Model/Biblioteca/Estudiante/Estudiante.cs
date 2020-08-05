using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Model
{
    class Estudiante
    {
        public int IdLector { get; set; }
        public int CI { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Carrera { get; set; }
        public int Edad { get; set; }
    }
}

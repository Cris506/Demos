using System;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Model
{
    public class Estudiante
    {
        public int IdLector { get; set; }

       [Required(ErrorMessage ="El campo CI es un campo requerido")]
        public int CI { get; set; }
        [Required(ErrorMessage = "El campo Nombre es un campo requerido")]
        public string Nombre { get; set; }
        public string Direccion { get; set; }

        public string Carrera { get; set; }
        [RegularExpression("[^0-9]", ErrorMessage = "Solo se permiten numeros")]
        public int Edad { get; set; }
    }
}

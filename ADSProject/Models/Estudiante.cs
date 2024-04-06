using System.ComponentModel.DataAnnotations;

namespace ADSProject.Models
{
    public class Estudiante
    {
        public int IdEstudiante { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(50, ErrorMessage = "El nombre del estudiante no puede tener más de 50 caracteres.")]
        public string NombresEstudiante { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(50, ErrorMessage = "Los apellidos del estudiante no pueden tener más de 50 caracteres.")]
        public string ApellidosEstudiante { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "El código del estudiante debe tener entre 5 y 10 caracteres.")]
        public string CodigoEstudiante { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        [EmailAddress(ErrorMessage = "El correo electrónico no tiene un formato válido.")]
        [StringLength(100, ErrorMessage = "El correo electrónico no puede tener más de 100 caracteres.")]
        public string CorreoEstudiante { get; set; }
    }
}

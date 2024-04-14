using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ADSProject.Models
{ [PrimaryKey(nameof(IdEstudiante))]
    public class Estudiante
    {
       
        public int IdEstudiante { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        [MinLength(12, ErrorMessage = "La longitud del campo no debe ser menor a 12 caracteres.")]
        [MaxLength(50, ErrorMessage = "La longitud del campo no debe ser mayor a 50 caracteres")]
        public string NombresEstudiante { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]

        [MinLength(12, ErrorMessage = "La longitud del campo no debe ser menor a 12 caracteres.")]
        [MaxLength(50, ErrorMessage = "La longitud del campo no debe ser mayor a 50 caracteres")]
        public string ApellidosEstudiante { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        [MinLength(12, ErrorMessage = "La longitud del campo no debe ser menor a 12 caracteres.")]
        [MaxLength(50, ErrorMessage = "La longitud del campo no debe ser mayor a 50 caracteres")]
        public string CodigoEstudiante { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        [EmailAddress(ErrorMessage = "El correo electrónico no tiene un formato válido.")]
        [StringLength(254, ErrorMessage = "El correo electrónico no puede tener más de 254 caracteres.")]
        public string CorreoEstudiante { get; set; }
    }
}

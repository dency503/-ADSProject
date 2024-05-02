using ADSProject.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ADSProject.Models
{
    [PrimaryKey(nameof(IdMateria))]
    public class Materia
    {
        public int IdMateria { get; set; }

        [Required(ErrorMessage = "Este Canmpo es requerido.")]
        [MaxLength(50, ErrorMessage = "La longitud no debe ser mayor a 50 caracteres.")]
        public string NombreMateria { get; set; }
    }
}

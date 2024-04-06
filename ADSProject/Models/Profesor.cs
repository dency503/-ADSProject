

    using System.ComponentModel.DataAnnotations;

    namespace ADSProject.Models
    {
        public class Profesor
        {
            public int IdProfesor { get; set; }

            [Required(ErrorMessage = "Este campo requerido.")]

            [MaxLength(254, ErrorMessage = "La longitud no debe ser mayor a 254 caracteres.")]
            [EmailAddress(ErrorMessage = "El correo electrónico no tiene un formato válido.")]
            public string Email { get; set; }


            [Required(ErrorMessage = "Este campo requerido.")]

            [MaxLength(50, ErrorMessage = "La longitud de los nombres no debe ser mayor a 50 caracteres.")]
            public string NombresProfesor { get; set; }

            [Required(ErrorMessage = "Este campo requerido.")]
            [MaxLength(50, ErrorMessage = "La longitud de los apellidos no debe ser mayor a 50 caracteres.")]
            public string ApellidosProfesor { get; set; }
        }
    }
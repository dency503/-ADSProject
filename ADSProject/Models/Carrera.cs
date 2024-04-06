using System.ComponentModel.DataAnnotations;

public class Carrera
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Este campo es requerido.")]
    [MaxLength(3, ErrorMessage = "La longitud no debe ser mayor a 3 caracteres.")]
    public string Codigo { get; set; }

    [Required(ErrorMessage = "Este campo es requerido.")]
    [MaxLength(50, ErrorMessage = "La longitud no debe ser mayor a 50 caracteres.")]
    public string Nombre { get; set; }
}

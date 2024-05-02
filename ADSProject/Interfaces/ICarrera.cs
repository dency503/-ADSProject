using ADSProject.Models;

namespace ADSProject.Interfaces
{
    public interface ICarrera
    {
        // Método para agregar una carrera
        int AgregarCarrera(Carrera carrera);

        // Método para actualizar una carrera
        bool ActualizarCarrera(int idCarrera, Carrera carrera);

        // Método para eliminar una carrera
        bool EliminarCarrera(int idCarrera);

        // Método para obtener todas las carreras
        List<Carrera> ObtenerTodasLasCarreras();

        // Método para obtener una carrera por su ID
        Carrera ObtenerCarreraPorId(int idCarrera);
    }
}

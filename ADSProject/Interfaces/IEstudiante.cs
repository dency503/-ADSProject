using ADSProject.Models;

namespace ADSProject.Interfaces
{
    public interface IEstudiante
    {
        int AgregarEstudiante(Estudiante estudiante);
        int ActualizarEstudiante(int idEstudiante, Estudiante estudiante);
        bool EliminarEstudiante(int idEstudiante);
        List<Estudiante> ObtenerTodosLosEstudiantes();
        Estudiante ObtenerEstudiantePorID(int idEstudiante);
    }
}

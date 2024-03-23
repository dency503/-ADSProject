namespace ADSProject.Interfaces
{
    using ADSProject.Models;
    using System.Collections.Generic;

    public interface IProfesor
    {
        int AgregarProfesor(Profesor profesor);
        int ActualizarProfesor(int idProfesor, Profesor profesor);
        bool EliminarProfesor(int idProfesor);
        List<Profesor> ObtenerTodosLosProfesores();
        Profesor ObtenerProfesorPorId(int idProfesor);
    }

}

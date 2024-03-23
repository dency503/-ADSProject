namespace ADSProject.Interfaces
{
    using ADSProject.Models;
    using System.Collections.Generic;

    public interface IMateria
    {
        int AgregarMateria(Materia materia);
        int ActualizarMateria(int idMateria, Materia materia);
        bool EliminarMateria(int idMateria);
        List<Materia> ObtenerTodasLasMaterias();
        Materia ObtenerMateriaPorId(int idMateria);
    }

}

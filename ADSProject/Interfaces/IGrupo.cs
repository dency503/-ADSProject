namespace ADSProject.Interfaces
{
    using ADSProject.Models;
    using System.Collections.Generic;

    public interface IGrupo
    {
        int AgregarGrupo(Grupo grupo);
        int ActualizarGrupo(int idGrupo, Grupo grupo);
        bool EliminarGrupo(int idGrupo);
        List<Grupo> ObtenerTodosLosGrupos();
        Grupo ObtenerGrupoPorId(int idGrupo);
    }

}

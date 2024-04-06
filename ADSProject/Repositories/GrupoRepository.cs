using ADSProject.Interfaces;
using ADSProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace ADSProject.Interfaces
{
    public class GrupoRepository : IGrupo
    {
        private List<Grupo> grupos = new List<Grupo>();

        public GrupoRepository()
        {
            // Add a default group when initializing the repository
            AgregarGrupoPorDefecto();
        }

        private void AgregarGrupoPorDefecto()
        {
            Grupo grupoPorDefecto = new Grupo
            {
                IdGrupo = 1,
                IdCarrera = 1,
                IdMateria = 1,
                IdProfesor = 1,
                Ciclo = 1,
                Anio = 2024
            };
            grupos.Add(grupoPorDefecto);
        }

        public int AgregarGrupo(Grupo grupo)
        {
            grupo.IdGrupo = grupos.Count + 1;
            grupos.Add(grupo);
            return grupo.IdGrupo;
        }

        public int ActualizarGrupo(int idGrupo, Grupo grupo)
        {
            Grupo grupoExistente = ObtenerGrupoPorId(idGrupo);
            if (grupoExistente != null)
            {
                grupoExistente.IdCarrera = grupo.IdCarrera;
                grupoExistente.IdMateria = grupo.IdMateria;
                grupoExistente.IdProfesor = grupo.IdProfesor;
                grupoExistente.Ciclo = grupo.Ciclo;
                grupoExistente.Anio = grupo.Anio;
                return 1; // Indicates success in updating
            }
            return 0; // Indicates that the group with the specified ID was not found
        }

        public bool EliminarGrupo(int idGrupo)
        {
            Grupo grupoExistente = ObtenerGrupoPorId(idGrupo);
            if (grupoExistente != null)
            {
                grupos.Remove(grupoExistente);
                return true; // Indicates success in deletion
            }
            return false; // Indicates that the group with the specified ID was not found
        }

        public List<Grupo> ObtenerTodosLosGrupos()
        {
            return grupos;
        }

        public Grupo ObtenerGrupoPorId(int idGrupo)
        {
            return grupos.FirstOrDefault(g => g.IdGrupo == idGrupo);
        }
    }
}

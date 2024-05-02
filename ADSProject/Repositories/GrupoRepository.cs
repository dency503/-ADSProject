using ADSProject.DB;
using ADSProject.Interfaces;
using ADSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ADSProject.Repositories
{
    public class GrupoRepository : IGrupo
    {
        private readonly ApplicationDbContext applicationDbContext;

        public GrupoRepository(ApplicationDbContext context)
        {
            applicationDbContext = context;

           
        }

        public int AgregarGrupo(Grupo grupo)
        {
            try
            {
                // Agregar el nuevo grupo al contexto de la base de datos
                applicationDbContext.Grupos.Add(grupo);

                // Guardar los cambios en la base de datos
                applicationDbContext.SaveChanges();

                // Devolver el ID del grupo agregado
                return grupo.IdGrupo;
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción lanzada
                throw ex;
            }
        }

        public int ActualizarGrupo(int idGrupo, Grupo grupo)
        {
            try
            {
                // Obtener el grupo existente por su ID
                var grupoExistente = applicationDbContext.Grupos.SingleOrDefault(g => g.IdGrupo == idGrupo);

                if (grupoExistente != null)
                {
                    // Actualizar los valores del grupo existente con los valores del grupo proporcionado
                    grupoExistente.IdCarrera = grupo.IdCarrera;
                    grupoExistente.IdMateria = grupo.IdMateria;
                    grupoExistente.IdProfesor = grupo.IdProfesor;
                    grupoExistente.Ciclo = grupo.Ciclo;
                    grupoExistente.Anio = grupo.Anio;

                    // Guardar los cambios en la base de datos
                    applicationDbContext.SaveChanges();

                    return 1; // Indica éxito en la actualización
                }
                else
                {
                    return 0; // Indica que no se encontró el grupo con el ID especificado
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción lanzada
                throw ex;
            }
        }

        public bool EliminarGrupo(int idGrupo)
        {
            try
            {
                // Obtener el grupo por su ID
                var grupo = applicationDbContext.Grupos.SingleOrDefault(g => g.IdGrupo == idGrupo);

                if (grupo != null)
                {
                    // Eliminar el grupo del contexto de la base de datos
                    applicationDbContext.Grupos.Remove(grupo);

                    // Guardar los cambios en la base de datos
                    applicationDbContext.SaveChanges();

                    return true; // Indica éxito en la eliminación
                }
                else
                {
                    return false; // Indica que no se encontró el grupo con el ID especificado
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción lanzada
                throw ex;
            }
        }

        public List<Grupo> ObtenerTodosLosGrupos()
        {
            try
            {
                // Obtener todos los grupos desde el contexto de la base de datos
                var grupos = applicationDbContext.Grupos.ToList();
                return grupos;
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción lanzada
                throw ex;
            }
        }

        public Grupo ObtenerGrupoPorId(int idGrupo)
        {
            try
            {
                // Obtener el grupo por su ID desde el contexto de la base de datos
                var grupo = applicationDbContext.Grupos.SingleOrDefault(g => g.IdGrupo == idGrupo);
                return grupo;
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción lanzada
                throw ex;
            }
        }
    }
}

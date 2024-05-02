using ADSProject.DB;
using ADSProject.Interfaces;
using ADSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ADSProject.Repositories
{
    public class MateriaRepository : IMateria
    {
        private readonly ApplicationDbContext applicationDbContext;

        public MateriaRepository(ApplicationDbContext context)
        {
            applicationDbContext = context;

           
        }

        public int AgregarMateria(Materia materia)
        {
            try
            {
                // Agregar la nueva materia al contexto de la base de datos
                applicationDbContext.Materias.Add(materia);

                // Guardar los cambios en la base de datos
                applicationDbContext.SaveChanges();

                // Devolver el ID de la materia agregada
                return materia.IdMateria;
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción lanzada
                throw ex;
            }
        }

        public int ActualizarMateria(int idMateria, Materia materia)
        {
            try
            {
                // Obtener la materia existente por su ID
                var materiaExistente = applicationDbContext.Materias.SingleOrDefault(m => m.IdMateria == idMateria);

                if (materiaExistente != null)
                {
                    // Actualizar los valores de la materia existente con los valores de la materia proporcionada
                    materiaExistente.NombreMateria = materia.NombreMateria;

                    // Guardar los cambios en la base de datos
                    applicationDbContext.SaveChanges();

                    return 1; // Indica éxito en la actualización
                }
                else
                {
                    return 0; // Indica que no se encontró la materia con el ID especificado
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción lanzada
                throw ex;
            }
        }

        public bool EliminarMateria(int idMateria)
        {
            try
            {
                // Obtener la materia por su ID
                var materia = applicationDbContext.Materias.SingleOrDefault(m => m.IdMateria == idMateria);

                if (materia != null)
                {
                    // Eliminar la materia del contexto de la base de datos
                    applicationDbContext.Materias.Remove(materia);

                    // Guardar los cambios en la base de datos
                    applicationDbContext.SaveChanges();

                    return true; // Indica éxito en la eliminación
                }
                else
                {
                    return false; // Indica que no se encontró la materia con el ID especificado
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción lanzada
                throw ex;
            }
        }

        public List<Materia> ObtenerTodasLasMaterias()
        {
            try
            {
                // Obtener todas las materias desde el contexto de la base de datos
                var materias = applicationDbContext.Materias.ToList();
                return materias;
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción lanzada
                throw ex;
            }
        }

        public Materia ObtenerMateriaPorId(int idMateria)
        {
            try
            {
                // Obtener la materia por su ID desde el contexto de la base de datos
                var materia = applicationDbContext.Materias.SingleOrDefault(x => x.IdMateria == idMateria);
                return materia;
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción lanzada
                throw ex;
            }
        }
    }
}

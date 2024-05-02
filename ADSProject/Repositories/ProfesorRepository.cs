using ADSProject.DB;
using ADSProject.Interfaces;
using ADSProject.Migrations;
using ADSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ADSProject.Repositories
{
    public class ProfesorRepository : IProfesor
    {
        private readonly ApplicationDbContext applicationDbContext;

        public ProfesorRepository(ApplicationDbContext context)
        {
            applicationDbContext = context;

            
        }

        public int AgregarProfesor(Profesor profesor)
        {
            try
            {
                // Agregar el nuevo profesor al contexto de la base de datos
                applicationDbContext.Profesores.Add(profesor);

                // Guardar los cambios en la base de datos
                applicationDbContext.SaveChanges();

                // Devolver el ID del profesor agregado
                return profesor.IdProfesor;
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción lanzada
                throw ex;
            }
        }

        public int ActualizarProfesor(int idProfesor, Profesor profesor)
        {
            try
            {
                // Obtener el profesor existente por su ID
                var profesorExistente = applicationDbContext.Profesores.SingleOrDefault(p => p.IdProfesor == idProfesor);

                if (profesorExistente != null)
                {
                    // Actualizar los valores del profesor existente con los valores del profesor proporcionado
                    profesorExistente.NombresProfesor = profesor.NombresProfesor;
                    profesorExistente.ApellidosProfesor = profesor.ApellidosProfesor;
                    profesorExistente.Email = profesor.Email;

                    // Guardar los cambios en la base de datos
                    applicationDbContext.SaveChanges();

                    return 1; // Indica éxito en la actualización
                }
                else
                {
                    return 0; // Indica que no se encontró el profesor con el ID especificado
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción lanzada
                throw ex;
            }
        }

        public bool EliminarProfesor(int idProfesor)
        {
            try
            {
                // Obtener el profesor por su ID
                 var profesor = applicationDbContext.Profesores.SingleOrDefault(p => p.IdProfesor == idProfesor);

                if (profesor != null)
                {
                    // Eliminar el profesor del contexto de la base de datos
                    applicationDbContext.Profesores.Remove(profesor);

                    // Guardar los cambios en la base de datos
                    applicationDbContext.SaveChanges();

                    return true; // Indica éxito en la eliminación
                }
                else
                {
                    return false; // Indica que no se encontró el profesor con el ID especificado
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción lanzada
                throw ex;
            }
        }

        public List<Profesor> ObtenerTodosLosProfesores()
        {
            try
            {
                // Obtener todos los profesores desde el contexto de la base de datos
                var profesores = applicationDbContext.Profesores.ToList();
                return profesores;
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción lanzada
                throw ex;
            }
        }

        public Profesor ObtenerProfesorPorId(int idProfesor)
        {
            try
            {
                // Obtener el profesor por su ID desde el contexto de la base de datos
                var profesor = applicationDbContext.Profesores.SingleOrDefault(p => p.IdProfesor == idProfesor);
                return profesor;
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción lanzada
                throw ex;
            }
        }
    }
}

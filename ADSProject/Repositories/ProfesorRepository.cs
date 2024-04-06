using ADSProject.Interfaces;
using ADSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ADSProject.Repositories
{
    public class ProfesorRepository: IProfesor
    {
        private List<Profesor> profesores = new List<Profesor>();

        public ProfesorRepository()
        {
            // Agregar algunos profesores por defecto al inicializar el repositorio
            AgregarProfesor(new Profesor { IdProfesor = 1, NombresProfesor = "Juan", ApellidosProfesor = "Perez", Email = "juan.perez@example.com" });
            AgregarProfesor(new Profesor { IdProfesor = 2, NombresProfesor = "María", ApellidosProfesor = "Gomez", Email = "maria.gomez@example.com" });
        }

        public int AgregarProfesor(Profesor profesor)
        {
            profesor.IdProfesor = profesores.Count + 1;
            profesores.Add(profesor);
            return profesor.IdProfesor;
        }

        public int ActualizarProfesor(int idProfesor, Profesor profesor)
        {
            Profesor profesorExistente = ObtenerProfesorPorId(idProfesor);
            if (profesorExistente != null)
            {
                profesorExistente.NombresProfesor = profesor.NombresProfesor;
                profesorExistente.ApellidosProfesor = profesor.ApellidosProfesor;
                profesorExistente.Email = profesor.Email;
                return 1; // Indica éxito en la actualización
            }
            return 0; // Indica que no se encontró el profesor con el ID especificado
        }

        public bool EliminarProfesor(int idProfesor)
        {
            Profesor profesorExistente = ObtenerProfesorPorId(idProfesor);
            if (profesorExistente != null)
            {
                profesores.Remove(profesorExistente);
                return true; // Indica éxito en la eliminación
            }
            return false; // Indica que no se encontró el profesor con el ID especificado
        }

        public List<Profesor> ObtenerTodosLosProfesores()
        {
            return profesores;
        }

        public Profesor ObtenerProfesorPorId(int idProfesor)
        {
            return profesores.FirstOrDefault(p => p.IdProfesor == idProfesor);
        }
    }
}

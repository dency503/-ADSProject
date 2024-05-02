using System;
using System.Collections.Generic;
using System.Linq;
using ADSProject.DB;
using ADSProject.Interfaces;
using ADSProject.Models;

public class CarreraRepository : ICarrera
{
    private readonly ApplicationDbContext applicationDbContext;

    public CarreraRepository(ApplicationDbContext context)
    {
        applicationDbContext = context;

   
    }


    public int AgregarCarrera(Carrera carrera)
    {
        try
        {
            // Agregar la nueva carrera al contexto de la base de datos
            applicationDbContext.Carreras.Add(carrera);

            // Guardar los cambios en la base de datos
            applicationDbContext.SaveChanges();

            // Devolver el ID de la carrera agregada
            return carrera.IdCarrera;
        }
        catch (Exception ex)
        {
            // Manejar cualquier excepción lanzada
            throw ex;
        }
    }

    public bool ActualizarCarrera(int idCarrera, Carrera carrera)
    {
        try
        {
            // Obtener la carrera existente por su ID
            var carreraExistente = applicationDbContext.Carreras.SingleOrDefault(c => c.IdCarrera == idCarrera);


            if (carreraExistente != null)
            {
                // Actualizar los valores de la carrera existente con los valores de la carrera proporcionada
                carreraExistente.Codigo = carrera.Codigo;
                carreraExistente.Nombre = carrera.Nombre;

                // Guardar los cambios en la base de datos
                applicationDbContext.SaveChanges();

                return true; // Indica éxito en la actualización
            }
            else
            {
                return false; // Indica que no se encontró la carrera con el ID especificado
            }
        }
        catch (Exception ex)
        {
            // Manejar cualquier excepción lanzada
            throw ex;
        }
    }

    public bool EliminarCarrera(int idCarrera)
    {
        try
        {
            // Obtener la carrera por su ID
            var carrera = applicationDbContext.Carreras.SingleOrDefault(c => c.IdCarrera == idCarrera);


            if (carrera != null)
            {
                // Eliminar la carrera del contexto de la base de datos
                applicationDbContext.Carreras.Remove(carrera);

                // Guardar los cambios en la base de datos
                applicationDbContext.SaveChanges();

                return true; // Indica éxito en la eliminación
            }
            else
            {
                return false; // Indica que no se encontró la carrera con el ID especificado
            }
        }
        catch (Exception ex)
        {
            // Manejar cualquier excepción lanzada
            throw ex;
        }
    }

    public List<Carrera> ObtenerTodasLasCarreras()
    {
        try
        {
            // Obtener todas las carreras desde el contexto de la base de datos
            var carreras = applicationDbContext.Carreras.ToList();
            return carreras;
        }
        catch (Exception ex)
        {
            // Manejar cualquier excepción lanzada
            throw ex;
        }
    }

    public Carrera ObtenerCarreraPorId(int idCarrera)
    {
        try
        {
            // Obtener la carrera por su ID desde el contexto de la base de datos
            var carrera = applicationDbContext.Carreras.SingleOrDefault(c => c.IdCarrera == idCarrera);

            return carrera;
        }
        catch (Exception ex)
        {
            // Manejar cualquier excepción lanzada
            throw ex;
        }
    }
}

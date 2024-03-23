using System;
using System.Collections.Generic;
using System.Linq;
using ADSProject.Interfaces;
using ADSProject.Models;

public class CarreraRepository : ICarrera
{
    private List<Carrera> carreras = new List<Carrera>();

    public CarreraRepository()
    {
        // Agregar una carrera por defecto al inicializar el repositorio
        AgregarCarreraPorDefecto();
    }

    private void AgregarCarreraPorDefecto()
    {
        Carrera carreraPorDefecto = new Carrera
        {
            Id = 1,
            Codigo = "I004",
            Nombre = "Ingeneria de sistema"
        };
        carreras.Add(carreraPorDefecto);
    }

    public int AgregarCarrera(Carrera carrera)
    {
        carrera.Id = carreras.Count + 1;
        carreras.Add(carrera);
        return carrera.Id;
    }

    public int ActualizarCarrera(int idCarrera, Carrera carrera)
    {
        Carrera carreraExistente = ObtenerCarreraPorId(idCarrera);
        if (carreraExistente != null)
        {
            carreraExistente.Codigo = carrera.Codigo;
            carreraExistente.Nombre = carrera.Nombre;
            return 1; // Indica éxito en la actualización
        }
        return 0; // Indica que no se encontró la carrera con el ID especificado
    }

    public bool EliminarCarrera(int idCarrera)
    {
        Carrera carreraExistente = ObtenerCarreraPorId(idCarrera);
        if (carreraExistente != null)
        {
            carreras.Remove(carreraExistente);
            return true; // Indica éxito en la eliminación
        }
        return false; // Indica que no se encontró la carrera con el ID especificado
    }

    public List<Carrera> ObtenerTodasLasCarreras()
    {
        return carreras;
    }

    public Carrera ObtenerCarreraPorId(int idCarrera)
    {
        return carreras.FirstOrDefault(c => c.Id == idCarrera);
    }
}

namespace ADSProject.Repositories
{
    using ADSProject.Interfaces;
    using ADSProject.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MateriaRepository : IMateria
    {
        private List<Materia> materias = new List<Materia>();

        public MateriaRepository()
        {
            // Agregar algunas materias por defecto al inicializar el repositorio
            AgregarMateria(new Materia { IdMateria = 1, NombreMateria = "Matemáticas" });
            AgregarMateria(new Materia { IdMateria = 2, NombreMateria = "Ciencias" });
        }

        public int AgregarMateria(Materia materia)
        {
            materia.IdMateria = materias.Count + 1;
            materias.Add(materia);
            return materia.IdMateria;
        }

        public int ActualizarMateria(int idMateria, Materia materia)
        {
            Materia materiaExistente = ObtenerMateriaPorId(idMateria);
            if (materiaExistente != null)
            {
                materiaExistente.NombreMateria = materia.NombreMateria;
                return 1; // Indica éxito en la actualización
            }
            return 0; // Indica que no se encontró la materia con el ID especificado
        }

        public bool EliminarMateria(int idMateria)
        {
            Materia materiaExistente = ObtenerMateriaPorId(idMateria);
            if (materiaExistente != null)
            {
                materias.Remove(materiaExistente);
                return true; // Indica éxito en la eliminación
            }
            return false; // Indica que no se encontró la materia con el ID especificado
        }

        public List<Materia> ObtenerTodasLasMaterias()
        {
            return materias;
        }

        public Materia ObtenerMateriaPorId(int idMateria)
        {
            return materias.FirstOrDefault(m => m.IdMateria == idMateria);
        }
    }

}

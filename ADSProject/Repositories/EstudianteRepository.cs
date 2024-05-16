using ADSProject.DB;
using ADSProject.Interfaces;
using ADSProject.Models;

namespace ADSProject.Repositories
{
    
    public class EstudianteRepository : IEstudiante
    {
        /*    private List<Estudiante> lstEstudiantes = new List<Estudiante>
        {
            new Estudiante()
            {
                IdEstudiante = 1,
                NombresEstudiante = "JUAN CARLOS",
                ApellidosEstudiante = "PEREZ SOSA",
                CodigoEstudiante = "PS2410L1002",
                CorreoEstudiante = "PS2L119L1602@usonsonate.edu.sv"
            }
        };*/
        private readonly ApplicationDbContext applicationDbContext;
        public EstudianteRepository(ApplicationDbContext context)
        {
            applicationDbContext = context;


        }


        public int ActualizarEstudiante(int idEstudiante, Estudiante estudiante)
        {
            try
            {
                // Obtenemos el índice del objeto a actualizar
                // int indice = lstEstudiantes.FindIndex(x => x.IdEstudiante == idEstudiante);

                // Verificamos si se encontró el estudiante con el ID dado
                /* if (indice != -1)
                 {
                     // Actualizamos el estudiante en la lista
                     lstEstudiantes[indice] = estudiante;

                     // Devolvemos el ID del estudiante actualizado
                     return idEstudiante;
                 }
                 else
                 {
                     // Si no se encuentra el estudiante con el ID dado, lanzamos una excepción
                     throw new Exception("No se encontró ningún estudiante con el ID especificado.");
                 }*/
                var item = applicationDbContext.Estudiantes.SingleOrDefault(x => x.IdEstudiante == idEstudiante);
                applicationDbContext.Entry(item).CurrentValues.SetValues(estudiante);
                applicationDbContext.SaveChanges();
                return idEstudiante;
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción lanzada
                throw ex;
            }
        }

        public int AgregarEstudiante(Estudiante estudiante)
        {
            try
            {
                // Validar si existen datos en la lista,
                // y 10 incrementamos en una unidad
                /*  if (lstEstudiantes.Count > 0)
                  {
                      // Si hay estudiantes en la lista, tomamos el último ID y le sumamos 1
                      estudiante.IdEstudiante = lstEstudiantes[lstEstudiantes.Count - 1].IdEstudiante + 1;
                  }
                  else
                  {
                      // Si la lista está vacía, asignamos el ID 1 al primer estudiante
                      estudiante.IdEstudiante = 1;
                  }

                  // Agregar el estudiante a la lista
                  lstEstudiantes.Add(estudiante);*/
                // Agregar el nuevo estudiante al contexto de la base de datos
                applicationDbContext.Estudiantes.Add(estudiante);

                // Guardar los cambios en la base de datos
                applicationDbContext.SaveChanges();


                // Devolver el ID del estudiante agregado
                return estudiante.IdEstudiante;
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción lanzada
                throw ex;
            }
        }

        public bool EliminarEstudiante(int idEstudiante)
        {
            try
            {
                // Obtenemos el índice del objeto a eliminar
                /*//int indice = lstEstudiantes.FindIndex(tmp => tmp.IdEstudiante == idEstudiante);

                // Verificamos si se encontró el estudiante con el ID dado
                if (indice != -1)
                {
                    // Procedemos a eliminar el registro de la lista
                    lstEstudiantes.RemoveAt(indice);
                    return true;
                }
                else
                {
                    // Si no se encuentra el estudiante con el ID especificado, retornamos false
                    return false;
                }*/
                var item = applicationDbContext.Estudiantes.SingleOrDefault(x => x.IdEstudiante == idEstudiante);

                    // Eliminar el estudiante del contexto de la base de datos
                    applicationDbContext.Estudiantes.Remove(item);

                    // Guardar los cambios en la base de datos
                    applicationDbContext.SaveChanges();
                return true;
               
            }
            catch (Exception ex)
            {
                return false;
                // Manejar cualquier excepción lanzada
                throw ex;
            }
        }

        public Estudiante ObtenerEstudiantePorID(int idEstudiante)
        {
            /*try
            {
                // Buscamos y asignamos el objeto estudiante
                Estudiante estudiante = lstEstudiantes.FirstOrDefault(tmp => tmp.IdEstudiante == idEstudiante);

                // Devolvemos el estudiante encontrado
                return estudiante;
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción lanzada
                throw ex;
            }*/
            var estudiante = applicationDbContext.Estudiantes.SingleOrDefault(x => x.IdEstudiante == idEstudiante);
            return estudiante;
        }

        // Implementación del método ObtenerTodosLosEstudiantes
        public List<Estudiante> ObtenerTodosLosEstudiantes()
        {
            try
            {
                // Obtener todos los estudiantes
                var estudiantes = applicationDbContext.Estudiantes.ToList();

                return estudiantes;
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción lanzada
                throw ex;
            }
        }


    }
}

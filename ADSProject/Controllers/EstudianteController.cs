using ADSProject.Interfaces;
using ADSProject.Models; // Asegúrate de tener el using necesario para Estudiante o el espacio de nombres correcto
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore;

namespace ADSProject.Controllers
{
    [Route("api/estudiantes")]
    public class EstudiantesController : ControllerBase
    {
        private readonly IEstudiante estudiante;
        private const string COD_EXITO = "000000"; // Código de éxito
        private const string COD_ERROR = "999999"; // Código de error
        private string pCodRespuesta;
        private string pMensajeUsuario;
        private string pMensajeTecnico;

        public EstudiantesController(IEstudiante estudiante)
        {
            this.estudiante = estudiante;
        }
        // Acción para agregar un estudiante
        [HttpPost("agregarEstudiante")]
        public IActionResult AgregarEstudiante([FromBody] Estudiante estudiante)
        {
            try
            {
                // Intentamos agregar el estudiante
                int contador = this.estudiante.AgregarEstudiante(estudiante);

                if (contador > 0)
                {
                    // Si el contador es mayor que cero, la operación fue exitosa
                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "Registro insertado con éxito";
                }
                else
                {
                    // Si el contador es cero o negativo, ocurrió un problema
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "Ocurrió un problema al insertar el registro";
                }

                // Construimos el mensaje técnico
                pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;

                // Retornamos una respuesta HTTP 200 OK con un objeto JSON que contiene los mensajes
                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
            catch (Exception)
            {
                // Si ocurre una excepción, la lanzamos
                throw;
            }
        }
        [HttpPost("actualizarEstudiante/{idEstudiante}")]
        public ActionResult<string> ActualizarEstudiante(int idEstudiante, [FromBody] Estudiante estudiante)
        {
            try
            {
                // Actualizamos el estudiante
                int contador = this.estudiante.ActualizarEstudiante(idEstudiante, estudiante);

                if (contador > 0)
                {
                    // Si el contador es mayor que cero, la operación fue exitosa
                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "Registro actualizado con éxito";
                }
                else
                {
                    // Si el contador es cero o negativo, ocurrió un problema
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "Ocurrió un problema al actualizar el registro";
                }

                // Construimos el mensaje técnico
                pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;

                // Retornamos una respuesta HTTP 200 OK con un objeto JSON que contiene los mensajes
                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
            catch (Exception)
            {
                // Si ocurre una excepción, la lanzamos
                throw;
            }
        }
        [HttpDelete("eliminarEstudiante/{idEstudiante}")]
        public ActionResult<string> EliminarEstudiante(int idEstudiante)
        {
            try
            {
                // Aquí deberías implementar la lógica para verificar si el estudiante fue eliminado correctamente
                bool eliminado = true; // Por ahora asumimos que el estudiante fue eliminado correctamente

                if (eliminado)
                {
                    // Si el estudiante fue eliminado correctamente, llamamos al método de eliminación
                    estudiante.EliminarEstudiante(idEstudiante);

                    // Establecemos los mensajes de éxito
                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "Registro eliminado con éxito";
                }
                else
                {
                    // Si ocurrió un problema al eliminar el estudiante, establecemos los mensajes de error
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "Ocurrió un problema al eliminar el registro";
                }

                // Construimos el mensaje técnico
                pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;

                // Retornamos una respuesta HTTP 200 OK con un objeto JSON que contiene los mensajes
                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
            catch (Exception)
            {
                // Si ocurre una excepción, la lanzamos
                throw;
            }
        }
        [HttpGet("obtenerEstudiantePorID/{idEstudiante}")]
        public ActionResult<Estudiante> ObtenerEstudiantePorID(int idEstudiante)
        {
            try
            {
                // Obtenemos el estudiante por su ID
                Estudiante estudiante = this.estudiante.ObtenerEstudiantePorID(idEstudiante);

                if (estudiante != null)
                {
                    // Si el estudiante fue encontrado, retornamos una respuesta HTTP 200 OK con el estudiante
                    return Ok(estudiante);
                }
                else
                {
                    // Si no se encontró el estudiante, establecemos los mensajes de error
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "No se encontraron datos del estudiante";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;

                    // Retornamos una respuesta HTTP 404 Not Found con los mensajes de error
                    return NotFound(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
                }
            }
            catch (Exception)
            {
                // Si ocurre una excepción, la lanzamos
                throw;
            }
        }
        [HttpGet("obtenerEstudiantes")]
        public ActionResult<List<Estudiante>> ObtenerEstudiantes()
        {
            try
            {
                // Obtener todos los estudiantes
                List<Estudiante> estudiantes = this.estudiante.ObtenerTodosLosEstudiantes();

                // Si se encontraron estudiantes, retornamos una respuesta HTTP 200 OK con la lista de estudiantes
                if (estudiantes != null && estudiantes.Count > 0)
                {
                    return Ok(estudiantes);
                }
                else
                {
                    // Si no se encontraron estudiantes, establecemos los mensajes de error
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "No se encontraron datos de estudiantes";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;

                    // Retornamos una respuesta HTTP 404 Not Found con los mensajes de error
                    return NotFound(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
                }
            }
            catch (Exception)
            {
                // Si ocurre una excepción, la lanzamos
                throw;
            }
        }
    }
}

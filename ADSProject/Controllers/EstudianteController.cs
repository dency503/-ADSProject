using ADSProject.Interfaces;
using ADSProject.Models;
using ADSProject.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace ADSProject.Controllers
{
    [Route("api/estudiantes/")]
    public class EstudiantesController : ControllerBase
    {
        private readonly IEstudiante estudiante;
        private static readonly int COD_EXITO = CodigoRespuesta.Exito;
        private static readonly int COD_ERROR = CodigoRespuesta.Error;
        private int pCodRespuesta;
        private string pMensajeUsuario;
        private string pMensajeTecnico;

        public EstudiantesController(IEstudiante estudiante)
        {
            this.estudiante = estudiante;
        }
        [HttpPost("agregarEstudiante")]
        public ActionResult<string> AgregarEstudiante([FromBody] Estudiante estudiante)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                int contador = this.estudiante.AgregarEstudiante(estudiante);
                if (contador > 0)
                {
                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "Registro insertado con exito";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "Ocurrio un problema al insertar el registro";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }
                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPut("actualizarEstudiante/{idEstudiante}")]
        public ActionResult<string> ActualizarEstudiante(int idEstudiante, [FromBody] Estudiante estudiante)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                int contador = this.estudiante.ActualizarEstudiante(idEstudiante, estudiante);
                if (contador > 0)
                {
                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "Registro actualizado con exito";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "Ocurrio un problema al actualizar el registro";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }
                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpDelete("eliminarEstudiante/{idEstudiante}")]
        public ActionResult<string> EliminarEstudiante(int idEstudiante)
        {
            try
            {
                bool eliminado = this.estudiante.EliminarEstudiante(idEstudiante);
                if (eliminado)
                {
                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "Registro eliminado con exito";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "Ocurrio un problema al eliminar el registro";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }
                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet("obtenerEstudiantePorID/{idEstudiante}")]
        public ActionResult<string> ObtenerEstudiante(int idEstudiante)
        {
            try
            {
                Estudiante estudiante = this.estudiante.ObtenerEstudiantePorID(idEstudiante);
                if (estudiante != null)
                {
                    return Ok(estudiante);
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "No se encontraron datos del estudiante";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                    return NotFound(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet("obtenerEstudiantes")]
        public ActionResult<List<Estudiante>> ObtenerEstudiantes()
        {
            try
            {
                List<Estudiante> lstEstudiantes = this.estudiante.ObtenerTodosLosEstudiantes();
                return Ok(lstEstudiantes);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
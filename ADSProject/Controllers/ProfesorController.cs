using ADSProject.Interfaces;
using ADSProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ADSProject.Controllers
{
    [Route("api/profesores")]
    public class ProfesoresController : ControllerBase
    {
        private readonly IProfesor _profesor;
        private static readonly int COD_EXITO = CodigoRespuesta.Exito;
        private static readonly int COD_ERROR = CodigoRespuesta.Error;
        private int pCodRespuesta;
        private string pMensajeUsuario;
        private string pMensajeTecnico;

        public ProfesoresController(IProfesor profesor)
        {
            _profesor = profesor;
        }

        [HttpPost("agregarProfesor")]
        public IActionResult AdicionarProfesor([FromBody] Profesor profesor)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                int contador = _profesor.AgregarProfesor(profesor);

                if (contador > 0)
                {
                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "Registro insertado con éxito";
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "Ocurrió un problema al insertar el registro";
                }

                pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;

                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("actualizarProfesor/{idProfesor}")]
        public ActionResult<string> ActualizarProfessor(int idProfesor, [FromBody] Profesor profesor)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                int contador = _profesor.ActualizarProfesor(idProfesor, profesor);

                if (contador > 0)
                {
                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "Registro actualizado con sucesso";
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "Ocurrido un problema al actualizar o registro";
                }

                pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;

                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("eliminarProfesor/{idProfesor}")]
        public ActionResult<string> EliminarProfesor(int idProfesor)
        {
            try
            {
                bool eliminado = true; // Por ahora asumimos que el profesor fue eliminado correctamente

                if (eliminado)
                {
                    _profesor.EliminarProfesor(idProfesor);

                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "Registro eliminado con éxito";
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "Ocurrió un problema al eliminar el registro";
                }

                pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;

                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("obtenerProfesorPorId/{idProfesor}")]
        public ActionResult<Profesor> ObtnerProfessorPorId(int idProfesor)
        {
            try
            {
                Profesor profesor = _profesor.ObtenerProfesorPorId(idProfesor);

                if (profesor != null)
                {
                    return Ok(profesor);
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "No se encontraron datos del profesor";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;

                    return NotFound(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("obtnerProfesores")]
        public ActionResult<List<Profesor>> ObterProfesores()
        {
            try
            {
                List<Profesor> profesores = _profesor.ObtenerTodosLosProfesores();

                if (profesores != null && profesores.Count > 0)
                {
                    return Ok(profesores);
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "No se encontraron datos de profesores";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;

                    return NotFound(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
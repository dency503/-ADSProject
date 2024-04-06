using ADSProject.Interfaces;
using ADSProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ADSProject.Controllers
{
    [Route("api/grupos")]
    public class GrupoController : ControllerBase
    {
        private readonly IGrupo _grupo;
        private static readonly int COD_EXITO = CodigoRespuesta.Exito;
        private static readonly int COD_ERROR = CodigoRespuesta.Error;
        private int pCodRespuesta;
        private string pMensajeUsuario;
        private string pMensajeTecnico;

        public GrupoController(IGrupo grupo)
        {
            _grupo = grupo;
        }

        [HttpPost("agregarGrupo")]
        public IActionResult AgregarGrupo([FromBody] Grupo grupo)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                int contador = _grupo.AgregarGrupo(grupo);

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

                pMensajeTecnico = $"{pCodRespuesta} || {pMensajeUsuario}";

                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("actualizarGrupo/{idGrupo}")]
        public IActionResult ActualizarGrupo(int idGrupo, [FromBody] Grupo grupo)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                int contador = _grupo.ActualizarGrupo(idGrupo, grupo);

                if (contador > 0)
                {
                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "Registro actualizado con éxito";
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "Ocurrió un problema al actualizar el registro";
                }

                pMensajeTecnico = $"{pCodRespuesta} || {pMensajeUsuario}";

                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("eliminarGrupo/{idGrupo}")]
        public IActionResult EliminarGrupo(int idGrupo)
        {
            try
            {
                bool eliminado = _grupo.EliminarGrupo(idGrupo);

                if (eliminado)
                {
                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "Registro eliminado con éxito";
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "Ocurrió un problema al eliminar el registro";
                }

                pMensajeTecnico = $"{pCodRespuesta} || {pMensajeUsuario}";

                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("obtenerGrupoPorId/{idGrupo}")]
        public IActionResult ObtenerGrupoPorId(int idGrupo)
        {
            try
            {
                Grupo grupo = _grupo.ObtenerGrupoPorId(idGrupo);

                if (grupo != null)
                {
                    return Ok(grupo);
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "No se encontraron datos del grupo";
                    pMensajeTecnico = $"{pCodRespuesta} || {pMensajeUsuario}";

                    return NotFound(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet()]
        public IActionResult ObtenerTodosLosGrupos()
        {
            try
            {
                List<Grupo> grupos = _grupo.ObtenerTodosLosGrupos();

                if (grupos != null && grupos.Count > 0)
                {
                    return Ok(grupos);
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "No se encontraron datos de grupos";
                    pMensajeTecnico = $"{pCodRespuesta} || {pMensajeUsuario}";

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

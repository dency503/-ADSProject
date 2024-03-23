using ADSProject.Interfaces;
using ADSProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ADSProject.Controllers
{
    [Route("api/carreras")]
    [ApiController]
    public class CarreraController : ControllerBase
    {
        private readonly ICarrera carreraRepository;
        // Código de éxito
        private static readonly string COD_EXITO = CodigoRespuesta.Exito.ToString();

        private static readonly string COD_ERROR = CodigoRespuesta.Error.ToString();
        private string pCodRespuesta;
        private string pMensajeUsuario;
        private string pMensajeTecnico;

        public CarreraController(ICarrera carreraRepository)
        {
            this.carreraRepository = carreraRepository;
        }

        [HttpGet]
        public ActionResult<List<Carrera>> ObtenerTodasLasCarreras()
        {
            try
            {
                var carreras = carreraRepository.ObtenerTodasLasCarreras();
                return Ok(carreras);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("obtenerCarreraPorId/{id}")]
        public ActionResult<Carrera> ObtenerCarreraPorId(int id)
        {
            try
            {
                var carrera = carreraRepository.ObtenerCarreraPorId(id);
                if (carrera == null)
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "No se encontraron datos de la carrera";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;

                    return NotFound(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
                }
                return Ok(carrera);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("agregarCarrera")]
        public ActionResult<int> AgregarCarrera([FromBody] Carrera carrera)
        {
            try
            {
                var id = carreraRepository.AgregarCarrera(carrera);
                pCodRespuesta = COD_EXITO;
                pMensajeUsuario = "Registro insertado con éxito";
                pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;

                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("modificarCarrera/{id}")]
        public ActionResult ActualizarCarrera(int id, [FromBody] Carrera carrera)
        {
            try
            {
                var result = carreraRepository.ActualizarCarrera(id, carrera);
                if (result == 0)
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "Ocurrió un problema al actualizar el registro";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;

                    return NotFound(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("eliminarCarrera/{id}")]
        public ActionResult EliminarCarrera(int id)
        {
            try
            {
                var result = carreraRepository.EliminarCarrera(id);
                if (!result)
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "Ocurrió un problema al eliminar el registro";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;

                    return NotFound(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}

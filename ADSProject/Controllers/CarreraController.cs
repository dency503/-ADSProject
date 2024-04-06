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
        private static readonly int COD_EXITO = CodigoRespuesta.Exito;
        private static readonly int COD_ERROR = CodigoRespuesta.Error;
        private int pCodRespuesta;
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
                int pCodRespuesta;
                string pMensajeUsuario, pMensajeTecnico;

                if (carreras.Count > 0)
                {
                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "Carreras obtenidas exitosamente";
                    pMensajeTecnico = $"{pCodRespuesta} || {pMensajeUsuario}";

                    return Ok( carreras );
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "No se encontraron carreras";
                    pMensajeTecnico = $"{pCodRespuesta} || {pMensajeUsuario}";

                    return NotFound(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("obtenerCarreraPorId/{id}")]
        public ActionResult<int> ObtenerCarreraPorId(int id)
        {
            try
            {
                var carrera = carreraRepository.ObtenerCarreraPorId(id);
                int pCodRespuesta;
                string pMensajeUsuario, pMensajeTecnico;

                if (carrera != null)
                {
                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "Datos de la carrera obtenidos con éxito";
                    pMensajeTecnico = $"{pCodRespuesta} || {pMensajeUsuario}";

                    return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico, carrera });
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "No se encontraron datos de la carrera";
                    pMensajeTecnico = $"{pCodRespuesta} || {pMensajeUsuario}";

                    return NotFound(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("agregarCarrera")]
        public ActionResult<int> AgregarCarrera([FromBody] Carrera carrera)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var id = carreraRepository.AgregarCarrera(carrera);
                int pCodRespuesta;
                string pMensajeUsuario, pMensajeTecnico;

                if (id > 0)
                {
                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "Registro insertado con éxito";
                    pMensajeTecnico = $"{pCodRespuesta} || {pMensajeUsuario}";
                    return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "Ocurrió un problema al insertar el registro";
                    pMensajeTecnico = $"{pCodRespuesta} || {pMensajeUsuario}";

                    return NotFound(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
                }

            

            }
            catch (Exception ex)
            {
                throw;
            }
        }


        [HttpPut("actualizarCarrera/{id}")]
        public ActionResult<int> ActualizarCarrera(int id, [FromBody] Carrera carrera)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                int contador = carreraRepository.ActualizarCarrera(id, carrera);
                int pCodRespuesta;
                string pMensajeUsuario, pMensajeTecnico;

                if (contador > 0)
                {
                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "Registro actualizado con éxito";
                    pMensajeTecnico = $"{pCodRespuesta} || {pMensajeUsuario}";

                    return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
                }
                else { 
                pCodRespuesta = COD_ERROR;
                pMensajeUsuario = "Ocurrió un problema al actualizar el registro";
                pMensajeTecnico = $"{pCodRespuesta} || {pMensajeUsuario}";

                return NotFound(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        [HttpDelete("eliminarCarrera/{id}")]
        public ActionResult<int> EliminarCarrera(int id)
        {
            try
            {
                Boolean contador = carreraRepository.EliminarCarrera(id);
                int pCodRespuesta;
                string pMensajeUsuario, pMensajeTecnico;

                if (contador)
                {
                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "Registro eliminado con éxito"; pMensajeTecnico = $"{pCodRespuesta} || {pMensajeUsuario}";
                    return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "Ocurrió un problema al eliminar el registro";
                    pMensajeTecnico = $"{pCodRespuesta} || {pMensajeUsuario}";
                    return NotFound(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
                }
                  
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}

using ADSProject.Interfaces;
using ADSProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace ADSProject.Controllers
{
    namespace ADSProject.Controllers
    {
        [Route("api/carreras")]
        [ApiController]
        public class CarreraController : ControllerBase
        {
            private readonly ICarrera carreraRepository;

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
                        return NotFound();
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
                    return Ok(id);
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
                        return NotFound();
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
                        return NotFound();
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
}

using Microsoft.AspNetCore.Mvc;
using webAPI.Database;
using webAPI.Models;

namespace webAPI.Controllers
{
    [ApiController]
    [Route("api/Localidades")]
    public class LocalidadController(AppDbContext context) : Controller
    {
        [HttpGet]
        public ActionResult<IEnumerable<Localidad>> GetLocalidades()
        {
			try
			{
				var localidades = context.Localidades.ToList();
				
                return Ok(localidades);
			}
			catch (Exception ex)
			{
                return BadRequest($"Ocurrió un error al procesar la solicitud: {ex.Message}");
            }
        }

        [HttpGet("{idLocalidad}")]
        public ActionResult<Localidad> GetLocalidad(int idLocalidad)
        {
            try
            {
                var localidad = context.Localidades.FirstOrDefault(l => l.Id == idLocalidad);

                if (localidad is null)
                {
                    throw new Exception("¡Registro no encontrado!");
                }

                return Ok(localidad);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocurrió un error al procesar la solicitud: {ex.Message}");
            }
        }
    }
}

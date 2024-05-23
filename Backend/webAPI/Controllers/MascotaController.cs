using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webAPI.Database;
using webAPI.DTOs;
using webAPI.Models;
using webAPI.Services.Interfaces;

namespace webAPI.Controllers
{
    [ApiController]
    [Route("api/Mascotas")]
    public class MascotaController(IMascotaService mascotaService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetMascotaDTO>>> LeerTodo()
        {
            try
            {
                var mascotas = await mascotaService.LeerTodoAsync();

                if (mascotas == null)
                {
                    return NotFound("¡Aún no hay registros!");
                }

                return Ok(mascotas);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocurrió un error al procesar la solicitud: {ex.Message}");
            }
        }

        [HttpGet("{idMascota}")]
        public async Task<ActionResult<GetMascotaDTO>> LeerUno(int idMascota)
        {
            try
            {
                var mascota = await mascotaService.LeerUnoAsync(idMascota);
                
                if (mascota == null)
                {
                    return NotFound("¡Registro no encontrado!");
                }

                return mascota;
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocurrió un error al procesar la solicitud: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Crear(MascotaDTO mascotaDTO)
        {
            try
            {
                await mascotaService.CrearAsync(mascotaDTO);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocurrió un error al procesar la solicitud: {ex.Message}");
            }
        }

        [HttpPut("{idMascota}")]
        public async Task<ActionResult> Actualizar(int idMascota, MascotaDTO mascotaDTO)
        {
            try
            {
                await mascotaService.ActualizarAsync(idMascota, mascotaDTO);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocurrió un error al procesar la solicitud: {ex.Message}");
            }
        }

        [HttpDelete("{idMascota}")]
        public async Task<ActionResult> Eliminar(int idMascota)
        {
            try
            {
                await mascotaService.EliminarAsync(idMascota);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocurrió un error al procesar la solicitud: {ex.Message}");
            }
        }
    }
}

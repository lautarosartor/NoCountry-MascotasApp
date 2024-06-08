using Microsoft.AspNetCore.Mvc;
using webAPI.DTOs;
using webAPI.Models;
using webAPI.Services;
using webAPI.Services.Interfaces;

namespace webAPI.Controllers
{
    [ApiController]
    [Route("api/Usuarios")]
    public class UsuarioController(IUsuarioService usuarioService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> LeerTodo()
        {
            try
            {
                var usuarios = await usuarioService.LeerTodoAsync();

                if (!usuarios.Any())
                {
                    return NotFound("¡Aún no hay registros!");
                }

                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocurrió un error al procesar la solicitud: {ex.Message}");
            }
        }

        [HttpGet("{idUsuario}")]
        public async Task<ActionResult<UsuarioDTO>> LeerUno(int idUsuario)
        {
            try
            {
                var usuario = await usuarioService.LeerUnoAsync(idUsuario);

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocurrió un error al procesar la solicitud: {ex.Message}");
            }
        }

        /*[HttpPut("{idUsuario}")]
        public async Task<ActionResult> Actualizar(int idUsuario, ModificarUsuarioDTO usuarioDTO)
        {
            try
            {
                await usuarioService.ActualizarAsync(idUsuario, usuarioDTO);

                return Ok("Usuario modificado correctamente.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocurrió un error al procesar la solicitud: {ex.Message}");
            }
        }*/

        [HttpDelete("{idUsuario}")]
        public async Task<ActionResult> Eliminar(int idUsuario)
        {
            try
            {
                await usuarioService.EliminarAsync(idUsuario);

                return Ok("Registro eliminado con éxito.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocurrió un error al procesar la solicitud: {ex.Message}");
            }
        }
    }
}

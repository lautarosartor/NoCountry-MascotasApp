using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using webAPI.DTOs;
using webAPI.Models;
using webAPI.Services;

namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> GetUsuarios()
        {
            try
            {
                var usuarios = await _usuarioService.GetUsuariosAsync();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                // Log the exception (consider using a logging framework)
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDTO>> GetUsuario(int id)
        {
            try
            {
                var usuario = await _usuarioService.GetUsuarioByIdAsync(id);
                if (usuario == null)
                {
                    return NotFound();
                }
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                // Log the exception (consider using a logging framework)
                return StatusCode(500, "Internal server error");
            }
        }

        // POST:
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            try
            {
                var createdUsuario = await _usuarioService.AddUsuarioAsync(usuario);
                return CreatedAtAction(nameof(GetUsuario), new { id = createdUsuario.Id }, createdUsuario);
            }
            catch (Exception ex)
            {
                // Log the exception (consider using a logging framework)
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT:
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest();
            }

            try
            {
                var updatedUsuario = await _usuarioService.UpdateUsuarioAsync(usuario);
                if (updatedUsuario == null)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception (consider using a logging framework)
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            try
            {
                var deleted = await _usuarioService.DeleteUsuarioAsync(id);
                if (!deleted)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception (consider using a logging framework)
                return StatusCode(500, "Internal server error");
            }
        }
    }
}

//GET, POST, PUT, DELETE


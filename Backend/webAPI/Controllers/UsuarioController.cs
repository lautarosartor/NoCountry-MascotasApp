using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webAPI.Database;
using webAPI.Models;

namespace webAPI.Controllers
{
    [ApiController]
    [Route("api/Usuarios")]
    public class UsuarioController(AppDbContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await context.Usuarios.ToListAsync();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using webAPI.Controllers;
using webAPI.Database;
using webAPI.DTOs;
using webAPI.Models;
using webAPI.Repositories.Interfaces;

namespace webAPI.Repositories
{
    public class UsuarioRepository(AppDbContext context) : IUsuarioRepository
    {
        public async Task<IEnumerable<UsuarioDTO>> LeerTodoAsync()
        {
            var usuarios = await context.Usuarios
                .Where(u => !u.Borrado)
                .Include(u => u.Rol)
                .Select(u => new UsuarioDTO
                {
                    Id = u.Id,
                    Nombre = u.Nombre,
                    Apellido = u.Apellido,
                    Email = u.Email,
                    Rol = u.Rol.Nombre,
                    Provincia = u.Provincia.Nombre,
                    Localidad = u.Localidad.Nombre,
                })
                .ToListAsync();

            return usuarios;
        }

        public async Task<UsuarioDTO> LeerUnoAsync(string email)
        {
            var usuario = await context.Usuarios
                .Where(u => !u.Borrado && u.Email == email)
                .Include(u => u.Rol)
                .Include(u => u.Provincia)
                .Include(u => u.Localidad)
                .Select(u => new UsuarioDTO
                {
                    Id = u.Id,
                    Nombre = u.Nombre,
                    Apellido = u.Apellido,
                    Email = u.Email,
                    Direccion = u.Direccion,
                    Descripcion = u.Descripcion,
                    Rol = u.Rol.Nombre,
                    Provincia = u.Provincia.Nombre,
                    Localidad = u.Localidad.Nombre
                })
                .FirstOrDefaultAsync();

            if (usuario is null)
            {
                throw new Exception("¡Usuario no encontrado!");
            }

            return usuario;
        }

        public async Task EliminarAsync(int idUsuario)
        {
            var usuario = await context.Usuarios
                .Where(u => !u.Borrado && u.Id == idUsuario)
                .FirstOrDefaultAsync();

            if (usuario is null)
            {
                throw new Exception("¡Usuario no encontrado!");
            }

            // Damos de baja logica el registro
            usuario.Borrado = true;

            // Aplicamos los cambios
            await context.SaveChangesAsync();
        }
    }
}

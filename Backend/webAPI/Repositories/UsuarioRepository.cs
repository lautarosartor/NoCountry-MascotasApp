using Microsoft.EntityFrameworkCore;
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
                    Rol = u.Rol.Nombre
                })
                .ToListAsync();

            return usuarios;
        }

        public async Task<UsuarioDTO> LeerUnoAsync(int idUsuario)
        {
            var usuario = await context.Usuarios
                .Where(u => !u.Borrado && u.Id == idUsuario)
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

        // Capaz esto se hace en el AccountController por el tema de la password
        public async Task ActualizarAsync(int idUsuario, ModificarUsuarioDTO usuarioDTO)
        {
            var usuario = await context.Usuarios
                .Where(u => !u.Borrado && u.Id == idUsuario)
                .FirstOrDefaultAsync();

            if (usuario is null)
            {
                throw new Exception("¡Usuario no encontrado!");
            }

            // Asignamos los nuevos valores a los campos que se pueden modificar
            usuario.Nombre = usuarioDTO.Nombre;
            usuario.Apellido = usuarioDTO.Apellido;
            usuario.Direccion = usuarioDTO.Direccion;
            usuario.Descripcion = usuarioDTO.Descripcion;
            usuario.IdProvincia = usuarioDTO.IdProvincia;
            usuario.IdLocalidad = usuarioDTO.IdLocalidad;
            // Ver como actualizar la password

            // Aplicamos los cambios
            await context.SaveChangesAsync();
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

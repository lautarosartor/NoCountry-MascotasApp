using Microsoft.EntityFrameworkCore;
using webAPI.Database;
using webAPI.DTOs;
using webAPI.Models;

namespace webAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UsuarioDTO>> GetUsuariosAsync()
        {
            return await _context.Usuarios
                .Select(u => new UsuarioDTO
                {
                    Id = u.Id,
                    Nombre = u.Nombre,
                    Apellido = u.Apellido,
                    Email = u.Email,
                    Descripcion = u.Descripcion,
                    Rol = u.Rol.Nombre,
                    Provincia = u.Provincia.Nombre,
                    Localidad = u.Localidad.Nombre
                })
                .ToListAsync();
        }
        public async Task<UsuarioDTO> GetUsuarioByIdAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return null;
            }
            return new UsuarioDTO 
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Email = usuario.Email,
                Descripcion = usuario.Descripcion,
                Rol = usuario.Rol.Nombre,
                Provincia = usuario.Provincia.Nombre,
                Localidad = usuario.Localidad.Nombre
            };
        }

        public async Task<Usuario> AddUsuarioAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> UpdateUsuarioAsync(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<bool> DeleteUsuarioAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return false;
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
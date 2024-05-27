
using webAPI.DTOs;
using webAPI.Models;

namespace webAPI.Services
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioDTO>> GetUsuariosAsync();
        Task<UsuarioDTO> GetUsuarioByIdAsync(int id);
        Task<Usuario> AddUsuarioAsync(Usuario usuario);
        Task<Usuario> UpdateUsuarioAsync(Usuario usuario);
        Task<bool> DeleteUsuarioAsync(int id);
    }
}




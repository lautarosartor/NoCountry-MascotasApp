
using webAPI.DTOs;
using webAPI.Models;

namespace webAPI.Repositories
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<UsuarioDTO>> GetUsuariosAsync();
        Task<UsuarioDTO> GetUsuarioByIdAsync(int id);
        Task<Usuario> AddUsuarioAsync(Usuario usuario);
        Task<Usuario> UpdateUsuarioAsync(Usuario usuario);
        Task<bool> DeleteUsuarioAsync(int id);

    }
}




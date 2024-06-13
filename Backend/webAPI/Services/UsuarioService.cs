using webAPI.DTOs;
using webAPI.Repositories.Interfaces;
using webAPI.Services.Interfaces;

namespace webAPI.Services
{
    public class UsuarioService(IUsuarioRepository usuarioRepository) : IUsuarioService
    {
        public async Task<IEnumerable<UsuarioDTO>> LeerTodoAsync()
        {
            return await usuarioRepository.LeerTodoAsync();
        }

        public async Task<UsuarioDTO> LeerUnoAsync(string email)
        {
            return await usuarioRepository.LeerUnoAsync(email);
        }

        public async Task EliminarAsync(int idUsuario)
        {
            await usuarioRepository.EliminarAsync(idUsuario);
        }
    }
}

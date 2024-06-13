using webAPI.DTOs;

namespace webAPI.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<UsuarioDTO>> LeerTodoAsync();

        Task<UsuarioDTO> LeerUnoAsync(string email);

        Task EliminarAsync (int idUsuario);
    }
}

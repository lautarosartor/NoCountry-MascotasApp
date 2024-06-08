using webAPI.DTOs;

namespace webAPI.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<UsuarioDTO>> LeerTodoAsync();

        Task<UsuarioDTO> LeerUnoAsync(int idUsuario);

        Task EliminarAsync (int idUsuario);
    }
}

using webAPI.DTOs;

namespace webAPI.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioDTO>> LeerTodoAsync();

        Task<UsuarioDTO> LeerUnoAsync(int idUsuario);

        Task EliminarAsync(int idUsuario);
    }
}

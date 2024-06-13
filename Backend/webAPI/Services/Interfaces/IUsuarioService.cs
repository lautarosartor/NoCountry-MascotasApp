using webAPI.DTOs;

namespace webAPI.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioDTO>> LeerTodoAsync();

        Task<UsuarioDTO> LeerUnoAsync(string email);

        Task EliminarAsync(int idUsuario);
    }
}

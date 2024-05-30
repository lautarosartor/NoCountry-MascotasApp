using webAPI.DTOs;

namespace webAPI.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioDTO>> LeerTodoAsync();

        Task<UsuarioDTO> LeerUnoAsync(int idUsuario);

        Task ActualizarAsync(int idUsuario, ModificarUsuarioDTO usuarioDTO);

        Task EliminarAsync(int idUsuario);
    }
}

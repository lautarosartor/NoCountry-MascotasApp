using webAPI.DTOs;

namespace webAPI.Repositories.Interfaces
{
    public interface ISolicitudRepository
    {
        Task<IEnumerable<GetSolicitudDTO>> LeerTodoAsync();

        Task<IEnumerable<GetSolicitudDTO>> SolicitudesUsuarioAsync(string email);

        Task<GetSolicitudDTO> LeerUnoAsync(int idSolicitud);

        Task CrearAsync(SolicitudDTO solicitudDTO);

        Task ConfirmarCancelarAsync(int idSolicitud, EstadoSolicitudDTO estadoSolicitudDTO);
    }
}

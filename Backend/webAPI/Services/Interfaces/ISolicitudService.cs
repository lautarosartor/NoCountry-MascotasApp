using webAPI.DTOs;
using webAPI.Models;

namespace webAPI.Services.Interfaces
{
    public interface ISolicitudService
    {
        Task<IEnumerable<GetSolicitudDTO>> LeerTodoAsync();

        Task<GetSolicitudDTO> LeerUnoAsync(int idSolicitud);

        Task CrearAsync(SolicitudDTO solicitud);

        Task ConfirmarCancelarAsync(int idSolicitud, EstadoSolicitudDTO estadoSolicitudDTO);
    }
}

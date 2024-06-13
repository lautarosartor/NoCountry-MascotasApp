using webAPI.DTOs;

namespace webAPI.Services.Interfaces
{
    public interface ISolicitudService
    {
        Task<IEnumerable<GetSolicitudDTO>> Get(int? idMascota, string? estado, string? email = null);

        Task<GetSolicitudDTO> LeerUnoAsync(int idSolicitud);

        Task CrearAsync(SolicitudDTO solicitud);

        Task ConfirmarCancelarAsync(int idSolicitud, EstadoSolicitudDTO estadoSolicitudDTO);
    }
}

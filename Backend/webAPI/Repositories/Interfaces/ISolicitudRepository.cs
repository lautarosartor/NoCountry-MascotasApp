using webAPI.DTOs;

namespace webAPI.Repositories.Interfaces
{
    public interface ISolicitudRepository
    {
        Task<IEnumerable<GetSolicitudDTO>> Get(int? idMascota, string? estado, string? email = null);

        Task<GetSolicitudDTO> LeerUnoAsync(int idSolicitud);

        Task CrearAsync(SolicitudDTO solicitudDTO);

        Task ConfirmarCancelarAsync(int idSolicitud, EstadoSolicitudDTO estadoSolicitudDTO);
    }
}

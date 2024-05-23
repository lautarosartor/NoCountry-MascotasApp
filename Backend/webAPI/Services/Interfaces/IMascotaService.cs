using webAPI.DTOs;

namespace webAPI.Services.Interfaces
{
    // Esta define los métodos relacionados con la gestión de mascotas en la lógica de negocio.
    public interface IMascotaService
    {
        Task<IEnumerable<GetMascotaDTO>> LeerTodoAsync();

        Task<GetMascotaDTO> LeerUnoAsync(int idMascota);

        Task CrearAsync(MascotaDTO mascotaDTO);

        Task ActualizarAsync(int idMascota, MascotaDTO mascotaDTO);

        Task EliminarAsync(int idMascota);
    }
}

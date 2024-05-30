using webAPI.DTOs;

namespace webAPI.Repositories.Interfaces
{
    // Dentro de la interfaz colocaremos que métodos vamos a necesitar dentro de mi ProductoRepository
    // Es decir, qué acciones tendra mi repository (en la mayoria de los casos minimamente seria el CRUD)
    public interface IMascotaRepository
    {
        Task<IEnumerable<GetMascotaDTO>> LeerTodoAsync();

        Task<GetMascotaDTO> LeerUnoAsync(int idMascota);

        Task CrearAsync(MascotaDTO mascotaDTO);

        Task ActualizarAsync(int idMascota, MascotaDTO mascotaDTO);

        Task EliminarAsync(int idMascota);
    }
}

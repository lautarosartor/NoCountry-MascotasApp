using webAPI.DTOs;
using webAPI.Models;
using webAPI.Repositories.Interfaces;
using webAPI.Services.Interfaces;

namespace webAPI.Services
{
    // Hacemos uso del repositorio correspondiente
    public class MascotaService(IMascotaRepository mascotaRepository) : IMascotaService
    {
        public async Task<IEnumerable<GetMascotaDTO>> Get(string? email = null)
        {
            return await mascotaRepository.Get(email);
        }

        public async Task<GetMascotaDTO> LeerUnoAsync(int idMascota)
        {
            return await mascotaRepository.LeerUnoAsync(idMascota);
        }

        public async Task CrearAsync(MascotaDTO mascotaDTO)
        {
            await mascotaRepository.CrearAsync(mascotaDTO);
        }

        public async Task ActualizarAsync(int idMascota, MascotaDTO mascotaDTO)
        {
            await mascotaRepository.ActualizarAsync(idMascota, mascotaDTO);
        }

        public async Task EliminarAsync(int idMascota)
        {
            await mascotaRepository.EliminarAsync(idMascota);
        }
    }
}

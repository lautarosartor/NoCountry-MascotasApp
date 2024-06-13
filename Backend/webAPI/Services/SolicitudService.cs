﻿using webAPI.DTOs;
using webAPI.Models;
using webAPI.Repositories.Interfaces;
using webAPI.Services.Interfaces;

namespace webAPI.Services
{
    public class SolicitudService(ISolicitudRepository solicitudRepository) : ISolicitudService
    {
        public async Task<IEnumerable<GetSolicitudDTO>> Get(int? idMascota, string? estado, string? email = null)
        {
            return await solicitudRepository.Get(idMascota, estado, email);
        }

        public async Task<GetSolicitudDTO> LeerUnoAsync(int idSolicitud)
        {
            return await solicitudRepository.LeerUnoAsync(idSolicitud);
        }

        public async Task CrearAsync(SolicitudDTO solicitudDTO)
        {
            await solicitudRepository.CrearAsync(solicitudDTO);
        }

        public async Task ConfirmarCancelarAsync(int idSolicitud, EstadoSolicitudDTO estadoSolicitudDTO)
        {
            await solicitudRepository.ConfirmarCancelarAsync(idSolicitud, estadoSolicitudDTO);
        }
    }
}

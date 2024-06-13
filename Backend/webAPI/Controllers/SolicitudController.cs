﻿using Microsoft.AspNetCore.Mvc;
using webAPI.DTOs;
using webAPI.Services.Interfaces;

namespace webAPI.Controllers
{
    [ApiController]
    [Route("api/Solicitud")]
    public class SolicitudController(ISolicitudService solicitudService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetSolicitudDTO>>> Get([FromQuery] int? idMascota, string? estado, string? email = null)
        {
            try
            {
                var solicitudes = await solicitudService.Get(idMascota, estado, email);

                if (!solicitudes.Any())
                {
                    throw new Exception("¡Aún no realizó ninguna solicitud!");
                }

                return Ok(solicitudes);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocurrió un error al procesar la solicitud: {ex.Message}");
            }
        }

        [HttpGet("{idSolicitud}")]
        public async Task<ActionResult<GetSolicitudDTO>> LeerUno(int idSolicitud)
        {
            try
            {
                var solicitud = await solicitudService.LeerUnoAsync(idSolicitud);

                return Ok(solicitud);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocurrió un error al procesar la solicitud: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Crear(SolicitudDTO solicitudDTO)
        {
            try
            {
                await solicitudService.CrearAsync(solicitudDTO);

                return Ok("Mascota solicitada con con éxito.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocurrió un error al procesar la solicitud: {ex.Message}");
            }
        }

        [HttpPut("{idSolicitud}")]
        public async Task<ActionResult> ActualizarEstado(int idSolicitud, EstadoSolicitudDTO estadoSolicitudDTO)
        {
            try
            {
                await solicitudService.ConfirmarCancelarAsync(idSolicitud, estadoSolicitudDTO);

                return Ok($"Solicitud ha sido {estadoSolicitudDTO.Estado} correctamente.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocurrió un error al procesar la solicitud: {ex.Message}");
            }
        }
    }
}

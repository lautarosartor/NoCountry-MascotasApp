﻿namespace webAPI.DTOs
{
    public class GetSolicitudDTO
    {
        public int Id { get; set; }

        public string NombreUsuario { get; set; } = string.Empty;

        public string NombreMascota { get; set; } = string.Empty;

        public int IdUsuario { get; set; }

        public int IdMascota { get; set; }

        public DateTime Fecha { get; set; }

        public string Estado { get; set; } = string.Empty;
    }

    public class SolicitudDTO
    {
        public string EmailUsuario { get; set; } = string.Empty;

        public int IdMascota { get; set; }

        //public int IdUsuario { get; set; }
    }

    public class EstadoSolicitudDTO
    {
        //Para confirmar o cancelarla
        public string Estado { get; set; } = string.Empty;
    }
}

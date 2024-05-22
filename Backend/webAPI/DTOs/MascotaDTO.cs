namespace webAPI.DTOs
{
    public class MascotaDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public int Edad { get; set; }

        public string Especie { get; set; } = string.Empty;

        public string Raza { get; set; } = string.Empty;

        public string NombreUsuario { get; set; } = string.Empty;

        public string Descripcion { get; set; } = string.Empty;

        public string Estado { get; set; } = string.Empty;
    }
}

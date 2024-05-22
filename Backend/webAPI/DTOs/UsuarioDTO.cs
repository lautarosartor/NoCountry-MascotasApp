namespace webAPI.DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Apellido { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Descripcion { get; set; } = string.Empty;

        public string Rol { get; set; } = string.Empty;

        public string Provincia { get; set; } = string.Empty;

        public string Localidad { get; set; } = string.Empty;
    }
}

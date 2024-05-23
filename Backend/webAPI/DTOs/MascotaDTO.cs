namespace webAPI.DTOs
{
    //Para mostrar cierta info en los GET
    public class GetMascotaDTO
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

    //Para el POST y el PUT
    public class MascotaDTO
    {
        public string Nombre { get; set; } = string.Empty;

        public int Edad { get; set; }

        public string Especie { get; set; } = string.Empty;

        public string Raza { get; set; } = string.Empty;

        public int IdUsuario { get; set; }  //Este no funcionara en el PUT

        public string Descripcion { get; set; } = string.Empty;
    }
}

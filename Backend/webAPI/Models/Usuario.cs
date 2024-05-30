using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webAPI.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(50)]
        public string Apellido { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;


        [Required]
        public byte[] PasswordHash { get; set; } = null!;

        [Required]
        public byte[] PasswordSalt { get; set; } = null!;


        [StringLength(100)]
        public string Direccion { get; set; } = string.Empty;

        [StringLength(255)]
        public string Descripcion { get; set; } = string.Empty;


        [Required]
        [ForeignKey("Rol")]
        public int IdRol { get; set; }
        public virtual Rol Rol { get; set; } = null!;


        [Required]
        [ForeignKey("Provincia")]
        public int IdProvincia { get; set; }
        public virtual Provincia Provincia { get; set; } = null!;


        [Required]
        [ForeignKey("Localidad")]
        public int IdLocalidad { get; set; }
        public virtual Localidad Localidad { get; set; } = null!;

        //Por defecto la propiedad de borrado logico es falsa
        public bool Borrado { get; set; } = false;
    }
}

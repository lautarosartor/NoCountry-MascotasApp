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

        [StringLength(255)]
        public string Descripcion { get; set; } = string.Empty;

        [Required]
        [ForeignKey("Id")]
        public Provincia Provincia { get; set; } = null!;

        [Required]
        [ForeignKey("Id")]
        public Localidad Localidad { get; set; } = null!;

        //Por defecto la propiedad de borrado logico es falsa
        public bool Borrado { get; set; } = false;

        /*
        [Required]
        public byte[] PasswordHash { get; set; } = null!;

        [Required]
        public byte[] PasswordSalt { get; set; } = null!;
        */
    }
}

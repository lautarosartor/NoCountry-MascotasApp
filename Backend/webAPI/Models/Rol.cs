using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webAPI.Models
{
    [Table("Rol")]
    public class Rol
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(7)]
        public string Nombre { get; set; } = string.Empty;  //admin, cliente, refugio
    }
}

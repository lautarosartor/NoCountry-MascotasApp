using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webAPI.Models
{
    [Table("Adopcion")]
    public class Adopcion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }
        public virtual Usuario Usuario { get; set; } = null!;

        [Required]
        [ForeignKey("Mascota")]
        public int IdMascota { get; set; }
        public virtual Mascota Mascota { get; set; } = null!;

        [Required]
        [StringLength(20)]
        public string Estado { get; set; } = "Solicitado";
    }
}

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
        [ForeignKey("Id")]
        public Usuario Usuario { get; set; } = null!;

        [Required]
        [ForeignKey("Id")]
        public Mascota Mascota { get; set; } = null!;

        [Required]
        [StringLength(20)]
        public string Estado { get; set; } = string.Empty;
    }
}

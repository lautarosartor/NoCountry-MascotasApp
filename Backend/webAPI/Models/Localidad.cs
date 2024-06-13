using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webAPI.Models
{
    [Table("Localidad")]
    public class Localidad
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [ForeignKey("Provincia")]
        public int IdProvincia { get; set; }

        public virtual Provincia Provincia { get; set; } = null!;
    }
}

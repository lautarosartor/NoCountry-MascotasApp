using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webAPI.Models
{
    [Table("Solicitud")]
    public class Solicitud
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
        public System.DateTime Fecha { get; set; } = DateTime.Now;  //Automaticamente la fecha y hora del momento

        [Required]
        [StringLength(20)]
        public string Estado { get; set; } = "Pendiente";   //Automaticamente cuando solicitamos, el estado sera pendiente
    }
}

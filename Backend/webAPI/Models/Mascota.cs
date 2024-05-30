using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webAPI.Models
{
    [Table("Mascota")]
    public class Mascota
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [Range(0, 11)]
        public int Meses { get; set; }

        [Required]
        [Range(0, 20)]
        public int Años { get; set; }

        [Required]
        [StringLength(50)]
        public string Especie { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Raza { get; set; } = string.Empty;

        [StringLength(500)]
        public string UrlImagen { get; set; } = string.Empty;

        [Required]
        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }  //solo usuario con rol refugio
        public virtual Usuario Usuario { get; set; } = null!;

        [StringLength(255)]
        public string Descripcion { get; set; } = string.Empty;

        //Por defecto ni bien se crea la publicacion el estado de la mascota es disponible
        [StringLength(20)]
        public string Estado { get; set; } = "Disponible";

        //Por defecto la propiedad de borrado logico es falsa
        public bool Borrado { get; set; } = false;
    }
}

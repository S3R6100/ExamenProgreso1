using System.ComponentModel.DataAnnotations;

namespace SergioMasin.Models
{
    public class Mascota
    {
        [Key]
        [Required]
        [Display(Name = "ID")]
        [Range(1, 999)]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(20)]
        public string Especie { get; set; }

        [Required]
        [StringLength(20)]
        public string Raza { get; set; }

        [Required]
        [Range(0, 50)]
        public int Edad { get; set; }

        [Required]
        [StringLength(15)]
        [Display(Name = "Tamaño")]
        public string Tamano { get; set; }
    }
}


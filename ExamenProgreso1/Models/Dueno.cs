using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace SergioMasin.Models
{
    public class Dueno
    {
        [Key]
        [Required]
        [Display(Name = "ID")]
        [Range(1, 999)]
        [DataType(DataType.Text)]

        public int Id { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        [StringLength(20)]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Cuenta Con Seguro?")]
        [DataType(DataType.Text)]
        public bool Seguro { get; set; }
        [Display(Name = "Fecha de Visita")]
        [DataType(DataType.Date)]
        public DateOnly FechaVisita { get; set; }
        [Display(Name = "Numero de Telefono")]
        public required string Telefono { get; set; }

    }

}
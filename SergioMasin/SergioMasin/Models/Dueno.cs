using System;
using System.ComponentModel.DataAnnotations;

namespace SergioMasin.Models
{
    public class Dueno
    {
        [Key]
        [Required]
        [Display(Name = "ID")]
        [Range(1, 999)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        [StringLength(20)]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Cuenta Con Seguro?")]
        public bool Seguro { get; set; }

        [Display(Name = "Fecha de Registro")]
        [DataType(DataType.Date)]
        public DateTime FechaVisita { get; set; }

        [Display(Name = "Número de Teléfono")]
        [DataType(DataType.PhoneNumber)]
        public string Telefono { get; set; }

        [Display(Name = "Saldo Deuda")]
        [Range(0, 10000)]
        public decimal Saldo { get; set; }
    }
}

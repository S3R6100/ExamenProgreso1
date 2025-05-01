using System;
using System.ComponentModel.DataAnnotations;

namespace SergioMasin.Models
{
    public class Visita
    {
        [Key]
        [Required]
        [Display(Name = "ID")]
        [Range(1, 999)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Fecha de Visita")]
        [DataType(DataType.Date)]
        public DateTime FechaVisita { get; set; }

        [Required]
        [Display(Name = "Tarifa")]
        [Range(0, 200)]
        public decimal Tarifa { get; set; }

        [Display(Name = "Motivo")]
        public string Motivo
        {
            get
            {
                return Tarifa switch
                {
                    30 => "Vacunación",
                    20 => "Revisión General",
                    100 => "Cirugía",
                    _ => "Otro"
                };
            }
        }

        [Required]
        [Display(Name = "Requiere Medicación")]
        public bool RequiereMedicacion { get; set; }
    }
}



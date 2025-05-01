using System.ComponentModel.DataAnnotations;

namespace SergioMasin.Models
{
    public class Visita
    {
        [Key]
        [Required]
        [Display(Name = "ID")]
        [Range(1, 999)]
        [DataType(DataType.Text)]
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaVisita { get; set; }
        [DataType(DataType.Text)]
        public int tarifa { get; set; }
        [DataType(DataType.Text)]
        public string Motivo
        {
            get
            {
                if (Motivo == "Vacunacion")
                {   
                    tarifa = 30;
                    return "Vacunacion";
                }
                else if (Motivo == "Revision")
                {
                    tarifa = 20;
                    return "Revision";
                }
                else if (Motivo == "Cirugia")
                {
                    tarifa = 50;
                    return "Cirugia";
                }
                else
                {
                    tarifa = 0;
                    return Motivo;
                }
            }
            set
            {
                Motivo = value;
            }
        }

        [DataType(DataType.Text)]
        public bool Emergencia { get; set; }

    }

}

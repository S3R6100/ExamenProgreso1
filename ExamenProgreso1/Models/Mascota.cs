using System.ComponentModel.DataAnnotations;

namespace SergioMasin.Models
{
    public class Mascota
    {
        [Key]
        [Required]
        [Display(Name = "ID")]
        [Range(1, 999)]
        [DataType(DataType.Text)]
        public int Id { get; set; }
        [DataType(DataType.Text)]
        public string Nombre { get; set; }
        [DataType(DataType.Text)]
        public string Especie { get; set; }
        [DataType(DataType.Text)]
        public string Raza { get; set; }
        [DataType(DataType.Text)]
        public int Edad { get; set; }
        [DataType(DataType.Text)]
        public string Tamano { get; set; }

    }
}

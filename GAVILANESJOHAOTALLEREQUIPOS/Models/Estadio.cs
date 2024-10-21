using System.ComponentModel.DataAnnotations;

namespace GAVILANESJOHAOTALLEREQUIPOS.Models
{
    public class Estadio
    {
        [Key]

        [Required]
        public int IdEstadio { get; set; }
        [MaxLength(50)]
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public int Capacidad { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }
    }
}

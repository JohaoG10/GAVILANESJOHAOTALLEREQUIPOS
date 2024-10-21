using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GAVILANESJOHAOTALLEREQUIPOS.Models
{
    public class Equipoligapro
    {
        [Key]

        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string Nombre { get; set; }

        [Required]
        public string Ciudad { get; set; }
        public int titulos { get; set; }
        
        public bool AceptaExtranjeros { get; set; }

        public Estadio? Estadio { get; set; }

        [ForeignKey("Estadio")]
        public int IdEstadio { get; set; }
       
    }
}

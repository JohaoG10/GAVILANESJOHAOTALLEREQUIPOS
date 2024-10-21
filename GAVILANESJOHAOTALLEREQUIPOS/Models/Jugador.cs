using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GAVILANESJOHAOTALLEREQUIPOS.Models
{
    public class Jugador
    {
        [Key]
       
        public int IdJugador { get; set; }
        [Required]
        [MaxLength(70)]
        public string Nombre { get; set; }
        [Required]
        [MaxLength(40)]
        public string Posicion { get; set; }

        public int Edad { get; set; }

        public Equipoligapro? Equipo { get; set; }
        [ForeignKey("Equipo")]
        public int IdEquipo { get; set; }
    }
}

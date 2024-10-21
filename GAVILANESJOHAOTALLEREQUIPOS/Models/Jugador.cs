using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GAVILANESJOHAOTALLEREQUIPOS.Models
{
    public class Jugador
    {
        [Key]
        [Required]
        public int IdJugador { get; set; }
        public string Nombre { get; set; }
        public string Posicion { get; set; }

        public int Edad { get; set; }

        public Equipoligapro? Equipo { get; set; }
        [ForeignKey("Equipo")]
        public int IdEquipo { get; set; }
    }
}

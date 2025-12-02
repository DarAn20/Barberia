using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Barberia.Models
{
    public class Cita
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime FechaHora { get; set; }

        // ---------------- Client --------------------
        public int ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public cliente cliente { get; set; }

        // ---------------- Servicio --------------------
        public int ServicioId { get; set; }

        [ForeignKey("ServicioId")]
        public Servicio Servicio { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Barberia.Models
{
    public class Cita
    {
        [Key]
        public int CitaId { get; set; }

        [Required]
        public DateTime FechaHora { get; set; }

        // ---------------- Client --------------------
        [Display(Name = "Nombre Cliente")]
        public int ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public cliente cliente { get; set; }

        // ---------------- Servicio --------------------
        [Display(Name = "Nombre del Servicio")]
        public int ServicioId { get; set; }

        [ForeignKey("ServicioId")]
        public Servicio Servicio { get; set; }
    }
}

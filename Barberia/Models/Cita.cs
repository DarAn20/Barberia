using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Barberia.Models
{
    public class Cita
    {
        [Key]
        public int Id { get; set; }

        public DateTime FechaHora { get; set; }

        // FK hacia Cliente
        public int ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public cliente cliente { get; set; }

        // Si más adelante querés agregar Servicio:
        // public int ServicioId { get; set; }
        // public Servicio Servicio { get; set; }
    }
}

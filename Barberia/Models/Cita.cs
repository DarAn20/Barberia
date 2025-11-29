using System.ComponentModel.DataAnnotations;

namespace Barberia.Models
{
    public class Cita
    {
        [Key]
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public int ClienteId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Barberia.Models
{
    public class Cita
    {
        [Key]
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public int ClienteId { get; set; }

        //Clave foranea uno a muchos
        //[ForeignKey("ServicioId")]
       // public int ServicioId { get; set; } 
       // public Servicio Servicio { get; set; }
    }
}

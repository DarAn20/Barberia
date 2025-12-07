using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Barberia.Models
{
    public class Cita
    {
        [Key]
        public int CitaId { get; set; }

        [Required]
        [Display(Name = "Fecha y Hora")]
        public DateTime FechaHora { get; set; }

        // ---------------- Client --------------------
        [Display(Name = "Nombre Cliente")]
        [ForeignKey("ClienteId")]
        public cliente cliente { get; set; }

        // ---------------- Servicio --------------------
        [Display(Name = "Nombre del Servicio")]
        public int ServicioId { get; set; }

        [ForeignKey("ServicioId")]
        public Servicio Servicio { get; set; }
        public int ClienteId { get; set; }
    }
}

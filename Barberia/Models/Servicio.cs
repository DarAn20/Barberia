using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Barberia.Models
{
    public class Servicio
    {
        [Key]
        public int ServicioId { get; set; }

        [Required]
        [Display(Name = "Nombre del Servicio")]
        public string NombreServicio { get; set; }


        [Required]
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Precio { get; set; }

        //Ppropiedades de navegacion
        //public ICollection<Cita> Citas { get; set; }= new List<Cita>();

    }
}

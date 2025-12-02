using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Barberia.Models
{
    public class Servicio
    {
        [Key]
        public int ServicioId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Precio { get; set; }

        //Ppropiedades de navegacion
        //public ICollection<Cita> Citas { get; set; }= new List<Cita>();

    }
}

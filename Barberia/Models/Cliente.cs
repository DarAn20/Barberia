using System.ComponentModel.DataAnnotations;

namespace Barberia.Models
{
    public class cliente
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
    }
}

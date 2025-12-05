using System.ComponentModel.DataAnnotations;

namespace Barberia.Models
{
    public class cliente
    {
        [Key]
        public int ClienteId { get; set; }
        
        [Required]
        [Display(Name = "Nombre")]
        public string NombreCliente { get; set; }
        public string Apellido { get; set; }
        [Required]
        public string Telefono { get; set; }
        public string Email { get; set; }

    }
}

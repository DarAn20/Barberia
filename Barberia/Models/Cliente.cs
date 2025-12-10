using Microsoft.AspNetCore.Authorization;
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

        [Required(ErrorMessage = "El correo es obligatorio")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@(gmail\.com|hotmail\.com)$")]
        public string Email { get; set; }

    }
}

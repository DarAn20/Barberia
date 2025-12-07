using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Barberia.Models
{
    public class Usuario:IdentityUser
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Cedula { get; set; }
        [Required]
        public DateOnly? FechaNacimiento{ get; set; }
      
    }
}

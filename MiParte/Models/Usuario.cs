using System.ComponentModel.DataAnnotations;

namespace MiParte.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Pwd { get; set; }

        public bool IsAdmin { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace BibliotecaCarlosMeridaAPI.Models
{
    public class Usuario
    {
        [Key] public int IdUsuario { get; set; }
        [Required] public string Username { get; set; }
        [Required] public string Pwd { get; set; }
        [Required] public bool IsAdmin { get; set; }
    }
}

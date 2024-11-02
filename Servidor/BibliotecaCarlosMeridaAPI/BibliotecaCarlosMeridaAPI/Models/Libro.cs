using System.ComponentModel.DataAnnotations;

namespace BibliotecaCarlosMeridaAPI.Models
{
    public class Libro
    {
        public int Id { get; set; }
        [Required] public string Titulo { get; set; }
        [Required] public string Autor { get; set; }
        [Required] public string ISBN { get; set; }
        public bool DisponiblePrestamo { get; set; }
        public byte[] Portada { get; set; }
    }
}

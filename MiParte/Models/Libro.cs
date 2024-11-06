using System.ComponentModel.DataAnnotations;
namespace BlazorWebAppMovies.Models
{
    public class Libro
    {
        [Key] public int IdLibro { get; set; }
        [Required] public string Titulo { get; set; }
        [Required] public string Autor { get; set; }
        [Required] public string ISBN { get; set; }
        [Required] public string Genero { get; set; }
        [Required] public int VecesPrestado { get; set; }


        public bool DisponiblePrestamo { get; set; }
        public byte[] Portada { get; set; }

        public string PrestadoA { get; set; }
        public DateTime? FechaPrestamo { get; set; }
    }
}

using BlazorWebAppMovies.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorWebAppMovies.Services
{
    public interface ILibroService
    {
        Task<IEnumerable<Libro>> GetLibrosAsync();
        Task<Libro> GetLibroByIdAsync(int id);
        Task AddLibroAsync(Libro libro);
        Task UpdateLibroAsync(Libro libro);
        Task DeleteLibroAsync(int id);
    }
}

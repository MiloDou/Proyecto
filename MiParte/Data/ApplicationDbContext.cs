using Microsoft.EntityFrameworkCore;
using BlazorWebAppMovies.Models;
using MiParte.Models;

namespace BlazorWebAppMovies.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Libro> Libros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}

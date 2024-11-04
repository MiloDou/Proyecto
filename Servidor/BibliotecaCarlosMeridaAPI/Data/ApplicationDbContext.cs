using Microsoft.EntityFrameworkCore;
using BibliotecaCarlosMeridaAPI.Models;

namespace BibliotecaCarlosMeridaAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Libro> Libros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Libro>().HasKey(l => l.IdLibro);
        }
    }
}

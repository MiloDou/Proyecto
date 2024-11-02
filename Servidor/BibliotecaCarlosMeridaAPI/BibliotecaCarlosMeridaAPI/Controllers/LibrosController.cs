using Microsoft.AspNetCore.Mvc;
using BibliotecaCarlosMeridaAPI.Data;
using BibliotecaCarlosMeridaAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class LibrosController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public LibrosController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Libro>>> GetLibros()
    {
        return await _context.Libros.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Libro>> PostLibro(Libro libro)
    {
        _context.Libros.Add(libro);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetLibros), new { id = libro.Id }, libro);
    }
}

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
        try
        {
            return await _context.Libros.ToListAsync();
        }
        catch (Exception ex)
        {
            // Registra el error en los logs del servidor
            Console.WriteLine($"Error al obtener los libros: {ex.Message}");
            return StatusCode(500, "Error interno del servidor");
        }
    }
    [HttpGet("populares")]
    public async Task<ActionResult<IEnumerable<Libro>>> GetLibrosPopulares(int cantidad)
    {
        try
        {
            var librosPopulares = await _context.Libros
                .OrderByDescending(l => l.VecesPrestado)
                .Take(cantidad)
                .ToListAsync();
            return Ok(librosPopulares);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al obtener libros populares: {ex.Message}");
            return StatusCode(500, "Error interno del servidor");
        }
    }



    [HttpPost]
    public async Task<ActionResult<Libro>> PostLibro(Libro libro)
    {
        try
        {
            _context.Libros.Add(libro);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetLibros), new { id = libro.IdLibro }, libro);
        }
        catch (Exception ex)
        {
            // Registra el error en los logs del servidor
            Console.WriteLine($"Error al agregar el libro: {ex.Message}");
            return StatusCode(500, "Error interno del servidor");
        }
    }

    [HttpGet("buscar")]
    public async Task<ActionResult<IEnumerable<Libro>>> BuscarLibros(string query)
    {
        if (string.IsNullOrEmpty(query))
        {
            return await GetLibros();
        }

        var libros = await _context.Libros
            .Where(l => l.Titulo.Contains(query) || l.Autor.Contains(query) || l.ISBN.Contains(query))
            .ToListAsync();

        return Ok(libros);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> ActualizarLibro(int id, Libro libro)
    {
        if (id != libro.IdLibro)
        {
            return BadRequest("El ID del libro no coincide.");
        }

        var libroExistente = await _context.Libros.FindAsync(id);
        if (libroExistente == null)
        {
            return NotFound("Libro no encontrado.");
        }

        // Actualizar el estado de DisponiblePrestamo
        libroExistente.DisponiblePrestamo = libro.DisponiblePrestamo;
        libroExistente.VecesPrestado = libro.VecesPrestado;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            Console.WriteLine($"Error al actualizar el libro: {ex.Message}");
            return StatusCode(500, "Error interno del servidor");
        }

        return NoContent();
    }


}


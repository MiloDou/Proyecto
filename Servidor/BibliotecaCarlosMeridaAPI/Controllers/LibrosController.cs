﻿using Microsoft.AspNetCore.Mvc;
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
}


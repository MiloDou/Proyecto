using Microsoft.AspNetCore.Mvc;
using BibliotecaCarlosMeridaAPI.Data;
using BibliotecaCarlosMeridaAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class UsuariosController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public UsuariosController(ApplicationDbContext context)
    {
        _context = context;
    }
    [HttpGet] public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios() { return await _context.Usuarios.ToListAsync(); }


    [HttpPost("login")]
    public async Task<ActionResult<Usuario>> Login([FromBody] Usuario usuario)
    {
        var user = await _context.Usuarios
            .Where(u => u.Username == usuario.Username && u.Pwd == usuario.Pwd)
            .FirstOrDefaultAsync();

        if (user == null)
        {
            return Unauthorized("Invalid username or password");
        }

        return Ok(user);
    }

    [HttpPost] 
    public async Task<ActionResult<Usuario>> CrearUsuario(Usuario usuario) 
    { 
        _context.Usuarios.Add(usuario); 
        await _context.SaveChangesAsync(); 
        return CreatedAtAction(nameof(CrearUsuario), new { id = usuario.IdUsuario }, usuario);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> EliminarUsuario(int id)
    {
        var usuario = await _context.Usuarios.FindAsync(id);
        if (usuario == null)
        {
            return NotFound();
        }

        _context.Usuarios.Remove(usuario);
        await _context.SaveChangesAsync();

        return NoContent();
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUsuario(int id, [FromBody] Usuario usuario)
    {
        // Verifica si el ID en la URL coincide con el ID en el objeto usuario
        if (id != usuario.IdUsuario)
        {
            return BadRequest("El ID de la URL no coincide con el ID del usuario.");
        }

        // Marca el estado del usuario como modificado en el contexto
        _context.Entry(usuario).State = EntityState.Modified;

        try
        {
            // Guarda los cambios en la base de datos
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            // Verifica si el usuario aún existe en la base de datos
            if (!UsuarioExists(id))
            {
                return NotFound("El usuario no existe.");
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // Método auxiliar para verificar si un usuario existe en la base de datos
    private bool UsuarioExists(int id)
    {
        return _context.Usuarios.Any(e => e.IdUsuario == id);
    }

}

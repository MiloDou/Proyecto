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
}

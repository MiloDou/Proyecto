using MiParte.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class UsuarioService
{
    private readonly HttpClient _httpClient;

    public UsuarioService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task CrearUsuarioAsync(Usuario usuario)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Usuarios", usuario); 
        response.EnsureSuccessStatusCode();
    }

    public async Task<IEnumerable<Usuario>> ObtenerUsuariosAsync()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<Usuario>>("api/Usuarios");
    }

    public async Task<Usuario> LoginAsync(Usuario usuario)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Usuarios/login", usuario);

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException("Invalid username or password");
        }

        return await response.Content.ReadFromJsonAsync<Usuario>();
    }
    public async Task EliminarUsuarioAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/Usuarios/{id}");
        response.EnsureSuccessStatusCode();
    }
    public async Task ActualizarUsuarioAsync(Usuario usuario)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/usuarios/{usuario.IdUsuario}", usuario);
        response.EnsureSuccessStatusCode();
    }

}
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

    public async Task<Usuario> LoginAsync(Usuario usuario)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Usuarios/login", usuario);

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException("Invalid username or password");
        }

        return await response.Content.ReadFromJsonAsync<Usuario>();
    }
}

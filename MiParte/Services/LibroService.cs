using BlazorWebAppMovies.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class LibroService
{
    private readonly HttpClient _httpClient;

    public LibroService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Libro>> GetLibrosAsync()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<Libro>>("api/Libros");
    }

    public async Task AddLibroAsync(Libro libro)
    {
        await _httpClient.PostAsJsonAsync("api/Libros", libro);
    }
}

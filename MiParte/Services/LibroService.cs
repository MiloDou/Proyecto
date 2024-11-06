using BlazorWebAppMovies.Models;
using BlazorWebAppMovies.Services;
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
        try
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Libro>>("api/Libros");
        }
        catch (HttpRequestException ex)
        {
            // Manejar error HTTP
            Console.WriteLine($"Error al obtener libros: {ex.Message}");
            return Enumerable.Empty<Libro>();
        }
        catch (Exception ex)
        {
            // Manejar cualquier otro error
            Console.WriteLine($"Error inesperado: {ex.Message}");
            return Enumerable.Empty<Libro>();
        }
    }

    public async Task AddLibroAsync(Libro libro)
    {
        try
        {
            await _httpClient.PostAsJsonAsync("api/Libros", libro);
        }
        catch (HttpRequestException ex)
        {
            // Manejar error HTTP
            Console.WriteLine($"Error al agregar libro: {ex.Message}");
        }
        catch (Exception ex)
        {
            // Manejar cualquier otro error
            Console.WriteLine($"Error inesperado: {ex.Message}");
        }
    }
    public async Task<IEnumerable<Libro>> BuscarLibrosAsync(string query)
    {
        try
        {
            // Llama a la API con el término de búsqueda en la URL
            return await _httpClient.GetFromJsonAsync<IEnumerable<Libro>>($"api/Libros/buscar?query={query}");
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Error al buscar libros: {ex.Message}");
            return Enumerable.Empty<Libro>();
        }
    }
   


}


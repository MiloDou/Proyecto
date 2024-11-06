using BlazorWebAppMovies.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
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
            Console.WriteLine($"Error al obtener libros: {ex.Message}");
            return Enumerable.Empty<Libro>();
        }
        catch (Exception ex)
        {
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
            Console.WriteLine($"Error al agregar libro: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error inesperado: {ex.Message}");
        }
    }

    public async Task<IEnumerable<Libro>> BuscarLibrosAsync(string query)
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Libro>>($"api/Libros/buscar?query={query}");
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Error al buscar libros: {ex.Message}");
            return Enumerable.Empty<Libro>();
        }
    }

    // Método para obtener los libros más populares (llamando a la API)
    public async Task<List<Libro>> GetLibrosPopulares(int cantidad)
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<List<Libro>>($"api/Libros/populares?cantidad={cantidad}");
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Error al obtener libros populares: {ex.Message}");
            return new List<Libro>();
        }
    }

}

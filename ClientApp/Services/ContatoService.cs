using System.Collections.ObjectModel;
using System.Net;
using System.Text.Json;

namespace ClientApp.Services;
using System.Net.Http.Json;
using SharedModels;

public class ContatoService
{
    private readonly HttpClient _httpClient;

    public ContatoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    
    public async Task<List<ContatoDto>?> GetContatosByClienteAsync(int clienteId)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/clientes/{clienteId}/contatos");
            
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.Content.ReadFromJsonAsync<List<ContatoDto>>();
            }
            response.EnsureSuccessStatusCode();
            return new List<ContatoDto>();
        }
        catch (HttpRequestException ex)
        {
            throw new ApplicationException($"Request error: {ex.Message}", ex);
        }
        catch (JsonException ex)
        {
            throw new ApplicationException($"JSON parsing error: {ex.Message}", ex);
        }
        catch (Exception ex)
        {
            throw new ApplicationException($"Unexpected error: {ex.Message}", ex);
        }
    }

    public async Task<ContatoDto?> GetContatoAsync(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/contatos/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ContatoDto>();
        }
        catch (HttpRequestException ex)
        {
            throw new ApplicationException($"Request error: {ex.Message}", ex);
        }
        catch (Exception ex)
        {
            throw new ApplicationException($"Unexpected error: {ex.Message}", ex);
        }
    }

    public async Task<ContatoDto?> AddContatoAsync(ContatoDto contatoDto)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync($"api/clientes/{contatoDto.IdCliente}/contatos", contatoDto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ContatoDto>();
        }
        catch (HttpRequestException ex)
        {
            throw new ApplicationException($"Request error: {ex.Message}", ex);
        }
        catch (Exception ex)
        {
            throw new ApplicationException($"Unexpected error: {ex.Message}", ex);
        }
    }

    public async Task UpdateContatoAsync(ContatoDto contatoDto)
    {
        try
        {
            var response = await _httpClient.PutAsJsonAsync($"api/contatos/{contatoDto.Id}", contatoDto);
            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException ex)
        {
            throw new ApplicationException($"Request error: {ex.Message}", ex);
        }
        catch (Exception ex)
        {
            throw new ApplicationException($"Unexpected error: {ex.Message}", ex);
        }
    }

    public async Task DeleteContatoAsync(int id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"api/contatos/{id}");
            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException ex)
        {
            throw new ApplicationException($"Request error: {ex.Message}", ex);
        }
        catch (Exception ex)
        {
            throw new ApplicationException($"Unexpected error: {ex.Message}", ex);
        }
    }
}
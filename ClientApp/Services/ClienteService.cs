using Microsoft.JSInterop;

namespace ClientApp.Services;
using System.Net.Http.Json;
using SharedModels;
public class ClienteService
{
    private readonly HttpClient _httpClient;

    public ClienteService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ClienteDto>?> GetClientesAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("api/clientes");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<ClienteDto>>();
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

    public async Task<ClienteDto?> GetClienteAsync(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/clientes/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ClienteDto>();
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

    public async Task<ClienteDto?> AddClienteAsync(ClienteDto clienteDto)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("api/clientes", clienteDto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ClienteDto>();
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

    public async Task UpdateClienteAsync(ClienteDto clienteDto)
    {
        try
        {
            var response = await _httpClient.PutAsJsonAsync($"api/clientes/{clienteDto.Id}", clienteDto);
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

    public async Task DeleteClienteAsync(int id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"api/clientes/{id}");
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
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

    public async Task<IEnumerable<ClienteDto>?> GetClientesAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("api/clientes");
            response.EnsureSuccessStatusCode();
        
            // Leitura e desserialização da resposta JSON diretamente em ClienteDto
            return await response.Content.ReadFromJsonAsync<IEnumerable<ClienteDto>>();
        }
        catch (HttpRequestException ex)
        {
            // Log e tratamento de erros
            Console.WriteLine($"Request error: {ex.Message}");
            throw new ApplicationException("Server error: " + ex.Message);
        }
        catch (Exception ex)
        {
            // Log e tratamento de exceções inesperadas
            Console.WriteLine($"Unexpected error: {ex.Message}");
            throw;
        }
    }


    public async Task<ClienteDto?> GetClienteAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<ClienteDto>($"api/clientes/{id}");
    }

    public async Task<ClienteDto?> AddClienteAsync(ClienteDto clienteDto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/clientes", clienteDto);
        return await response.Content.ReadFromJsonAsync<ClienteDto>();
    }

    public async Task UpdateClienteAsync(ClienteDto clienteDto)
    {
        await _httpClient.PutAsJsonAsync($"api/clientes/{clienteDto.Id}", clienteDto);
    }

    public async Task DeleteClienteAsync(int id)
    {
        await _httpClient.DeleteAsync($"api/clientes/{id}");
    }
}
namespace Server.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using SharedModels;
public interface IClienteService
{
    Task<IEnumerable<ClienteDto>> GetAllClientesAsync();
    Task<ClienteDto> GetClienteByIdAsync(int id);
    Task AddClienteAsync(ClienteDto clienteDto);
    Task UpdateClienteAsync(ClienteDto clienteDto);
    Task DeleteClienteAsync(int id);
}
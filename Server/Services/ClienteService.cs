using AutoMapper;
using Server.Repositories;
using SharedModels;

namespace Server.Services;

public class ClienteService : IClienteService
{
    private readonly IClienteRepository _clienteRepository;
    private readonly IMapper _mapper;

    public ClienteService(IClienteRepository clienteRepository, IMapper mapper)
    {
        _clienteRepository = clienteRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ClienteDto>> GetAllClientesAsync()
    {
        var clientes = await _clienteRepository.GetAllClientesAsync();
        return _mapper.Map<IEnumerable<ClienteDto>>(clientes);
    }

    Task<ClienteDto> IClienteService.GetClienteByIdAsync(int id)
    {
        return GetClienteByIdAsync(id);
    }

    Task IClienteService.AddClienteAsync(ClienteDto clienteDto)
    {
        return AddClienteAsync(clienteDto);
    }

    Task IClienteService.UpdateClienteAsync(ClienteDto clienteDto)
    {
        return UpdateClienteAsync(clienteDto);
    }

    Task<IEnumerable<ClienteDto>> IClienteService.GetAllClientesAsync()
    {
        return GetAllClientesAsync();
    }

    public async Task<ClienteDto> GetClienteByIdAsync(int id)
    {
        var cliente = await _clienteRepository.GetClienteByIdAsync(id);
        return _mapper.Map<ClienteDto>(cliente);
    }

    public async Task AddClienteAsync(ClienteDto clienteDto)
    {
        var cliente = _mapper.Map<Cliente>(clienteDto);
        cliente.Cnpj = cliente.Cnpj = new string(cliente.Cnpj.Where(char.IsDigit).ToArray());;
        await _clienteRepository.AddClienteAsync(cliente);
    }

    public async Task UpdateClienteAsync(ClienteDto clienteDto)
    {
        var cliente = _mapper.Map<Cliente>(clienteDto);
        await _clienteRepository.UpdateClienteAsync(cliente);
    }

    public async Task DeleteClienteAsync(int id)
    {
        await _clienteRepository.DeleteClienteAsync(id);
    }
}
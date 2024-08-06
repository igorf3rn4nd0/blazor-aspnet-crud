using AutoMapper;
using Server.Repositories;
using SharedModels;

namespace Server.Services;

public class ContatoService : IContatoService
{
    private readonly IContatoRepository _contatoRepository;
    private readonly IMapper _mapper;

    public ContatoService(IContatoRepository contatoRepository, IMapper mapper)
    {
        _contatoRepository = contatoRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ContatoDto>> GetContatosByClienteIdAsync(int idCliente)
    {
        var contatos = await _contatoRepository.GetContatosByClienteIdAsync(idCliente);
        return _mapper.Map<IEnumerable<ContatoDto>>(contatos);
    }

    Task<ContatoDto> IContatoService.GetContatoByIdAsync(int id)
    {
        return GetContatoByIdAsync(id);
    }

    Task IContatoService.AddContatoAsync(ContatoDto contatoDto)
    {
        return AddContatoAsync(contatoDto);
    }

    Task IContatoService.UpdateContatoAsync(ContatoDto contatoDto)
    {
        return UpdateContatoAsync(contatoDto);
    }

    Task<IEnumerable<ContatoDto>> IContatoService.GetContatosByClienteIdAsync(int idCliente)
    {
        return GetContatosByClienteIdAsync(idCliente);
    }

    public async Task<ContatoDto> GetContatoByIdAsync(int id)
    {
        var contato = await _contatoRepository.GetContatoByIdAsync(id);
        return _mapper.Map<ContatoDto>(contato);
    }

    public async Task AddContatoAsync(ContatoDto contatoDto)
    {
        var contato = _mapper.Map<Contato>(contatoDto);
        await _contatoRepository.AddContatoAsync(contato);
    }

    public async Task UpdateContatoAsync(ContatoDto contatoDto)
    {
        var contato = _mapper.Map<Contato>(contatoDto);
        await _contatoRepository.UpdateContatoAsync(contato);
    }

    public async Task DeleteContatoAsync(int id)
    {
        await _contatoRepository.DeleteContatoAsync(id);
    }
}
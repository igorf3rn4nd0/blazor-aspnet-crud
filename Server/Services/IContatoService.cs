namespace Server.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using SharedModels;
public interface IContatoService
{
    Task<IEnumerable<ContatoDto>> GetAllContatosAsync();
    Task<ContatoDto> GetContatoByIdAsync(int id);
    Task AddContatoAsync(ContatoDto contatoDto);
    Task UpdateContatoAsync(ContatoDto contatoDto);
    Task DeleteContatoAsync(int id);
}
using Server.Data;
using Microsoft.EntityFrameworkCore;
using SharedModels;

namespace Server.Repositories
{
    public interface IContatoRepository
    {
        Task<IEnumerable<Contato>> GetContatosByClienteIdAsync(int idCliente);
        Task<Contato> GetContatoByIdAsync(int id);
        Task AddContatoAsync(Contato contato);
        Task UpdateContatoAsync(Contato contato);
        Task DeleteContatoAsync(int id);
    }

    public class ContatoRepository : IContatoRepository
    {
        private readonly ApplicationDbContext _context;

        public ContatoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Contato>> GetContatosByClienteIdAsync(int idCliente)
        {
            return await _context.Set<Contato>()
                .Where(c => c.IdCliente == idCliente)
                .ToListAsync();
        }

        public async Task<Contato> GetContatoByIdAsync(int id)
        {
            return await _context.Set<Contato>().FindAsync(id);
        }

        public async Task AddContatoAsync(Contato contato)
        {
            _context.Set<Contato>().Add(contato);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateContatoAsync(Contato contato)
        {
            _context.Entry(contato).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteContatoAsync(int id)
        {
            var contato = await _context.Set<Contato>().FindAsync(id);
            if (contato != null)
            {
                _context.Set<Contato>().Remove(contato);
                await _context.SaveChangesAsync();
            }
        }
    }
}
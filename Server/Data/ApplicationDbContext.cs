using Microsoft.EntityFrameworkCore;
using SharedModels;

namespace Server.Data;

public class ApplicationDbContext : DbContext {
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
    }
    
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Contato> Contatos { get; set; }
}
using EstacionamentoAPI.Data.Mappings;
using EstacionamentoAPI.Entities;
using Microsoft.EntityFrameworkCore;


namespace EstacionamentoAPI.Data;

public class EstacionamentoContext : DbContext
{
    public EstacionamentoContext(DbContextOptions<EstacionamentoContext> opts)
        : base(opts)
    {
            
    }

    public DbSet<Estacionamento> Estacionamentos { get; set; }
    public DbSet<Preco> Precos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EstacionamentoMapping());
        modelBuilder.ApplyConfiguration(new PrecoMapping());

    }
}

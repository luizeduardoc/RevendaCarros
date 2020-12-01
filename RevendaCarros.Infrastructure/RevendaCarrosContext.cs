using Microsoft.EntityFrameworkCore;
using RevendaCarros.Domain.Entities;

namespace RevendaCarros.Infrastructure
{
    public class RevendaCarrosContext : DbContext
    {
        public DbSet<Aluguel> Alugueis { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Imposto> Impostos{ get; set; }

        public RevendaCarrosContext(DbContextOptions<RevendaCarrosContext> options) :
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ImpostoMap());
            modelBuilder.ApplyConfiguration(new VeiculoMap());
            modelBuilder.ApplyConfiguration(new VendaMap());
            modelBuilder.ApplyConfiguration(new AluguelMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}

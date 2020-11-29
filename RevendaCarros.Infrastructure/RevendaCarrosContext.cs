using Microsoft.EntityFrameworkCore;
using RevendaCarros.Domain.Entities;

namespace RevendaCarros.Infrastructure
{
    public class RevendaCarrosContext : DbContext
    {
        //public DbSet<Alugueis> Alugueis { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Imposto> Impostos{ get; set; }

        public RevendaCarrosContext(DbContextOptions<RevendaCarrosContext> options) :
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ImpostosMap());
            modelBuilder.ApplyConfiguration(new VeiculoMap());
            modelBuilder.ApplyConfiguration(new VendaMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}

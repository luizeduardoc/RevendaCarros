using Microsoft.EntityFrameworkCore;
using RevendaCarros.Domain.Entities;

namespace RevendaCarros.Infrastructure
{
    public class RevendaCarrosContext : DbContext
    {
        //public DbSet<Alugueis> Alugueis { get; set; }
        //public DbSet<Vendas> Vendas { get; set; }
        public DbSet<Veiculos> Veiculos { get; set; }
        public DbSet<Impostos> Impostos{ get; set; }

        public RevendaCarrosContext(DbContextOptions<RevendaCarrosContext> options) :
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ImpostosMap());
            modelBuilder.ApplyConfiguration(new VeiculoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}

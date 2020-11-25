using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RevendaCarros.Domain.Entities;
using System;

namespace RevendaCarros.Infrastructure
{
    public sealed class VendaMap : IEntityTypeConfiguration<Vendas>
    {
        public void Configure(EntityTypeBuilder<Vendas> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.Property(t => t.Id).HasColumnName("id").IsRequired().HasColumnType("INT").ValueGeneratedOnAdd();
            builder.Property(t => t.IdVeiculo).HasColumnName("id_veiculo").HasColumnType("INT").IsRequired();
            builder.Property(t => t.Valor).HasColumnName("valor").HasColumnType("NUMERIC(9,2)").IsRequired();
            builder.Property(t => t.NomeComprador).HasColumnName("nome_comprador").HasColumnType("VARCHAR(150)").IsRequired();

            builder.HasKey(t => t.Id);            
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RevendaCarros.Domain.Entities;
using System;

namespace RevendaCarros.Infrastructure
{
    public sealed class VeiculoMap : IEntityTypeConfiguration<Veiculos>
    {
        public void Configure(EntityTypeBuilder<Veiculos> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.Property(t => t.Id).HasColumnName("id").IsRequired().HasColumnType("INT").ValueGeneratedOnAdd();
            builder.Property(t => t.Cor).HasColumnName("cor").HasColumnType("VARCHAR(20)");
            builder.Property(t => t.Placa).HasColumnName("placa").HasColumnType("CARCHAR(7)");
            builder.Property(t => t.Preco).HasColumnName("preco").HasColumnType("DECIMAL(9,2)");
            builder.Property(t => t.TipoVeiculo).HasColumnName("tipo").HasColumnType("NUMERIC(1)");

            builder.HasKey(t => t.Id);
        }
    }
}

﻿using Microsoft.EntityFrameworkCore;
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

            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("INT").ValueGeneratedOnAdd();
            builder.Property(t => t.Cor).HasColumnName("cor").HasColumnType("VARCHAR(20)").IsRequired();
            builder.Property(t => t.Placa).HasColumnName("placa").HasColumnType("CARCHAR(7)").IsRequired();
            builder.Property(t => t.Preco).HasColumnName("preco").HasColumnType("DECIMAL(9,2)").IsRequired();
            builder.Property(t => t.TipoVeiculo).HasColumnName("tipo").HasColumnType("NUMERIC(1)").IsRequired();
            builder.Property(t => t.TipoOperacao).HasColumnName("tipo_operacao").HasColumnType("VARCHAR(10)").IsRequired();

            builder.HasKey(t => t.Id);

            builder.HasOne(t => t.Venda).WithOne(t => t.Veiculo).HasForeignKey<Vendas>(t => t.IdVeiculo);
            builder.HasOne(t => t.Aluguel).WithOne(t => t.Veiculo).HasForeignKey<Alugueis>(t => t.IdVeiculo);
        }
    }
}

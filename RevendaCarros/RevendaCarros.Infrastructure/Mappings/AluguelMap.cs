using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RevendaCarros.Domain.Entities;
using System;

namespace RevendaCarros.Infrastructure
{
    public sealed class AluguelMap : IEntityTypeConfiguration<Alugueis>
    {
        public void Configure(EntityTypeBuilder<Alugueis> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.Property(t => t.Id).HasColumnName("id").IsRequired().HasColumnType("INT").ValueGeneratedOnAdd();
            builder.Property(t => t.IdVeiculo).HasColumnName("id_veiculo").HasColumnType("INT").IsRequired();
            builder.Property(t => t.ValorMensal).HasColumnName("valor").HasColumnType("NUMERIC(9,2)").IsRequired();
            builder.Property(t => t.Nome).HasColumnName("nome_cliente").HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(t => t.DataRetirada).HasColumnName("data_retirada").HasColumnType("DATE").IsRequired();
            builder.Property(t => t.DataDevolucao).HasColumnName("data_entrega").HasColumnType("DATE").IsRequired();

            builder.HasKey(t => t.Id);
        }
    }
}

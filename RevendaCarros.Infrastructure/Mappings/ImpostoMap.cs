using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RevendaCarros.Domain.Entities;
using System;

namespace RevendaCarros.Infrastructure
{
    public sealed class ImpostoMap : IEntityTypeConfiguration<Imposto>
    {
        public void Configure(EntityTypeBuilder<Imposto> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.Property(t => t.Id).HasColumnName("id").IsRequired().HasColumnType("INT").ValueGeneratedOnAdd();
            builder.Property(t => t.Valor).HasColumnName("valor").HasColumnType("DECIMAL(5,2)");
            builder.Property(t => t.Nome).HasColumnName("nome").HasColumnType("VARCHAR(150)");
            builder.Property(t => t.Descricao).HasColumnName("descricao").HasColumnType("VARCHAR(250)");

            builder.HasKey(t => t.Id);
        }
    }
}

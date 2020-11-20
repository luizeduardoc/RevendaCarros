using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RevendaCarros.Domain.Entities;
using System;

namespace RevendaCarros.Infrastructure
{
    public sealed class ImpostosMap : IEntityTypeConfiguration<Impostos>
    {
        public void Configure(EntityTypeBuilder<Impostos> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.Property(t => t.Id).HasColumnName("id").IsRequired().HasColumnType("INT").ValueGeneratedOnAdd();
            builder.Property(t => t.Valor).HasColumnName("valor").HasColumnType("DECIMAL(5,2)");

            builder.HasKey(t => t.Id);
        }
    }
}

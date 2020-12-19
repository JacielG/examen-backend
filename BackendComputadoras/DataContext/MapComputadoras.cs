using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BackendComputadoras.Models;

namespace BackendComputadoras.DataContext
{
    public class MapComputadoras : IEntityTypeConfiguration<Computadora>
    {
        public void Configure(EntityTypeBuilder<Computadora> builder)
        {
            builder.ToTable("Computadoras", "dbo");
            builder.HasKey(q => q.id);
            builder.Property(e => e.id).IsRequired().UseIdentityColumn();
            builder.Property(e => e.nombre).HasColumnType("varchar(50)").HasMaxLength(50).IsRequired();
            builder.Property(e => e.tipoDisco).HasColumnType("varchar(50)").HasMaxLength(50).IsRequired();
            builder.Property(e => e.precio).HasColumnType("varchar(50)").HasMaxLength(50).IsRequired();

            builder.HasOne(e => e.Marca)
                .WithMany(e => e.Computadoras)
                .HasForeignKey(e => e.marcaId);
        }
    }
}

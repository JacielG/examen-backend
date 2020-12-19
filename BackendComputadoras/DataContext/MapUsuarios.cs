using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendComputadoras.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendComputadoras.DataContext
{
    public class MapUsuarios : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios", "dbo");
            builder.HasKey(q => q.usuarioId);
            builder.Property(e => e.usuarioId).IsRequired();
            builder.Property(e => e.contrasena).HasColumnType("varchar(50)").HasMaxLength(50).IsRequired();
            builder.Property(e => e.estaActivo);
        }
    }
}

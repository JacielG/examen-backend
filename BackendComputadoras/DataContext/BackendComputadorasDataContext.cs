using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BackendComputadoras.Models;

namespace BackendComputadoras.DataContext
{
    public class BackendComputadorasDataContext : DbContext
    {
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Computadora> Computadoras { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=ARAX;DataBase=ComputadorasBD;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MapComputadoras());
            modelBuilder.ApplyConfiguration(new MapUsuarios());
            base.OnModelCreating(modelBuilder);
        }
    }
}

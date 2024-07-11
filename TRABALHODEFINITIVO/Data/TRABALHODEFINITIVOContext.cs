using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TRABALHODEFINITIVO.Models;

namespace TRABALHODEFINITIVO.Data
{
    public class TRABALHODEFINITIVOContext : DbContext
    {
        public TRABALHODEFINITIVOContext (DbContextOptions<TRABALHODEFINITIVOContext> options)
            : base(options)
        {
        }

        public DbSet<TRABALHODEFINITIVO.Models.Filme> Filme { get; set; } = default!;
        public DbSet<TRABALHODEFINITIVO.Models.Artista> Artista { get; set; } = default!;
        public DbSet<TRABALHODEFINITIVO.Models.FilmeAtores> FilmeAtores { get; set; } = default!;
        public DbSet<TRABALHODEFINITIVO.Models.Genero> Genero { get; set; } = default!;
        public DbSet<TRABALHODEFINITIVO.Models.Mensagem> Mensagem { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Filme>()
                .Property(f => f.Preco)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Filme>()
                .Property(f => f.ValorCusto)
                .HasColumnType("decimal(18,2)");


        }
    }
}

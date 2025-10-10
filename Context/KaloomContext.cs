using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KaloomAPI.Models;

namespace KaloomAPI.Context
{
    public class KaloomContext : DbContext
    {
        public KaloomContext(DbContextOptions<KaloomContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>()
                .HasOne(a => a.Usuario)
                .WithOne(u => u.Aluno)
                .HasForeignKey<Aluno>(a => a.IdUsuario);

            modelBuilder.Entity<Aluno>()
                .HasOne(a => a.TipoAluno)
                .WithMany()
                .HasForeignKey(a => a.IdTipoAluno);
                
            modelBuilder.Entity<Etec>().ToTable("Etecs");
            modelBuilder.Entity<Fatec>().ToTable("Fatecs");
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<TipoAluno> TipoAlunos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Etec> Etecs { get; set; }
        public DbSet<Fatec> Fatecs { get; set; }
    }
}
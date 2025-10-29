using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Kaloom.API.Models;

namespace Kaloom.API.Context
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

            modelBuilder.Entity<Etec>().HasData(
               new Etec
               {
                   Id = 1,
                   NomeUnidade = "Etec JK - Sede"
               },
               new Etec
               {
                   Id = 2,
                   NomeUnidade = "Etec JK - Extensão Céu Caminho do Mar"
               },
               new Etec
               {
                   Id = 3,
                   NomeUnidade = "Etec JK - Extensão Associação Comunitária Despertar"
               },
               new Etec
               {
                   Id = 4,
                   NomeUnidade = "Etec Lauro Gomes"
               },
               new Etec
               {
                   Id = 5,
                   NomeUnidade = "Etec Jorge Street"
               }
            );

            modelBuilder.Entity<Fatec>().HasData(
               new Fatec
               {
                   Id = 1,
                   NomeUnidade = "Fatec Diadema - \"Luigi Papaiz\""
               },
               new Fatec
               {
                   Id = 2,
                   NomeUnidade = "Fatec SBC - \"Adib Moisés Dib\""
               },
               new Fatec
               {
                   Id = 3,
                   NomeUnidade = "Fatec São Paulo"
               }
            );
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<TipoAluno> TipoAlunos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Etec> Etecs { get; set; }
        public DbSet<Fatec> Fatecs { get; set; }
    }
}
using Kaloom.API.Models;
using Kaloom.Communication.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kaloom.API.Context
{
    public class KaloomContext : DbContext
    {
        public KaloomContext(DbContextOptions<KaloomContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>(entity =>
            {
                entity.Property(a => a.Nome)
                .HasColumnType("varchar(16)");
                entity.Property(a => a.Sobrenome)
                .HasColumnType("varchar(24)");
                entity.Property(a => a.NomeUsuario)
                .HasColumnType("varchar(24)");
                entity.HasOne(a => a.Usuario)
                .WithOne(u => u.Aluno)
                .HasForeignKey<Aluno>(a => a.IdUsuario)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
                entity.HasOne(a => a.TipoAluno)
                .WithMany(t => t.Alunos)
                .HasForeignKey(a => a.IdTipoAluno)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
            });

            modelBuilder.Entity<Etec>().ToTable("Etecs");
            modelBuilder.Entity<Fatec>().ToTable("Fatecs");

            modelBuilder.Entity<TipoAluno>()
                .HasIndex(t => new { t.Fatec, t.Etec, t.StatusFatec, t.StatusEtec })
                .IsUnique();

            modelBuilder.Entity<TipoAluno>()
                .Property(t => t.Description)
                .HasColumnType("varchar(35)");

            modelBuilder.Entity<TipoAluno>()
                .ToTable(t => t.HasCheckConstraint(
                    "CK_StudentType_StatusEtec",
                    "StatusEtec IN (1,2)"
                ));

            modelBuilder.Entity<TipoAluno>()
                .ToTable(t => t.HasCheckConstraint(
                    "CK_StudentType_StatusFatec",
                    "StatusFatec IN (1,2)"
                ));



            modelBuilder.Entity<TipoAluno>().HasData(
                new TipoAluno
                {
                    Id = 1,
                    Fatec = true,
                    Etec = false,
                    StatusFatec = EAcademicStatus.Cursando,
                    StatusEtec = null,
                    Description = "Aluno Fatec"
                },
                new TipoAluno
                {
                    Id = 2,
                    Fatec = true,
                    Etec = false,
                    StatusFatec = EAcademicStatus.Formado,
                    StatusEtec = null,
                    Description = "Ex-Aluno Fatec"
                },
                new TipoAluno
                {
                    Id = 3,
                    Fatec = false,
                    Etec = true,
                    StatusFatec = null,
                    StatusEtec = EAcademicStatus.Cursando,
                    Description = "Aluno Etec"
                },
                new TipoAluno
                {
                    Id = 4,
                    Fatec = false,
                    Etec = true,
                    StatusFatec = null,
                    StatusEtec = EAcademicStatus.Formado,
                    Description = "Ex-Aluno Etec"
                },
                new TipoAluno
                {
                    Id = 5,
                    Fatec = true,
                    Etec = true,
                    StatusFatec = EAcademicStatus.Cursando,
                    StatusEtec = EAcademicStatus.Cursando,
                    Description = "Aluno Fatec e Etec"
                },
                new TipoAluno
                {
                    Id = 6,
                    Fatec = true,
                    Etec = true,
                    StatusFatec = EAcademicStatus.Cursando,
                    StatusEtec = EAcademicStatus.Formado,
                    Description = "Aluno Fatec e Ex-Aluno Etec"
                },
                new TipoAluno
                {
                    Id = 7,
                    Fatec = true,
                    Etec = true,
                    StatusFatec = EAcademicStatus.Formado,
                    StatusEtec = EAcademicStatus.Cursando,
                    Description = "Aluno Etec e Ex-Aluno Fatec"
                },
                new TipoAluno
                {
                    Id = 8,
                    Fatec = true,
                    Etec = true,
                    StatusFatec = EAcademicStatus.Formado,
                    StatusEtec = EAcademicStatus.Formado,
                    Description = "Ex-Aluno Fatec e Ex-Aluno Etec"
                }
            );


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
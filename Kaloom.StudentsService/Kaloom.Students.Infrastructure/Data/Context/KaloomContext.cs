using Kaloom.Students.Domain.Models;
using Kaloom.Students.Infrastructure.Data.Seeds;
using Microsoft.EntityFrameworkCore;

namespace Kaloom.Students.Infrastructure.Data.Context
{
    public class KaloomContext : DbContext
    {
        public KaloomContext(DbContextOptions<KaloomContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(KaloomContext).Assembly);

            EtecSeed.Seed(modelBuilder);
            FatecSeed.Seed(modelBuilder);
            StudentTypeSeed.Seed(modelBuilder);
        }


        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<TipoAluno> TipoAlunos { get; set; }
        public DbSet<Etec> Etecs { get; set; }
        public DbSet<Fatec> Fatecs { get; set; }
    }
}
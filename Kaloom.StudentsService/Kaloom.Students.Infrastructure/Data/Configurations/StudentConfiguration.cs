using Kaloom.Students.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Kaloom.Students.Infrastructure.Data.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder
                .HasMany(a => a.Instituicoes)
                .WithMany(i => i.Alunos)
                .UsingEntity(j => j.ToTable("AlunoInstituicoes"));

            builder
                .Property(a => a.Nome)
                .HasColumnType("varchar(16)");

            builder
                .Property(a => a.Sobrenome)
                .HasColumnType("varchar(24)");

            


            builder
                .HasOne(a => a.TipoAluno)
                .WithMany(t => t.Alunos)
                .HasForeignKey(a => a.IdTipoAluno)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }
    }
}

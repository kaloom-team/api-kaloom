using Kaloom.Students.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kaloom.Students.Infrastructure.Data.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder
                .Property(a => a.Nome)
                .HasColumnType("varchar(16)");

            builder
                .Property(a => a.Sobrenome)
                .HasColumnType("varchar(24)");

            builder
                .Property(a => a.NomeUsuario)
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

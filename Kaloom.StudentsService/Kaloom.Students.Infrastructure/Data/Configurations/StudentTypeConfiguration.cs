using Kaloom.Students.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kaloom.Students.Infrastructure.Data.Configurations
{
    public class StudentTypeConfiguration : IEntityTypeConfiguration<TipoAluno>
    {
        public void Configure(EntityTypeBuilder<TipoAluno> builder)
        {
            builder
                .HasIndex(t => new { t.Fatec, t.Etec, t.StatusFatec, t.StatusEtec })
                .IsUnique();

            builder
                .Property(t => t.Description)
                .HasColumnType("varchar(35)");

            builder
                .ToTable(t => t.HasCheckConstraint(
                    "CK_StudentType_StatusEtec",
                    "StatusEtec IN (1,2)"
                ));

            builder
                .ToTable(t => t.HasCheckConstraint(
                    "CK_StudentType_StatusFatec",
                    "StatusFatec IN (1,2)"
                ));
        }
    }
}

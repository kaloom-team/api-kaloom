using Kaloom.Students.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kaloom.Students.Infrastructure.Data.Configurations
{
    public class EtecConfiguration : IEntityTypeConfiguration<Etec>
    {
        public void Configure(EntityTypeBuilder<Etec> builder)
        {
            builder.ToTable("Etecs");

            builder
                .Property(t => t.NomeUnidade)
                .HasColumnType("varchar(60)");
        }
    }
}

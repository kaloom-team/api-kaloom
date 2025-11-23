using Kaloom.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kaloom.Infrastructure.Data.Configurations
{
    public class FatecConfiguration : IEntityTypeConfiguration<Fatec>
    {
        public void Configure(EntityTypeBuilder<Fatec> builder)
        {
            builder.ToTable("Fatecs");

            builder
                .Property(t => t.NomeUnidade)
                .HasColumnType("varchar(50)");
        }
    }
}

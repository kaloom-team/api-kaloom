using Kaloom.Users.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kaloom.Users.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder
                .Property(a => a.NomeUsuario)
                .HasColumnType("varchar(24)");
        }
    }
}

using Kaloom.Users.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaloom.Users.Infrastructure.Data.Context
{
    public class UsersContext : DbContext
    {
        public UsersContext(DbContextOptions<UsersContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}

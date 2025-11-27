using Kaloom.Students.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Kaloom.Students.Infrastructure.Data.Seeds
{
    public static class EtecSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
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
        }
    }
}

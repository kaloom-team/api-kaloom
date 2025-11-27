using Kaloom.Students.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Kaloom.Students.Infrastructure.Data.Seeds
{
    public static class FatecSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fatec>().HasData(
               new Fatec
               {
                   Id = 6,
                   NomeUnidade = "Fatec Diadema - \"Luigi Papaiz\""
               },
               new Fatec
               {
                   Id = 7,
                   NomeUnidade = "Fatec SBC - \"Adib Moisés Dib\""
               },
               new Fatec
               {
                   Id = 8,
                   NomeUnidade = "Fatec São Paulo"
               }
            );
        }
    }
}

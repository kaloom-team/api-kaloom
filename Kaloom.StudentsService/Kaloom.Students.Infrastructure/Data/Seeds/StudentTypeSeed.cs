using Kaloom.Students.Domain.Enums;
using Kaloom.Students.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Kaloom.Students.Infrastructure.Data.Seeds
{
    public static class StudentTypeSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoAluno>().HasData(
                new TipoAluno
                {
                    Id = 1,
                    Fatec = true,
                    Etec = false,
                    StatusFatec = EAcademicStatus.Cursando,
                    StatusEtec = null,
                    Description = "Aluno Fatec"
                },
                new TipoAluno
                {
                    Id = 2,
                    Fatec = true,
                    Etec = false,
                    StatusFatec = EAcademicStatus.Formado,
                    StatusEtec = null,
                    Description = "Ex-Aluno Fatec"
                },
                new TipoAluno
                {
                    Id = 3,
                    Fatec = false,
                    Etec = true,
                    StatusFatec = null,
                    StatusEtec = EAcademicStatus.Cursando,
                    Description = "Aluno Etec"
                },
                new TipoAluno
                {
                    Id = 4,
                    Fatec = false,
                    Etec = true,
                    StatusFatec = null,
                    StatusEtec = EAcademicStatus.Formado,
                    Description = "Ex-Aluno Etec"
                },
                new TipoAluno
                {
                    Id = 5,
                    Fatec = true,
                    Etec = true,
                    StatusFatec = EAcademicStatus.Cursando,
                    StatusEtec = EAcademicStatus.Cursando,
                    Description = "Aluno Fatec e Etec"
                },
                new TipoAluno
                {
                    Id = 6,
                    Fatec = true,
                    Etec = true,
                    StatusFatec = EAcademicStatus.Cursando,
                    StatusEtec = EAcademicStatus.Formado,
                    Description = "Aluno Fatec e Ex-Aluno Etec"
                },
                new TipoAluno
                {
                    Id = 7,
                    Fatec = true,
                    Etec = true,
                    StatusFatec = EAcademicStatus.Formado,
                    StatusEtec = EAcademicStatus.Cursando,
                    Description = "Aluno Etec e Ex-Aluno Fatec"
                },
                new TipoAluno
                {
                    Id = 8,
                    Fatec = true,
                    Etec = true,
                    StatusFatec = EAcademicStatus.Formado,
                    StatusEtec = EAcademicStatus.Formado,
                    Description = "Ex-Aluno Fatec e Ex-Aluno Etec"
                }
            );
        }
    }
}

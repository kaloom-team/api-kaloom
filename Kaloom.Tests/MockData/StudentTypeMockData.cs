using Kaloom.Communication.DTOs.Requests;
using Kaloom.Communication.DTOs.Responses;
using Kaloom.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaloom.Tests.MockData
{
    public class StudentTypeMockData
    {
        public static IEnumerable<StudentTypeResponse> GetAll()
        {
            return new List<StudentTypeResponse>
            {
                new(
                    1,
                    Fatec: true,
                    Etec: false,
                    StatusEtec: null,
                    StatusFatec: EAcademicStatus.Cursando,
                    Description: "Aluno Fatec"
                ),
                new(
                    2,
                    Fatec: false,
                    Etec: true,
                    StatusEtec: EAcademicStatus.Cursando,
                    StatusFatec: null,
                    Description: "Aluno Etec"
                )
            };
        }

        public static StudentTypeResponse GetById(int id)
        {
            return new StudentTypeResponse
            (
                id,
                true,
                false,
                null,
                EAcademicStatus.Formado,
                "Mock StudentType"
            );
        }

        public static StudentTypeRequest RegisterRequest()
        {
            return new StudentTypeRequest
            {
                Fatec = true,
                Etec = false,
                StatusFatec = EAcademicStatus.Cursando,
                Description = "Novo Tipo de Aluno"
            };
        }

        public static StudentTypeResponse RegisterResponse()
        {
            return new StudentTypeResponse
            (
                1,
                true,
                false,
                null,
                EAcademicStatus.Cursando,
                "Novo Tipo de Aluno"
            );
        }

        public static StudentTypeRequest UpdateRequest()
        {
            return new StudentTypeRequest
            {
                Fatec = false,
                Etec = true,
                StatusEtec = EAcademicStatus.Formado,
                Description = "Atualizado"
            };
        }
    }
}

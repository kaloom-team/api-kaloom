using Kaloom.Communication.DTOs.Requests;
using Kaloom.Communication.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaloom.Tests.MockData
{
    public class FatecMockData
    {
        public static IEnumerable<FatecResponse> GetAll()
        {
            return new List<FatecResponse>
            {
                new(1, "Fatec Diadema"),
                new(2, "Fatec São Caetano")
            };
        }

        public static FatecResponse GetById(int id)
        {
            return new FatecResponse { Id = id };
        }

        public static FatecRequest RegisterRequest()
        {
            return new FatecRequest
            {
                NomeUnidade = "Fatec Diadema"
            };
        }

        public static FatecResponse RegisterResponse()
        {
            return new FatecResponse
            (
                1,
                "Fatec Diadema"
            );
        }

        public static FatecRequest UpdateRequest(string nome)
        {
            return new FatecRequest
            {
                NomeUnidade = nome
            };
        }
    }
}

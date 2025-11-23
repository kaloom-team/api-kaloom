using Kaloom.Communication.DTOs.Requests;
using Kaloom.Communication.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaloom.Tests.MockData
{
    public class EtecMockData
    {
        public static IEnumerable<EtecResponse> GetAll()
        {
            return new List<EtecResponse>
            {
                new(1, "Etec JK - Sede"),
                new(2, "Etec Lauro Gomes")
            };
        }

        public static EtecResponse GetById(int id)
        {
            return new EtecResponse { Id = id };
        }

        public static EtecRequest RegisterRequest()
        {
            return new EtecRequest
            {
                NomeUnidade = "Etec Lauro Gomes"
            };
        }

        public static EtecResponse RegisterResponse()
        {
            return new EtecResponse
            (
                1,
                "Etec JK - Sede"
            );
        }

        public static EtecRequest UpdateRequest(string nome)
        {
            return new EtecRequest
            {
                NomeUnidade = nome
            };
        }
    }
}

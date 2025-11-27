using Kaloom.Users.Communication.DTOs.Requests;
using Kaloom.Users.Communication.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaloom.Users.Tests.MockData
{
    public class UsuarioMockData
    {
        public static IEnumerable<UserResponse> GetAll()
        {
            return new List<UserResponse>
            {
                new(
                    1,
                    "john@email.com"
                ),
                new(
                    1,
                    "jane@email.com"
                )
            };
        }

        public static UserResponse GetById(int id)
        {
            return new UserResponse { Id = id };
        }

        public static UserRequest RegisterRequest()
        {
            return new UserRequest
            {
                Email = "john@email.com",
                Senha = "123"
            };
        }

        public static UserResponse RegisterResponse()
        {
            return new UserResponse(1, "john@email.com");
        }

        public static UserRequest UpdateRequest(string email, string senha)
        {
            return new UserRequest
            {
                Email = email,
                Senha = senha
            };
        }
    }
}

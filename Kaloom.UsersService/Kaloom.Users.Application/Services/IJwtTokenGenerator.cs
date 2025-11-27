using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaloom.Users.Application.Services
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(int userId, string email);
    }
}

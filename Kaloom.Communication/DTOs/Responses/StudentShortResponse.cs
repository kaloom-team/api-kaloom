using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Kaloom.Communication.DTOs.Responses
{
    public class StudentShortResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string NomeUsuario { get; set; } = string.Empty;
        public DateOnly DataNascimento { get; set; }
        public UserResponse Usuario { get; set; } = new UserResponse();
        public StudentTypeResponse TipoAluno { get; set; } = new StudentTypeResponse();
    }
}
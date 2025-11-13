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
        public string Sobrenome { get; set; } = string.Empty;
    }
}
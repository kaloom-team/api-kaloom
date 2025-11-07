using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kaloom.Communication.DTOs.Responses
{
    public class StudentTypeResponse
    {
        public int Id { get; set; }
        public bool Fatec { get; set; }
        public bool Etec { get; set; }
    }
}
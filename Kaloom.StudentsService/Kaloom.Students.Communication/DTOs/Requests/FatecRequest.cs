using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaloom.Students.Communication.DTOs.Requests
{
    public class FatecRequest : IInstitutionRequest
    {
        public int Id { get; set; }
        public string NomeUnidade { get; set; } = string.Empty;
    }
}

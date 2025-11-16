using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaloom.Communication.DTOs.Responses
{
    public class FatecResponse : IInstitutionResponse
    {
        public int Id { get; set; }
        public string NomeUnidade { get; set; } = string.Empty;
    }
}

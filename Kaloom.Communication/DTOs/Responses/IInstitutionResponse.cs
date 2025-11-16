using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaloom.Communication.DTOs.Responses
{
    public interface IInstitutionResponse
    {
        int Id { get; set; }
        string NomeUnidade { get; set; }
    }
}

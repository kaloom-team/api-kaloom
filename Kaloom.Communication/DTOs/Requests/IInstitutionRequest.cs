using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaloom.Communication.DTOs.Requests
{
    public interface IInstitutionRequest
    {
        public int Id { get; set; }
        public string NomeUnidade { get; set; }
    }
}

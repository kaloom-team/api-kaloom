using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kaloom.API.Models;
using Kaloom.Communication.DTOs.Responses;

namespace Kaloom.API.Factories
{
    public interface IStudentShortFactory
    {
        public StudentShortResponse Create(Aluno aluno);
    }
}
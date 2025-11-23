using Kaloom.Domain.Models;
using Kaloom.Communication.DTOs.Requests;
using Kaloom.Communication.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kaloom.Application.Factories
{
    public interface IStudentShortFactory
    {
        public StudentShortResponse Create(Aluno aluno);
    }
}
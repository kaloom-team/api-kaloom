using Kaloom.Students.Communication.DTOs.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kaloom.Students.Communication.DTOs.Responses;
using Kaloom.Students.Domain.Models;

namespace Kaloom.Students.Application.Factories
{
    public interface IStudentShortFactory
    {
        public StudentShortResponse Create(Aluno aluno);
    }
}
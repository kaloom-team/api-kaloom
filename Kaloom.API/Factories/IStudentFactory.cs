using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kaloom.API.Models;
using Kaloom.Communication.DTOs.Requests;

namespace Kaloom.API.Factories
{
    public interface IStudentFactory
    {
        public Aluno Create(StudentRequest dto);
    }
}
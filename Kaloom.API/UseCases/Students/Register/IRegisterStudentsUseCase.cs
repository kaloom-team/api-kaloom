using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kaloom.Communication.DTOs.Responses;
using Kaloom.Communication.DTOs.Requests;

namespace Kaloom.API.UseCases.Students.Register
{
    public interface IRegisterStudentsUseCase
    {
        public Task<StudentResponse> ExecuteAsync(StudentRequest request);
    }
}
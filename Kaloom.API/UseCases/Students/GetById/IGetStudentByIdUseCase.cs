using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kaloom.API.Models;
using Kaloom.Communication.DTOs.Responses;

namespace Kaloom.API.UseCases.Students.GetById
{
    public interface IGetStudentByIdUseCase
    {
        public Task<StudentResponse> ExecuteAsync(int id);
    }
}
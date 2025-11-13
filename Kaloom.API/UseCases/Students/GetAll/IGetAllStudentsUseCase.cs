using Kaloom.API.Models;
using Kaloom.Communication.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kaloom.API.UseCases.Students.GetAll
{
    public interface IGetAllStudentsUseCase
    {
        public Task<IEnumerable<StudentResponse>> ExecuteAsync();
    }
}
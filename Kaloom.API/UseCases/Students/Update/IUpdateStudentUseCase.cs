using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kaloom.Communication.DTOs.Requests;

namespace Kaloom.API.UseCases.Students.Update
{
    public interface IUpdateStudentUseCase
    {
        public Task ExecuteAsync(int id, StudentRequest request);
    }
}
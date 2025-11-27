using Kaloom.SharedContracts.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaloom.Students.Application.UseCases.Students.GetByReferenceId
{
    public interface IGetStudentByReferenceIdUseCase
    {
        Task<StudentResponse?> ExecuteAsync(int userId);
    }
}

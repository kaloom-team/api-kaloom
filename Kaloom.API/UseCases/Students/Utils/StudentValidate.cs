using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kaloom.Communication.DTOs.Requests;
using Kaloom.API.UseCases.Students.SharedValidator;
using Kaloom.Exceptions.ExceptionsBase;

namespace Kaloom.API.UseCases.Students.Utils
{
    public class StudentValidate
    {
        public static void Validate(StudentRequest request)
        {
            var validator = new StudentRequestValidator();

            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(error => error.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errors);
            }
        }
    }
}
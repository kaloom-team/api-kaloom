using Kaloom.Students.Application.UseCases.StudentsTypes.SharedValidator;
using Kaloom.Students.Exceptions.ExceptionsBase;
using Kaloom.Students.Communication.DTOs.Requests;

namespace Kaloom.Students.Application.UseCases.StudentsTypes.Utils
{
    public class StudentTypeValidate
    {
        public static void Validate(StudentTypeRequest request)
        {
            var validator = new StudentTypeRequestValidator();

            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(error => error.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errors);
            }
        }
    }
}
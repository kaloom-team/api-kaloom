using Kaloom.Application.UseCases.StudentsTypes.SharedValidator;
using Kaloom.Communication.DTOs.Requests;
using Kaloom.Exceptions.ExceptionsBase;

namespace Kaloom.Application.UseCases.StudentsTypes.Utils
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
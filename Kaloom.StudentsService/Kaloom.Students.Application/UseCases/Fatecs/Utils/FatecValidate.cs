using Kaloom.Students.Application.UseCases.Fatecs.SharedValidator;
using Kaloom.Students.Exceptions.ExceptionsBase;
using Kaloom.Students.Communication.DTOs.Requests;

namespace Kaloom.Students.Application.UseCases.Fatecs.Utils
{
    public class FatecValidate
    {
        public static void Validate(FatecRequest request)
        {
            var validator = new FatecRequestValidator();

            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(error => error.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errors);
            }
        }
    }
}
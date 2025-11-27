using Kaloom.Students.Application.UseCases.Etecs.SharedValidator;
using Kaloom.Students.Exceptions.ExceptionsBase;
using Kaloom.Students.Communication.DTOs.Requests;

namespace Kaloom.Students.Application.UseCases.Etecs.Utils
{
    public class EtecValidate
    {
        public static void Validate(EtecRequest request)
        {
            var validator = new EtecRequestValidator();

            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(error => error.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errors);
            }
        }
    }
}
using Kaloom.Application.UseCases.Etecs.SharedValidator;
using Kaloom.Communication.DTOs.Requests;
using Kaloom.Exceptions.ExceptionsBase;

namespace Kaloom.Application.UseCases.Etecs.Utils
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
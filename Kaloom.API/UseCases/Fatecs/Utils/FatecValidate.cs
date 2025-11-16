using Kaloom.API.UseCases.Fatecs.SharedValidator;
using Kaloom.Communication.DTOs.Requests;
using Kaloom.Exceptions.ExceptionsBase;

namespace Kaloom.API.UseCases.Fatecs.Utils
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

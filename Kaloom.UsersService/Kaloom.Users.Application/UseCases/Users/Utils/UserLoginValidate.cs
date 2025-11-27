using Kaloom.Users.Communication.DTOs.Requests;
using Kaloom.Users.Exceptions.ExceptionsBase;
using Kaloom.Users.Application.UseCases.Users.SharedValidator;

namespace Kaloom.Users.Application.UseCases.Users.Utils
{
    public class UserLoginValidate
    {
        public static void Validate(UserLoginRequest request)
        {
            var validator = new UserLoginRequestValidator();

            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(error => error.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errors);
            }
        }
    }
}
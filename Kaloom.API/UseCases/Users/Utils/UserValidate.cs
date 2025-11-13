using Kaloom.Communication.DTOs.Requests;
using Kaloom.Exceptions.ExceptionsBase;
using Kaloom.API.UseCases.Users.SharedValidator;

namespace Kaloom.API.UseCases.Users.Utils
{
    public class UserValidate
    {
        public static void Validate(UserRequest request)
        {
            var validator = new UserRequestValidator();

            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(error => error.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errors);
            }
        }
    }
}

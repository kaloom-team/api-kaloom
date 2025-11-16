using FluentValidation;
using Kaloom.Communication.DTOs.Requests;

namespace Kaloom.API.UseCases.Users.SharedValidator
{
    public class UserRequestValidator : AbstractValidator<UserRequest>
    {
        public UserRequestValidator()
        {
            RuleFor(user => user.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress().WithMessage("O email é obrigatório, digite um email válido.");
        }
    }
}
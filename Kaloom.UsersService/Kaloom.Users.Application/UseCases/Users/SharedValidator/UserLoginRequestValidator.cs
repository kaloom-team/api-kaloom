using FluentValidation;
using Kaloom.Users.Communication.DTOs.Requests;

namespace Kaloom.Users.Application.UseCases.Users.SharedValidator
{
    public class UserLoginRequestValidator : AbstractValidator<UserLoginRequest>
    {
        public UserLoginRequestValidator()
        {
            RuleFor(user => user.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress().WithMessage("O email é obrigatório, digite um email válido.");
        }
    }
}
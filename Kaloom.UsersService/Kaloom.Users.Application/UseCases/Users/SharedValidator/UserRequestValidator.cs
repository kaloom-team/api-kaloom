using FluentValidation;
using Kaloom.Users.Communication.DTOs.Requests;

namespace Kaloom.Users.Application.UseCases.Users.SharedValidator
{
    public class UserRequestValidator : AbstractValidator<UserRequest>
    {
        public UserRequestValidator()
        {
            RuleFor(user => user.NomeUsuario)
                .NotEmpty()
                .NotNull()
                .WithMessage("O nome de usuário é obrigatório, não pode ser vazio ou conter apenas espaços.");

            RuleFor(user => user.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress().WithMessage("O email é obrigatório, digite um email válido.");
        }
    }
}
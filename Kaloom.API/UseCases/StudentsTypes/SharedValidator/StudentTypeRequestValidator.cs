using FluentValidation;
using Kaloom.Communication.DTOs.Requests;

namespace Kaloom.API.UseCases.StudentsTypes.SharedValidator
{
    public class StudentTypeRequestValidator : AbstractValidator<StudentTypeRequest>
    {
        public StudentTypeRequestValidator()
        {
            RuleFor(tipoAluno => tipoAluno.Fatec)
                .NotNull()
                .NotEmpty().WithMessage("O campo Fatec é obrigatório.");

            RuleFor(tipoAluno => tipoAluno.Etec)
                .NotNull()
                .NotEmpty().WithMessage("O campo Etec é obrigatório.");

            RuleFor(tipoAluno => tipoAluno.Description)
                .NotNull()
                .NotEmpty().WithMessage("A descrição é obrigatória.");
        }
    }
}
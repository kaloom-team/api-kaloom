using FluentValidation;
using Kaloom.Students.Communication.DTOs.Requests;

namespace Kaloom.Students.Application.UseCases.Fatecs.SharedValidator
{
    public class FatecRequestValidator : AbstractValidator<FatecRequest>
    {
        public FatecRequestValidator()
        {
            RuleFor(fatec => fatec.NomeUnidade)
                .NotNull()
                .NotEmpty().WithMessage("O nome da unidade é obrigatório.");
        }
    }
}
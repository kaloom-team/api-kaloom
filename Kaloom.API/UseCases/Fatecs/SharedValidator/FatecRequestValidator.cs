using FluentValidation;
using Kaloom.Communication.DTOs.Requests;

namespace Kaloom.API.UseCases.Fatecs.SharedValidator
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

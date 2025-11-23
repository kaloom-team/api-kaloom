using FluentValidation;
using Kaloom.Communication.DTOs.Requests;

namespace Kaloom.Application.UseCases.Etecs.SharedValidator
{
    public class EtecRequestValidator : AbstractValidator<EtecRequest>
    {
        public EtecRequestValidator()
        {
            RuleFor(etec => etec.NomeUnidade)
                .NotNull()
                .NotEmpty().WithMessage("O nome da unidade é obrigatório.");
        }
    }
}

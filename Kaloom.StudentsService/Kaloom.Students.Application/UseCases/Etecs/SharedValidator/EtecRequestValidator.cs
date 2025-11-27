using FluentValidation;
using Kaloom.Students.Communication.DTOs.Requests;

namespace Kaloom.Students.Application.UseCases.Etecs.SharedValidator
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

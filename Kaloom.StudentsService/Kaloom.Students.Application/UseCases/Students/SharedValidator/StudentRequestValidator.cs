using FluentValidation;
using Kaloom.Students.Application.UseCases.Students.SharedValidator.Utils;
using Kaloom.Students.Communication.DTOs.Requests;


namespace Kaloom.Students.Application.UseCases.Students.SharedValidator
{
    public class StudentRequestValidator : AbstractValidator<StudentRequest>
    {
        public StudentRequestValidator()
        {
            RuleFor(student => student.IdTipoAluno)
                .NotEmpty()
                .GreaterThan(0).WithMessage("O Tipo de Aluno é obrigatório.");

            RuleFor(student => student.IdUsuario)
                .NotEmpty()
                .GreaterThan(0).WithMessage("O usuário é obrigatório.");

            RuleFor(student => student.Nome)
                .NotEmpty()
                .NotNull()
                .WithMessage("O nome é obrigatório, não pode ser vazio ou conter apenas espaços.");

            RuleFor(student => student.Sobrenome)
                .NotEmpty()
                .NotNull()
                .WithMessage("O sobrenome é obrigatório, não pode ser vazio ou conter apenas espaços.");

            RuleFor(student => student.DataNascimento)
                .NotEmpty().WithMessage("A data de nascimento é obrigatória, não pode ser vazio ou conter apenas espaços.")
                .NotNull().WithMessage("A data de nascimento é obrigatória, não pode ser vazio ou conter apenas espaços.")
                .Must(BirthDateValidate.ValidDate).WithMessage("A data de nascimento deve ser válida.")
                .Must(BirthDateValidate.InTheFuture).WithMessage("A data de nascimento não pode estar no futuro.");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Kaloom.API.UseCases.Students.SharedValidator.Utils;
using Kaloom.Communication.DTOs.Requests;


namespace Kaloom.API.UseCases.Students.SharedValidator
{
    public class StudentRequestValidator : AbstractValidator<StudentRequest>
    {
        public StudentRequestValidator()
        {
            RuleFor(student => student.Nome)
                .NotEmpty()
                .NotNull()
                .WithMessage("O nome é obrigatório, não pode ser vazio ou conter apenas espaços.");

            RuleFor(student => student.Sobrenome)
                .NotEmpty()
                .NotNull()
                .WithMessage("O sobrenome é obrigatório, não pode ser vazio ou conter apenas espaços.");

            RuleFor(student => student.NomeUsuario)
                .NotEmpty()
                .NotNull()
                .WithMessage("O nome de usuário é obrigatório, não pode ser vazio ou conter apenas espaços.");

            RuleFor(student => student.DataNascimento)
                .NotEmpty().WithMessage("A data de nascimento é obrigatória, não pode ser vazio ou conter apenas espaços.")
                .NotNull().WithMessage("A data de nascimento é obrigatória, não pode ser vazio ou conter apenas espaços.")
                .Must(BirthDateValidate.ValidDate).WithMessage("A data de nascimento deve ser válida.")
                .Must(BirthDateValidate.InTheFuture).WithMessage("A data de nascimento não pode estar no futuro.");
        }
    }
}
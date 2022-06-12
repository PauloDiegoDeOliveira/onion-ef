﻿using Empresa.Projeto.Application.Dtos.AlunoB64;
using FluentValidation;


namespace Empresa.Projeto.Application.Validations.AlunoB64
{
    public class PostAlunoB64Valitator : AbstractValidator<PostAlunoB64Dto>
    {
        public PostAlunoB64Valitator()
        {
            RuleFor(x => x.Nome)
               .NotNull()
               .WithMessage("O nome não pode ser nulo.")

               .NotEmpty()
               .WithMessage("O nome não pode ser vazio.")

               .MinimumLength(3)
               .WithMessage("O nome deve ter no mínimo 3 caracteres.")

               .MaximumLength(100)
               .WithMessage("O nome deve ter no máximo 100 caracteres.");

            RuleFor(x => x.Sobrenome)
               .NotNull()
               .WithMessage("O sobrenome não pode ser nulo.")

               .NotEmpty()
               .WithMessage("O sobrenome não pode ser vazio.")

               .MinimumLength(3)
               .WithMessage("O sobrenome deve ter no mínimo 3 caracteres.")

               .MaximumLength(100)
               .WithMessage("O sobrenome deve ter no máximo 100 caracteres.");

            RuleFor(x => x.ImagemEmBase64)
                .NotNull()
                .WithMessage("A imagem não pode ser nula.")

                .NotEmpty()
                .WithMessage("A imagem não pode ser vazio.");
        }
    }
}

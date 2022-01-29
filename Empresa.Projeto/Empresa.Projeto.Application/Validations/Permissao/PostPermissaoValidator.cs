using Empresa.Projeto.Application.Dtos.Permissao;
using FluentValidation;

namespace Empresa.Projeto.Application.Validations.Permissao
{
    public class PostPermissaoValidator : AbstractValidator<PostPermissaoDto>
    {
        public PostPermissaoValidator()
        {
            RuleFor(x => x.Nome)
                .NotNull()
                .WithMessage("O nome não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O nome não pode ser vazio.")

                .MinimumLength(3)
                .WithMessage("O nome deve ter no mínimo 3 caracteres.")

                .MaximumLength(1000)
                .WithMessage("O nome deve ter no máximo 100 caracteres.");

            RuleFor(x => x.Descricao)
                .NotNull()
                .WithMessage("A descrição não pode ser nula.")

                .NotEmpty()
                .WithMessage("A descrição não pode ser vazia.")

                .MinimumLength(3)
                .WithMessage("A descrição deve ter no mínimo 3 caracteres.")

                .MaximumLength(100)
                .WithMessage("A descrição deve ter no máximo 100 caracteres.");

            RuleFor(x => x.Status)
                .NotNull()
                .WithMessage("O status não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O status não pode ser vazio.");
        }
    }
}
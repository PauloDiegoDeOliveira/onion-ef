using Empresa.Projeto.Application.Dtos.Especialidade;
using FluentValidation;

namespace Empresa.Projeto.Application.Validations.Especialidade
{
    public class PostEspecialidadeValidator : AbstractValidator<PostEspecialidadeDto>
    {
        public PostEspecialidadeValidator()
        {
            RuleFor(x => x.Nome)
                .NotNull()
                .WithMessage("O nome não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O nome não pode ser vazio.")

                .MinimumLength(3)
                .WithMessage("O nome deve ter no mínimo 3 caracteres.")

                .MaximumLength(200)
                .WithMessage("O nome deve ter no máximo 200 caracteres.");

            RuleFor(x => x.Descricao)
                .NotNull()
                .WithMessage("A descrição não pode ser nulo.")

                .NotEmpty()
                .WithMessage("A descrição não pode ser vazio.")

                .MinimumLength(3)
                .WithMessage("A descrição deve ter no mínimo 3 caracteres.")

                .MaximumLength(200)
                .WithMessage("A descrição deve ter no máximo 200 caracteres.");

            RuleFor(x => x.Status)
                .NotNull()
                .WithMessage("O status não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O status não pode ser vazio.");
        }
    }
}

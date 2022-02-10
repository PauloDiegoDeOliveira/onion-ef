using Empresa.Projeto.Application.Dtos.Progresso;
using FluentValidation;

namespace Empresa.Projeto.Application.Validations.Progresso
{
    public class PostProgressoValidator : AbstractValidator<PostProgressoDto>
    {
        public PostProgressoValidator()
        {
            RuleFor(x => x.TotalProgresso)
                 .NotNull()
                 .WithMessage("O número do progresso não pode ser nulo.")

                 .NotEmpty()
                 .WithMessage("O número do progresso não pode ser vazio.")

                 .GreaterThanOrEqualTo(0)
                 .WithMessage("O número do progresso não pode ser menor que zero (0).")

                 .LessThanOrEqualTo(100)
                 .WithMessage("O número do progressoa não pode ser maior que cem (100).");

            RuleFor(x => x.Status)
                .NotNull()
                .WithMessage("O status não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O status não pode ser vazio.");
        }
    }
}
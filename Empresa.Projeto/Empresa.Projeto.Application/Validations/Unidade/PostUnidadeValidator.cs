using Empresa.Projeto.Application.Dtos.Unidade;
using Empresa.Projeto.Application.Interfaces;
using Empresa.Projeto.Application.Validations.Capitulo;
using FluentValidation;

namespace Empresa.Projeto.Application.Validations.Unidade
{
    public class PostUnidadeValidator : AbstractValidator<PostUnidadeDto>
    {
        private readonly IApplicationCapitulo applicationCapitulo;

        public PostUnidadeValidator(IApplicationCapitulo applicationCapitulo)
        {
            this.applicationCapitulo = applicationCapitulo;

            RuleFor(x => x.NumeroUnidade)
                .NotNull()
                .WithMessage("O número da unidade não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O número da unidade não pode ser vazio.");

            RuleFor(x => x.Capitulos)
                .NotNull()
                .WithMessage("O id de capítulo não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O id de capítulo não pode ser vazio.");

            RuleFor(x => x.Status)
                .NotNull()
                .WithMessage("O status não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O status não pode ser vazio.");

            RuleForEach(p => p.Capitulos).SetValidator(new ReferenciaCapituloValidator(applicationCapitulo));
        }
    }
}

using Empresa.Projeto.Application.Dtos.Capitulo;
using Empresa.Projeto.Application.Interfaces;
using Empresa.Projeto.Application.Validations.Progresso;
using FluentValidation;

namespace Empresa.Projeto.Application.Validations.Capitulo
{
    public class PostCapituloValidator : AbstractValidator<PostCapituloDto>
    {
        private readonly IApplicationProgresso applicationProgresso;

        public PostCapituloValidator(IApplicationProgresso applicationProgresso)
        {
            this.applicationProgresso = applicationProgresso;

            RuleFor(x => x.NumeroCapitulo)
                .NotNull()
                .WithMessage("O número do capítulo não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O número do capítulo não pode ser vazio.");

            RuleFor(x => x.Progressos)
                .NotNull()
                .WithMessage("O id de progresso não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O id de progresso não pode ser vazio.");

            RuleFor(x => x.Status)
                .NotNull()
                .WithMessage("O status não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O status não pode ser vazio.");

            RuleForEach(p => p.Progressos).SetValidator(new ReferenciaProgressoValidator(applicationProgresso));
        }
    }
}

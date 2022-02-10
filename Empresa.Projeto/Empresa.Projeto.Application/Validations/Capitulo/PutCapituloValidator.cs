using Empresa.Projeto.Application.Dtos.Capitulo;
using Empresa.Projeto.Application.Interfaces;
using Empresa.Projeto.Application.Validations.Progresso;
using FluentValidation;
using System.Threading.Tasks;

namespace Empresa.Projeto.Application.Validations.Capitulo
{
    public class PutCapituloValidator : AbstractValidator<PutCapituloDto>
    {
        private readonly IApplicationCapitulo applicationCapitulo;
        private readonly IApplicationProgresso applicationProgresso;

        public PutCapituloValidator(IApplicationCapitulo applicationCapitulo, IApplicationProgresso applicationProgresso)
        {
            this.applicationProgresso = applicationProgresso;
            this.applicationCapitulo = applicationCapitulo;

            RuleFor(x => x.Id)
              .NotNull()
              .WithMessage("O id não pode ser nulo.")

              .NotEmpty()
              .WithMessage("O id não pode ser vazio.")

              .MustAsync(async (Id, cancelar) =>
              {
                  return await ExisteNaBaseAsync(Id);
              }).WithMessage("Capítulo não cadastrado.");

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

        private async Task<bool> ExisteNaBaseAsync(long? id)
        {
            return await applicationCapitulo.ExisteNaBaseAsync(id);
        }
    }
}

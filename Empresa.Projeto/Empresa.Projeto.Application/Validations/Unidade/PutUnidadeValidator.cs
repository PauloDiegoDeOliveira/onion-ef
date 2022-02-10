using Empresa.Projeto.Application.Dtos.Unidade;
using Empresa.Projeto.Application.Interfaces;
using Empresa.Projeto.Application.Validations.Capitulo;
using FluentValidation;
using System.Threading.Tasks;

namespace Empresa.Projeto.Application.Validations.Unidade
{
    public class PutUnidadeValidator : AbstractValidator<PutUnidadeDto>
    {
        private readonly IApplicationCapitulo applicationCapitulo;
        private readonly IApplicationUnidade applicationUnidade;

        public PutUnidadeValidator(IApplicationUnidade applicationUnidade, IApplicationCapitulo applicationCapitulo)
        {
            this.applicationCapitulo = applicationCapitulo;
            this.applicationUnidade = applicationUnidade;

            RuleFor(x => x.Id)
                .NotNull()
                .WithMessage("O id não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O id não pode ser vazio.")

                .MustAsync(async (Id, cancelar) =>
                {
                    return await ExisteNaBaseAsync(Id);
                }).WithMessage("Unidade não cadastrada.");

            RuleFor(x => x.Capitulos)
                 .NotNull()
                 .WithMessage("O id de capítulo não pode ser nulo.")

                 .NotEmpty()
                 .WithMessage("O id de capítulo não pode ser vazio.");

            RuleFor(x => x.NumeroUnidade)
                .NotNull()
                .WithMessage("O número da unidade não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O número da unidade não pode ser vazio.");

            RuleFor(x => x.Status)
                .NotNull()
                .WithMessage("O status não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O status não pode ser vazio.");

            RuleForEach(p => p.Capitulos).SetValidator(new ReferenciaCapituloValidator(applicationCapitulo));
        }

        private async Task<bool> ExisteNaBaseAsync(long? id)
        {
            return await applicationUnidade.ExisteNaBaseAsync(id);
        }
    }
}

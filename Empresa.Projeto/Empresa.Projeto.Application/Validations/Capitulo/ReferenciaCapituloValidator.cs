using Empresa.Projeto.Application.Dtos.Capitulo;
using Empresa.Projeto.Application.Interfaces;
using FluentValidation;
using System.Threading.Tasks;

namespace Empresa.Projeto.Application.Validations.Capitulo
{
    public class ReferenciaCapituloValidator : AbstractValidator<ReferenciaCapituloDto>
    {
        private readonly IApplicationCapitulo applicationCapitulo;

        public ReferenciaCapituloValidator(IApplicationCapitulo applicationCapitulo)
        {
            this.applicationCapitulo = applicationCapitulo;

            RuleFor(x => x.Id)
            .MustAsync(async (Id, cancelar) =>
            {
                return await ExisteNaBaseAsync(Id);
            }).WithMessage("Capítulo não cadastrado.");
        }

        private async Task<bool> ExisteNaBaseAsync(long? id)
        {
            return await applicationCapitulo.ExisteNaBaseAsync(id);
        }
    }
}
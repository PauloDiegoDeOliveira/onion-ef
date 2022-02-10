using Empresa.Projeto.Application.Dtos.Progresso;
using Empresa.Projeto.Application.Interfaces;
using FluentValidation;
using System.Threading.Tasks;

namespace Empresa.Projeto.Application.Validations.Progresso
{
    public class ReferenciaProgressoValidator : AbstractValidator<ReferenciaProgressoDto>
    {
        private readonly IApplicationProgresso applicationProgresso;

        public ReferenciaProgressoValidator(IApplicationProgresso applicationProgresso)
        {
            this.applicationProgresso = applicationProgresso;

            RuleFor(x => x.Id)
            .MustAsync(async (Id, cancelar) =>
            {
                return await ExisteNaBaseAsync(Id);
            }).WithMessage("Progresso não cadastrado.");
        }

        private async Task<bool> ExisteNaBaseAsync(long? id)
        {
            return await applicationProgresso.ExisteNaBaseAsync(id);
        }
    }
}
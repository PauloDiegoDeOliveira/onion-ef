using Empresa.Projeto.Application.Dtos.Especialidade;
using Empresa.Projeto.Application.Interfaces;
using FluentValidation;
using System.Threading.Tasks;

namespace Empresa.Projeto.Application.Validations.Especialidade
{
    public class ReferenciaEspecialidadeValidator : AbstractValidator<ReferenciaEspecialidadeDto>
    {
        private readonly IApplicationEspecialidade applicationEspecialidade;

        public ReferenciaEspecialidadeValidator(IApplicationEspecialidade applicationEspecialidade)
        {
            this.applicationEspecialidade = applicationEspecialidade;

            RuleFor(x => x.Id)
                  .NotNull()
                  .WithMessage("O id de especialidade não pode ser nulo.")

                  .NotEmpty()
                  .WithMessage("O id de especialidade não pode ser vazio.")

              .MustAsync(async (id, cancelar) =>
              {
                  return await ExisteNaBaseAsync(id);
              }).WithMessage("Id de especialidade não cadastrado!");
        }

        private async Task<bool> ExisteNaBaseAsync(long? id)
        {
            return await applicationEspecialidade.ExisteNaBaseAsync(id);
        }
    }
}

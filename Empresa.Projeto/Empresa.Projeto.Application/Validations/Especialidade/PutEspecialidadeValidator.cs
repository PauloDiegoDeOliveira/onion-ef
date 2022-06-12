using Empresa.Projeto.Application.Dtos.Especialidade;
using Empresa.Projeto.Application.Interfaces;
using FluentValidation;
using System.Threading.Tasks;

namespace Empresa.Projeto.Application.Validations.Especialidade
{
    public class PutEspecialidadeValidator : AbstractValidator<PutEspecialidadeDto>
    {
        private readonly IApplicationEspecialidade applicationEspecialidade;

        public PutEspecialidadeValidator(IApplicationEspecialidade applicationEspecialidade)
        {
            this.applicationEspecialidade = applicationEspecialidade;

            RuleFor(x => x.Id)
                  .NotNull()
                  .WithMessage("O id de especialidade não pode ser nulo.")

                  .NotEmpty()
                  .WithMessage("O de especialidade não pode ser vazio.")

              .MustAsync(async (id, cancelar) =>
              {
                  return await ExisteNaBaseAsync(id);
              }).WithMessage("Id de especialidade não cadastrado!");

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

        private async Task<bool> ExisteNaBaseAsync(long? id)
        {
            return await applicationEspecialidade.ExisteNaBaseAsync(id);
        }
    }
}

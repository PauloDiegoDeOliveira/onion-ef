using Empresa.Projeto.Application.Dtos.Permissao;
using Empresa.Projeto.Application.Interfaces;
using FluentValidation;
using System.Threading.Tasks;

namespace Empresa.Projeto.Application.Validations.Permissao
{
    public class PutPermissaoValidator : AbstractValidator<PutPermissaoDto>
    {
        private readonly IApplicationPermissao applicationPermissao;

        public PutPermissaoValidator(IApplicationPermissao applicationPermissao)
        {
            this.applicationPermissao = applicationPermissao;

            RuleFor(x => x.Id)
                  .NotNull()
                  .WithMessage("O id da permissão não pode ser nulo.")

                  .NotEmpty()
                  .WithMessage("O id da permissão não pode ser vazio.")

              .MustAsync(async (id, cancelar) =>
              {
                  return await ExisteNaBaseAsync(id);
              }).WithMessage("Id de permissão não cadastrada!");

            RuleFor(x => x.Nome)
                .NotNull()
                .WithMessage("O nome não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O nome não pode ser vazio.")

                .MinimumLength(3)
                .WithMessage("O nome deve ter no mínimo 3 caracteres.")

                .MaximumLength(1000)
                .WithMessage("O nome deve ter no máximo 100 caracteres.");

            RuleFor(x => x.Descricao)
                .NotNull()
                .WithMessage("A descrição não pode ser nula.")

                .NotEmpty()
                .WithMessage("A descrição não pode ser vazia.")

                .MinimumLength(3)
                .WithMessage("A descrição deve ter no mínimo 3 caracteres.")

                .MaximumLength(100)
                .WithMessage("A descrição deve ter no máximo 100 caracteres.");

            RuleFor(x => x.Status)
                .NotNull()
                .WithMessage("O status não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O status não pode ser vazio.");

        }

        private async Task<bool> ExisteNaBaseAsync(long? id)
        {
            return await applicationPermissao.ExisteNaBaseAsync(id);
        }
    }
}
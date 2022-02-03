using Empresa.Projeto.Application.Dtos.Usuario;
using Empresa.Projeto.Application.Interfaces;
using FluentValidation;
using System.Threading.Tasks;

namespace Empresa.Projeto.Application.Validations.Usuario
{
    public class PostUsuarioValidator : AbstractValidator<PostUsuarioDto>
    {
        private readonly IApplicationServicePermissao applicationServicePermissao;

        public PostUsuarioValidator(IApplicationServicePermissao applicationServicePermissao)
        {
            this.applicationServicePermissao = applicationServicePermissao;

            RuleFor(x => x.PermissaoId)
                  .NotNull()
                  .WithMessage("O id da permissão não pode ser nulo.")

                  .NotEmpty()
                  .WithMessage("O id da permissão não pode ser vazio.")

              .MustAsync(async (id, cancelar) =>
              {
                  return await ExisteNaBaseAsync(id);
              }).WithMessage("Permisão não cadastrada!");

            RuleFor(x => x.Nome)
                .NotNull()
                .WithMessage("O nome não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O nome não pode ser vazio.")

                .MinimumLength(3)
                .WithMessage("O nome deve ter no mínimo 3 caracteres.")

                .MaximumLength(1000)
                .WithMessage("O nome deve ter no máximo 100 caracteres.");

            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage("O e-mail informado não é válido.");

            RuleFor(x => x.Status)
                .NotNull()
                .WithMessage("O status não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O status não pode ser vazio.");
        }

        private async Task<bool> ExisteNaBaseAsync(long? id)
        {
            return await applicationServicePermissao.ExisteNaBaseAsync(id);
        }
    }
}
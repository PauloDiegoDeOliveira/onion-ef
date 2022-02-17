using Empresa.Projeto.Application.Dtos.Usuario;
using Empresa.Projeto.Application.Interfaces;
using Empresa.Projeto.Application.Validations.Especialidade;
using FluentValidation;
using System.Threading.Tasks;

namespace Empresa.Projeto.Application.Validations.Usuario
{
    public class PostUsuarioValidator : AbstractValidator<PostUsuarioDto>
    {
        private readonly IApplicationPermissao applicationPermissao;
        private readonly IApplicationEspecialidade applicationEspecialidade;

        public PostUsuarioValidator(IApplicationPermissao applicationPermissao, IApplicationEspecialidade applicationEspecialidade)
        {
            this.applicationPermissao = applicationPermissao;
            this.applicationEspecialidade = applicationEspecialidade;

            RuleFor(x => x.PermissaoId)
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

                .MaximumLength(100)
                .WithMessage("O nome deve ter no máximo 100 caracteres.");

            RuleFor(x => x.Sobrenome)
               .NotNull()
               .WithMessage("O sobrenome não pode ser nulo.")

               .NotEmpty()
               .WithMessage("O sobrenome não pode ser vazio.")

               .MinimumLength(3)
               .WithMessage("O sobrenome deve ter no mínimo 3 caracteres.")

               .MaximumLength(100)
               .WithMessage("O sobrenome deve ter no máximo 100 caracteres.");

            RuleFor(x => x.Apelido)
               .MaximumLength(100)
               .WithMessage("O sobrenome deve ter no máximo 100 caracteres.");

            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage("O e-mail informado não é válido.");

            RuleFor(x => x.Senha)
               .NotNull()
               .WithMessage("A senha não pode ser nulo.")

               .NotEmpty()
               .WithMessage("A senha não pode ser vazio.")

               .MinimumLength(3)
               .WithMessage("A senha deve ter no mínimo 3 caracteres.")

               .MaximumLength(100)
               .WithMessage("A senha deve ter no máximo 100 caracteres.");

            RuleFor(x => x.Status)
                .NotNull()
                .WithMessage("O status não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O status não pode ser vazio.");

            RuleForEach(p => p.Especialidades).SetValidator(new ReferenciaEspecialidadeValidator(applicationEspecialidade));
        }

        private async Task<bool> ExisteNaBaseAsync(long? id)
        {
            return await applicationPermissao.ExisteNaBaseAsync(id);
        }
    }
}
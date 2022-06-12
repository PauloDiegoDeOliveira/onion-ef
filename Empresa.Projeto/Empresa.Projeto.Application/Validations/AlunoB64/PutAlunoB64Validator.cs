using Empresa.Projeto.Application.Dtos.AlunoB64;
using FluentValidation;
using Empresa.Projeto.Application.Interfaces;
using System.Threading.Tasks;

namespace Empresa.Projeto.Application.Validations.AlunoB64
{
    public class PutAlunoB64Validator : AbstractValidator<PutAlunoB64Dto>
    {
        private readonly IApplicationAlunoB64 applicationAlunoB64;
        public PutAlunoB64Validator(IApplicationAlunoB64 applicationAlunoB64)
        {
            this.applicationAlunoB64 = applicationAlunoB64;

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

            RuleFor(x => x.ImagemEmBase64)
                .NotNull()
                .WithMessage("A imagem não pode ser nula.")

                .NotEmpty()
                .WithMessage("A imagem não pode ser vazio.");
        }

        private async Task<bool> ExisteNaBaseAsync(long? id)
        {
            return await applicationAlunoB64.ExisteNaBaseAsync(id);
        }
    }
}

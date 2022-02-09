using Empresa.Projeto.Application.Dtos.UploadB64;
using FluentValidation;
using Empresa.Projeto.Application.Interfaces;
using System.Threading.Tasks;

namespace Empresa.Projeto.Application.Validations.UploadB64
{
    public class PutUploadB64Validator : AbstractValidator<PutUploadB64Dto>
    {
        private readonly IApplicationUploadB64 applicationUploadB64;

        public PutUploadB64Validator(IApplicationUploadB64 applicationUploadB64)
        {
            this.applicationUploadB64 = applicationUploadB64;

            RuleFor(x => x.Id)
                  .NotNull()
                  .WithMessage("O id da permissão não pode ser nulo.")

                  .NotEmpty()
                  .WithMessage("O id da permissão não pode ser vazio.")

              .MustAsync(async (id, cancelar) =>
              {
                  return await ExisteNaBaseAsync(id);
              }).WithMessage("Id de permissão não cadastrada!");

            RuleFor(x => x.ImagemEmBase64)
                .NotNull()
                .WithMessage("A imagem não pode ser nula.")

                .NotEmpty()
                .WithMessage("A imagem não pode ser vazio.");
        }

        private async Task<bool> ExisteNaBaseAsync(long? id)
        {
            return await applicationUploadB64.ExisteNaBaseAsync(id);
        }
    }
}

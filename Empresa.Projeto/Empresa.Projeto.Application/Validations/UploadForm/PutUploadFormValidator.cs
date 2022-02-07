using Empresa.Projeto.Application.Dtos.UploadForm;
using Empresa.Projeto.Application.Interfaces;
using FluentValidation;
using System.Threading.Tasks;

namespace Empresa.Projeto.Application.Validations.UploadForm
{
    public class PutUploadFormValidator : AbstractValidator<PutUploadFormDto>
    {
        private readonly IApplicationUploadForm applicationUploadForm;

        public PutUploadFormValidator(IApplicationUploadForm applicationUploadForm)
        {
            this.applicationUploadForm = applicationUploadForm;

            RuleFor(x => x.Id)
                  .NotNull()
                  .WithMessage("O id da imagem não pode ser nulo.")

                  .NotEmpty()
                  .WithMessage("O id da imagem não pode ser vazio.")

              .MustAsync(async (id, cancelar) =>
              {
                  return await ExisteNaBaseAsync(id);
              }).WithMessage("Id de imagem não cadastrada!");

            RuleFor(x => x.ImagemUpload)
                .NotNull()
                .WithMessage("A Imagem não pode ser nulo.")

                .NotEmpty()
                .WithMessage("A Imagem não pode ser vazio.");
        }

        private async Task<bool> ExisteNaBaseAsync(long? id)
        {
            return await applicationUploadForm.ExisteNaBaseAsync(id);
        }
    }
}
using Empresa.Projeto.Application.Dtos.UploadForm;
using FluentValidation;

namespace Empresa.Projeto.Application.Validations.UploadForm
{
    public class PostUploadFormValidator : AbstractValidator<PostUploadFormDto>
    {
        public PostUploadFormValidator()
        {
            RuleFor(x => x.ImagemUpload)
                .NotNull()
                .WithMessage("A imagem não pode ser nulo.")

                .NotEmpty()
                .WithMessage("A imagem não pode ser vazio.");
        }
    }
}
using Empresa.Projeto.Application.Dtos.UploadB64;
using FluentValidation;

namespace Empresa.Projeto.Application.Validations.UploadB64
{
    public class PostUploadB64Validator : AbstractValidator<PostUploadB64Dto>
    {
        public PostUploadB64Validator()
        {
            RuleFor(x => x.ImagemEmBase64)
                .NotNull()
                .WithMessage("A imagem não pode ser nula.")

                .NotEmpty()
                .WithMessage("A imagem não pode ser vazio.");
        }
    }
}

using Empresa.Projeto.Application.Dtos.Progresso;
using Empresa.Projeto.Application.Interfaces;
using FluentValidation;
using System.Threading.Tasks;

namespace Empresa.Projeto.Application.Validations.Progresso
{
    public class PutProgressoValidator : AbstractValidator<PutProgressoDto>
    {
        private readonly IApplicationProgresso applicationProgresso;
        public PutProgressoValidator(IApplicationProgresso applicationProgresso)
        {
            this.applicationProgresso = applicationProgresso;

            RuleFor(x => x.Id)
                 .NotNull()
                 .WithMessage("O id de progresso não pode ser nulo.")

                 .NotEmpty()
                 .WithMessage("O id de progresso não pode ser vazio.")

                .MustAsync(async (Id, cancelar) =>
                {
                    return await ExisteNaBaseAsync(Id);
                }).WithMessage("Progresso não cadastrada");

            RuleFor(x => x.TotalProgresso)
                 .NotNull()
                 .WithMessage("O número do progresso não pode ser nulo.")

                 .NotEmpty()
                 .WithMessage("O número do progresso não pode ser vazio.")

                 .GreaterThanOrEqualTo(0)
                 .WithMessage("O número do progresso não pode ser menor que zero (0).")

                 .LessThanOrEqualTo(100)
                 .WithMessage("O número do progressoa não pode ser maior que cem (100).");

            RuleFor(x => x.Status)
                .NotNull()
                .WithMessage("O status não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O status não pode ser vazio.");
        }

        private async Task<bool> ExisteNaBaseAsync(int FuncaoId)
        {
            return await applicationProgresso.ExisteNaBaseAsync(FuncaoId);
        }
    }
}

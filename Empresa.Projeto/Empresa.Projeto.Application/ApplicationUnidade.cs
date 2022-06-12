using AutoMapper;
using Empresa.Projeto.Application.Adaptatives;
using Empresa.Projeto.Application.Dtos.Unidade;
using Empresa.Projeto.Application.Interfaces;
using Empresa.Projeto.Domain.Core.Interfaces.Services;
using Empresa.Projeto.Domain.Entitys;
using System.Threading.Tasks;

namespace Empresa.Projeto.Application
{
    public class ApplicationUnidade :
        ApplicationBase<Unidade, ViewUnidadeDto, PostUnidadeDto, PutUnidadeDto>,
        IApplicationUnidade
    {
        private readonly IServiceUnidade serviceUnidade;

        public ApplicationUnidade(IServiceUnidade serviceUnidade,
                                         IMapper mapper) : base(serviceUnidade, mapper)
        {
            this.serviceUnidade = serviceUnidade;
        }

        public async Task<UnidadeAdaptative> GetByIdDetalhesAdaptativeAsync(long id)
        {
            Unidade consulta = await serviceUnidade.GetByIdDetalhesAsync(id);

            if (consulta is null)
                return null;

            UnidadeAdaptative unidadeAdaptative = new UnidadeAdaptative();
            unidadeAdaptative.Construtor(mapper.Map<ViewUnidadeDto>(consulta));

            return unidadeAdaptative;
        }
    }
}

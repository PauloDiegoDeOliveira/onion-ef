using AutoMapper;
using Empresa.Projeto.Application.Adaptatives;
using Empresa.Projeto.Application.Dtos.Capitulo;
using Empresa.Projeto.Application.Interfaces;
using Empresa.Projeto.Domain.Core.Interfaces.Services;
using Empresa.Projeto.Domain.Entitys;
using System.Threading.Tasks;

namespace Empresa.Projeto.Application
{
    public class ApplicationCapitulo :
        ApplicationBase<Capitulo, ViewCapituloDto, PostCapituloDto, PutCapituloDto>,
        IApplicationCapitulo
    {
        private readonly IServiceCapitulo serviceCapitulo;

        public ApplicationCapitulo(IServiceCapitulo serviceCapitulo,
                                         IMapper mapper) : base(serviceCapitulo, mapper)
        {
            this.serviceCapitulo = serviceCapitulo;
        }

        public async Task<CapituloAdaptative> GetByIdDetalhesAdaptativeAsync(long id)
        {
            Capitulo consulta = await serviceCapitulo.GetByIdDetalhesAsync(id);

            if (consulta is null)
                return null;

            CapituloAdaptative capituloAdaptative = new CapituloAdaptative();
            capituloAdaptative.Construtor(mapper.Map<ViewCapituloDto>(consulta));

            return capituloAdaptative;
        }
    }
}

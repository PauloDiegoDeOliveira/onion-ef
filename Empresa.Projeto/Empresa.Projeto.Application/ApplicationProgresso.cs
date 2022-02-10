using AutoMapper;
using Empresa.Projeto.Application.Dtos.Progresso;
using Empresa.Projeto.Application.Interfaces;
using Empresa.Projeto.Domain.Core.Interfaces.Services;
using Empresa.Projeto.Domain.Entitys;

namespace Empresa.Projeto.Application
{
    public class ApplicationProgresso :
        ApplicationBase<Progresso, ViewProgressoDto, PostProgressoDto, PutProgressoDto>,
        IApplicationProgresso
    {
        private readonly IServiceProgresso serviceProgresso;

        public ApplicationProgresso(IServiceProgresso serviceProgresso,
                                         IMapper mapper) : base(serviceProgresso, mapper)
        {
            this.serviceProgresso = serviceProgresso;
        }
    }
}

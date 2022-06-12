using AutoMapper;
using Empresa.Projeto.Application.Dtos.Especialidade;
using Empresa.Projeto.Application.Interfaces;
using Empresa.Projeto.Domain.Core.Interfaces.Services;
using Empresa.Projeto.Domain.Entitys;

namespace Empresa.Projeto.Application
{
    public class ApplicationEspecialidade :
        ApplicationBase<Especialidade, ViewEspecialidadeDto, PostEspecialidadeDto, PutEspecialidadeDto>,
        IApplicationEspecialidade
    {
        private readonly IServiceEspecialidade serviceEspecialidade;

        public ApplicationEspecialidade(IServiceEspecialidade serviceEspecialidade,
                                         IMapper mapper) : base(serviceEspecialidade, mapper)
        {
            this.serviceEspecialidade = serviceEspecialidade;
        }
    }
}
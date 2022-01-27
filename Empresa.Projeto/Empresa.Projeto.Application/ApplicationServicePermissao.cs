using AutoMapper;
using Empresa.Projeto.Application.Dtos.Permissao;
using Empresa.Projeto.Application.Interfaces;
using Empresa.Projeto.Domain.Core.Interfaces.Services;
using Empresa.Projeto.Domain.Entitys;
using Empresa.Projeto.Domain.Enums;
using System;
using System.Threading.Tasks;

namespace Empresa.Projeto.Application
{
    public class ApplicationServicePermissao: 
        ApplicationServiceBase<Permissao, ViewPermissaoDto, PostPermissaoDto, PutPermissaoDto>,
        IApplicationServicePermissao
    {
        private readonly IServicePermissao servicePermissao;


        public ApplicationServicePermissao(IServicePermissao servicePermissao,
                                         IMapper mapper) : base(servicePermissao, mapper)
        {
            this.servicePermissao = servicePermissao;
        }

        public async Task<ViewPermissaoDto> PutStatusAsync(long id)
        {
            Permissao consulta = await servicePermissao.GetByIdUsuarioAsync(id);
            if (consulta is null)
            {
                return null;
            }

            consulta.ChangeStatusValue((int)Status.Excluido);
            consulta.ChangeAlteradoEmValue(DateTime.Now);

            Permissao obj = await servicePermissao.PutStatusAsync(consulta);
            return mapper.Map<ViewPermissaoDto>(obj);
        }
    }
}

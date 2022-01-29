using AutoMapper;
using Empresa.Projeto.Application.Dtos.Permissao;
using Empresa.Projeto.Application.Interfaces;
using Empresa.Projeto.Application.Structs;
using Empresa.Projeto.Domain.Core.Interfaces.Services;
using Empresa.Projeto.Domain.Entitys;
using Empresa.Projeto.Domain.Enums;
using System;
using System.Threading.Tasks;

namespace Empresa.Projeto.Application
{
    public class ApplicationServicePermissao :
        ApplicationServiceBase<Permissao, ViewPermissaoDto, PostPermissaoDto, PutPermissaoDto>,
        IApplicationServicePermissao
    {
        private readonly IServicePermissao servicePermissao;

        public ApplicationServicePermissao(IServicePermissao servicePermissao,
                                         IMapper mapper) : base(servicePermissao, mapper)
        {
            this.servicePermissao = servicePermissao;
        }

        public async Task<ViewPermissaoDto> PutStatusAsync(long id, Status status)
        {
            Permissao consulta = await servicePermissao.GetByIdPermissaoAsync(id);
            if (consulta is null)
            {
                return null;
            }

            consulta.ChangeStatusValue((int)status);
            consulta.ChangeAlteradoEmValue(DateTime.Now);

            Permissao obj = await servicePermissao.PutStatusAsync(consulta);
            return mapper.Map<ViewPermissaoDto>(obj);
        }

        public async Task<EntityDtoStruct<Permissao, PutPermissaoDto>> GetByIdReturnPutAsync(long id)
        {
            EntityDtoStruct<Permissao,PutPermissaoDto> objetoPermissao = new EntityDtoStruct<Permissao, PutPermissaoDto>();
            objetoPermissao.ChangeEntity(await servicePermissao.GetByIdPermissaoAsync(id));
            objetoPermissao.ChantePutDto(mapper.Map<PutPermissaoDto>(objetoPermissao.entity));
            return objetoPermissao;
        }

        public async Task SaveChangesAsync(EntityDtoStruct<Permissao,PutPermissaoDto> dtoStruct)
        {
            mapper.Map(dtoStruct.dto, dtoStruct.entity);
            await servicePermissao.SaveChangesAsync();
        }

        public async Task<ViewPermissaoUsuarioDto> GetByIdDetalhesAsync(long id)
        {
            Permissao consulta = await servicePermissao.GetByIdDetalhesAsync(id);
            return mapper.Map<ViewPermissaoUsuarioDto>(consulta);
        }
    }
}
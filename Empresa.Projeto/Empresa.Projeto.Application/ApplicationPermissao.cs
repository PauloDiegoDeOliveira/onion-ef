using AutoMapper;
using Empresa.Projeto.Application.Dtos.Paginacao;
using Empresa.Projeto.Application.Dtos.Permissao;
using Empresa.Projeto.Application.Interfaces;
using Empresa.Projeto.Application.Structs;
using Empresa.Projeto.Domain.Core.Interfaces.Services;
using Empresa.Projeto.Domain.Entitys;
using Empresa.Projeto.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Empresa.Projeto.Application
{
    public class ApplicationPermissao :
        ApplicationBase<Permissao, ViewPermissaoDto, PostPermissaoDto, PutPermissaoDto>,
        IApplicationPermissao
    {
        private readonly IServicePermissao servicePermissao;

        public ApplicationPermissao(IServicePermissao servicePermissao,
                                         IMapper mapper) : base(servicePermissao, mapper)
        {
            this.servicePermissao = servicePermissao;
        }

        public async Task<PermissaoPagination> GetAllPaginationAsync(int pageNumber, int resultSize)
        {
            PermissaoPagination pagination = new PermissaoPagination();
            pagination.SetValues(await servicePermissao.GetCountAsync(), resultSize, pageNumber);
            pagination.Permissoes = mapper.Map<List<ViewPermissaoDto>>(await servicePermissao.GetAllPaginationAsync(pagination.PaginaAtual, pagination.ResultadosExibidos));
            return pagination;
        }

        public async Task<ViewPermissaoUsuarioDto> GetByIdDetalhesAsync(long id)
        {
            Permissao consulta = await servicePermissao.GetByIdDetalhesAsync(id);
            return mapper.Map<ViewPermissaoUsuarioDto>(consulta);
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
            EntityDtoStruct<Permissao, PutPermissaoDto> objetoPermissao = new EntityDtoStruct<Permissao, PutPermissaoDto>();
            objetoPermissao.ChangeEntity(await servicePermissao.GetByIdPermissaoAsync(id));
            objetoPermissao.ChangeDto(mapper.Map<PutPermissaoDto>(objetoPermissao.Entity));
            return objetoPermissao;
        }

        public async Task SaveChangesAsync(EntityDtoStruct<Permissao, PutPermissaoDto> dtoStruct)
        {
            mapper.Map(dtoStruct.Dto, dtoStruct.Entity);
            await servicePermissao.SaveChangesAsync();
        }

        public async Task<bool> ExisteNaBaseAsync(long? id)
        {
            return await servicePermissao.ExisteNaBaseAsync(id);
        }
    }
}
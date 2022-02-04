using AutoMapper;
using Empresa.Projeto.Application.Dtos.Paginacao;
using Empresa.Projeto.Application.Dtos.Permissao;
using Empresa.Projeto.Application.Interfaces;
using Empresa.Projeto.Application.Structs;
using Empresa.Projeto.Domain.Core.Interfaces.Services;
using Empresa.Projeto.Domain.Entitys;
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

        public async Task<PermissaoPagination> GetPaginationAsync(int pageNumber, int resultSize)
        {
            PermissaoPagination pagination = new PermissaoPagination();
            pagination.SetValues(await servicePermissao.GetCountAsync(), resultSize, pageNumber);
            pagination.Permissoes = mapper.Map<List<ViewPermissaoDto>>(await servicePermissao.GetPaginationAsync(pagination.PaginaAtual, pagination.ResultadosExibidos));
            return pagination;
        }

        public async Task<ViewPermissaoUsuarioDto> GetByIdDetalhesAsync(long id)
        {
            Permissao consulta = await servicePermissao.GetByIdDetalhesAsync(id);
            return mapper.Map<ViewPermissaoUsuarioDto>(consulta);
        }

        public async Task<EntityDtoStruct<Permissao, PutPermissaoDto>> GetByIdReturnStructDtoAsync(long id)
        {
            EntityDtoStruct<Permissao, PutPermissaoDto> objetoPermissao = new EntityDtoStruct<Permissao, PutPermissaoDto>();
            objetoPermissao.ChangeEntity(await servicePermissao.GetByIdAsync(id));
            objetoPermissao.ChangeDto(mapper.Map<PutPermissaoDto>(objetoPermissao.Entity));
            return objetoPermissao;
        }

        public async Task SaveChangesAsync(EntityDtoStruct<Permissao, PutPermissaoDto> dtoStruct)
        {
            mapper.Map(dtoStruct.Dto, dtoStruct.Entity);
            await servicePermissao.SaveChangesAsync();
        }
    }
}
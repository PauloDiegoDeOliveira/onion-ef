﻿using Empresa.Projeto.Domain.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Empresa.Projeto.Domain.Core.Interfaces.Services
{
    public interface IServicePermissao : IServiceBase<Permissao>
    {
        Task<IEnumerable<Permissao>> GetAllPaginationAsync(int pageNumber, int resultSize);

        Task<Permissao> GetByIdPermissaoAsync(long id);

        Task<Permissao> GetByIdDetalhesAsync(long id);

        Task<Permissao> PutStatusAsync(Permissao permissao);

        Task<int> GetCountAsync();

        Task SaveChangesAsync();

        Task<bool> ExisteNaBaseAsync(long? id);
    }
}
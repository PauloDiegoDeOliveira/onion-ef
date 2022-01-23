using System.Collections.Generic;
using System.Threading.Tasks;

namespace Empresa.Projeto.Domain.Core.Interfaces.Repositorys
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {        
        Task<IEnumerable<TEntity>> GetAllAsync();      
    }
}
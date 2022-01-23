using System.Collections.Generic;
using System.Threading.Tasks;

namespace Empresa.Projeto.Domain.Core.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {       
        Task<IEnumerable<TEntity>> GetAllAsync();      
    }
}
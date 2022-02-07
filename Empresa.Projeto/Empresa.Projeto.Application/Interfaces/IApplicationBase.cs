using Empresa.Projeto.Domain.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Empresa.Projeto.Application.Interfaces
{
    public interface IApplicationBase<TView, TPost, TPut>
        where TView : class where TPost : class where TPut : class
    {
        Task<IEnumerable<TView>> GetAllAsync();

        Task<TView> GetByIdAsync(long id);

        Task<TView> PostAsync(TPost post);

        Task<TView> PutAsync(TPut put);

        Task<TView> DeleteAsync(long id);

        Task<TView> PutStatusAsync(long id, Status status);

        Task<bool> ExisteNaBaseAsync(long? id);
    }
}
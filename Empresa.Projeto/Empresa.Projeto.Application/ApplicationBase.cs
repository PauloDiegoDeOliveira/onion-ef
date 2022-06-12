using AutoMapper;
using Empresa.Projeto.Application.Interfaces;
using Empresa.Projeto.Domain.Core.Interfaces.Services;
using Empresa.Projeto.Domain.Entitys;
using Empresa.Projeto.Domain.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Empresa.Projeto.Application
{
    public class ApplicationBase<TEntity, TView, TPost, TPut> :
        IApplicationBase<TView, TPost, TPut>
        where TEntity : EntityBase where TView : class where TPost : class where TPut : class
    {
        protected readonly IMapper mapper;
        protected readonly IServiceBase<TEntity> serviceBase;

        public ApplicationBase(IServiceBase<TEntity> serviceBase, IMapper mapper)
        {
            this.serviceBase = serviceBase;
            this.mapper = mapper;
        }

        public virtual async Task<IEnumerable<TView>> GetAllAsync()
        {
            IEnumerable<TEntity> consulta = await serviceBase.GetAllAsync();
            return mapper.Map<IList<TView>>(consulta);
        }

        public virtual async Task<TView> GetByIdAsync(long id)
        {
            TEntity consulta = await serviceBase.GetByIdAsync(id);
            return mapper.Map<TView>(consulta);
        }

        public virtual async Task<TView> PostAsync(TPost obj)
        {
            TEntity consulta = mapper.Map<TEntity>(obj);
            consulta = await serviceBase.PostAsync(consulta);
            return mapper.Map<TView>(consulta);
        }

        public virtual async Task<TView> PutAsync(TPut obj)
        {
            TEntity consulta = mapper.Map<TEntity>(obj);
            consulta = await serviceBase.PutAsync(consulta);
            return mapper.Map<TView>(consulta);
        }

        public virtual async Task<TView> DeleteAsync(long id)
        {
            TEntity consulta = await serviceBase.DeleteAsync(id);
            return mapper.Map<TView>(consulta);
        }

        public async Task<TView> PutStatusAsync(long id, Status status)
        {
            TEntity consulta = await serviceBase.GetByIdAsync(id);
            if (consulta is null)
            {
                return null;
            }

            consulta.ChangeStatusValue((int)status);

            TEntity obj = await serviceBase.PutStatusAsync(consulta);
            return mapper.Map<TView>(obj);
        }

        public virtual async Task<bool> ExisteNaBaseAsync(long? id)
        {
            return await serviceBase.ExisteNaBaseAsync(id);
        }
    }
}
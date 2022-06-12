using Empresa.Projeto.Domain.Entitys;

namespace Empresa.Projeto.Application.Structs
{
    public struct EntityDtoStruct<TEntity, TDto> where TEntity : EntityBase where TDto : class
    {
        public TEntity Entity { get; private set; }
        public TDto Dto { get; private set; }

        public EntityDtoStruct(TEntity entity, TDto dto)
        {
            Entity = entity;
            Dto = dto;
        }
    }
}
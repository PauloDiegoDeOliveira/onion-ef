using Empresa.Projeto.Domain.Entitys;

namespace Empresa.Projeto.Application.Structs
{
    public struct EntityDtoStruct<TEntity, TDto> where TEntity : EntityBase where TDto : class
    {
        public TEntity Entity { get; private set; }
        public TDto Dto { get; private set; }

        public void ChangeEntity(TEntity entity)
        {
            this.Entity = entity;
        }

        public void ChangeDto(TDto dto)
        {
            this.Dto = dto;
        }
    }
}
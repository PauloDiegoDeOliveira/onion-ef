using Empresa.Projeto.Domain.Entitys;

namespace Empresa.Projeto.Application.Structs
{
    public struct EntityDtoStruct<TEntity, TDto> where TEntity : EntityBase where TDto : class
    {
        public TEntity entity { get; private set; }
        public TDto dto { get; private set; }

        public void ChangeEntity(TEntity entity)
        {
            this.entity = entity;
        }

        public void ChantePutDto(TDto dto)
        {
            this.dto = dto;
        }
    }
}

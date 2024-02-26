using ParkingLot.Server.Models;

namespace ParkingLot.Server.Dtos
{
    public abstract class EntityDto<TEntity>
    {
        public int? Id { get; set; }

        public EntityDto()
        {
        }

        public EntityDto(TEntity entity)
        {
            FromEntity(entity);
        }

        public abstract void FromEntity(TEntity entity);
        public abstract TEntity ToEntity();
    }
}

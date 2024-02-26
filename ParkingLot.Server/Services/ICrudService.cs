using ParkingLot.Server.Dtos;
using ParkingLot.Server.Models;

namespace ParkingLot.Server.Repositories
{
    public interface ICrudService<TEntity, TDto>
        where TEntity : Entity, new()
        where TDto : EntityDto<TEntity>, new()
    {
        public TDto? Find(int id);
        public int? Create(TDto vehicleType);
        public bool Update(TDto vehicleType);
        public bool Delete(int id);
    }
}

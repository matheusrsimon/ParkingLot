using ParkingLot.Server.Models;

namespace ParkingLot.Server.Repositories
{
    public interface IRepository<TEntity>
        where TEntity : Entity, new()
    {
        public TEntity? Find(int id);
        public IEnumerable<TEntity> Filter(Func<TEntity, bool>? predicate = null);
        public int? Create(TEntity vehicleType);
        public bool Update(TEntity vehicleType);
        public bool Delete(int id);
    }
}

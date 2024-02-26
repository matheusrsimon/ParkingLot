using Microsoft.EntityFrameworkCore;
using ParkingLot.Server.Data;
using ParkingLot.Server.Models;

namespace ParkingLot.Server.Repositories
{
    public interface IVehicleTypeRepository : IRepository<VehicleType>
    {
    }

    public class VehicleTypeRepository : Repository<VehicleType>, IVehicleTypeRepository
    {
        protected override DbSet<VehicleType> Set { get => base.context.VehicleTypes; }

        public VehicleTypeRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public override VehicleType? UpdateValues(VehicleType input, VehicleType? entity)
        {
            if (entity != null)
            {
                entity.Name = input.Name ?? entity.Name;
                entity.SizeId = input.SizeId != 0 ? input.SizeId : entity.SizeId;
            }
            return entity;
        }
    }
}

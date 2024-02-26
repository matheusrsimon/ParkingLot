using Microsoft.EntityFrameworkCore;
using ParkingLot.Server.Data;
using ParkingLot.Server.Models;

namespace ParkingLot.Server.Repositories
{
    public interface IVehicleRepository : IRepository<Vehicle>
    {
    }

    public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        protected override DbSet<Vehicle> Set { get => base.context.Vehicles; }

        public VehicleRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public override Vehicle? UpdateValues(Vehicle input, Vehicle? entity)
        {
            if (entity != null)
            {
                entity.Plate = input.Plate ?? entity.Plate;
                entity.TypeId = input.TypeId != 0 ? input.TypeId : entity.TypeId;
                entity.SectionId = input.SectionId != 0 ? input.SectionId : entity.SectionId;
            }
            return entity;
        }
    }
}

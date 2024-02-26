using Microsoft.EntityFrameworkCore;
using ParkingLot.Server.Data;
using ParkingLot.Server.Models;

namespace ParkingLot.Server.Repositories
{
    public interface ISpotSizeUsageRepository : IRepository<SpotSizeUsage>
    {
    }

    public class SpotSizeUsageRepository : Repository<SpotSizeUsage>, ISpotSizeUsageRepository
    {
        protected override DbSet<SpotSizeUsage> Set { get => base.context.SpotSizeUsages; }

        public SpotSizeUsageRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public override SpotSizeUsage? UpdateValues(SpotSizeUsage input, SpotSizeUsage? entity)
        {
            if (entity != null)
            {
                entity.Usage = input.Usage != 0 ? input.Usage : entity.Usage;
                entity.VehicleSizeId = input.VehicleSizeId != 0 ? input.VehicleSizeId : entity.VehicleSizeId;
                entity.SpotSizeId = input.SpotSizeId != 0 ? input.SpotSizeId : entity.SpotSizeId;
            }
            return entity;
        }
    }
}

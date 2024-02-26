using Microsoft.EntityFrameworkCore;
using ParkingLot.Server.Data;
using ParkingLot.Server.Models;

namespace ParkingLot.Server.Repositories
{
    public interface ISpotSizeRepository : IRepository<SpotSize>
    {
    }

    public class SpotSizeRepository : Repository<SpotSize>, ISpotSizeRepository
    {
        protected override DbSet<SpotSize> Set { get => base.context.SpotSizes; }

        public SpotSizeRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public override SpotSize? UpdateValues(SpotSize input, SpotSize? entity)
        {
            if (entity != null)
            {
                entity.Name = input.Name ?? entity.Name;
            }
            return entity;
        }
    }
}

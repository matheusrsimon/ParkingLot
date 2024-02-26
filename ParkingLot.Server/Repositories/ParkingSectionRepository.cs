using Microsoft.EntityFrameworkCore;
using ParkingLot.Server.Data;
using ParkingLot.Server.Models;
using System.Linq;

namespace ParkingLot.Server.Repositories
{
    public interface IParkingSectionRepository : IRepository<ParkingSection>
    {
    }

    public class ParkingSectionRepository : Repository<ParkingSection>, IParkingSectionRepository
    {
        protected override DbSet<ParkingSection> Set { get => base.context.ParkingSections; }

        public ParkingSectionRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public override ParkingSection? UpdateValues(ParkingSection input, ParkingSection? entity)
        {
            if (entity != null)
            {
                entity.Count = input.Count != 0 ? input.Count : entity.Count;
                entity.SizeId = input.SizeId != 0 ? input.SizeId : entity.SizeId;
            }
            return entity;
        }
    }
}

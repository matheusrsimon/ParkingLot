using ParkingLot.Server.Dtos;
using ParkingLot.Server.Models;
using ParkingLot.Server.Repositories;

namespace ParkingLot.Server.Services
{
    public interface IParkingSectionService : ICrudService<ParkingSection, ParkingSectionDto>
    {
        public IEnumerable<ParkingSectionDto> Filter(int? sizeId = null, int? count = null);
    }

    public class ParkingSectionService : CrudService<ParkingSection, ParkingSectionDto, IParkingSectionRepository>, IParkingSectionService
    {
        public ParkingSectionService(IParkingSectionRepository repository)
            : base(repository)
        {
        }

        public IEnumerable<ParkingSectionDto> Filter(int? sizeId = null, int? count = null)
        {
            return base.Filter(x => (sizeId == null || x.SizeId == sizeId) && (count == null || x.Count == count));
        }
    }
}

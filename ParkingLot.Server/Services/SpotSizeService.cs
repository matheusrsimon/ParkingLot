using ParkingLot.Server.Dtos;
using ParkingLot.Server.Models;
using ParkingLot.Server.Repositories;

namespace ParkingLot.Server.Services
{
    public interface ISpotSizeService : ICrudService<SpotSize, SpotSizeDto>
    {
        public IEnumerable<SpotSizeDto> Filter(string? name = null);
    }

    public class SpotSizeService : CrudService<SpotSize, SpotSizeDto, ISpotSizeRepository>, ISpotSizeService
    {
        public SpotSizeService(ISpotSizeRepository repository)
            : base(repository)
        {
        }

        public IEnumerable<SpotSizeDto> Filter(string? name = null)
        {
            return base.Filter(x => (name == null || x.Name.ToLower().Contains(name)));
        }
    }
}

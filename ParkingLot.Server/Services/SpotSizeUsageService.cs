using ParkingLot.Server.Dtos;
using ParkingLot.Server.Models;
using ParkingLot.Server.Repositories;
using static System.Collections.Specialized.BitVector32;

namespace ParkingLot.Server.Services
{
    public interface ISpotSizeUsageService : ICrudService<SpotSizeUsage, SpotSizeUsageDto>
    {
        public IEnumerable<SpotSizeUsageDto> Filter(int? usage = null, int? vehicleSizeId = null, int? spotSizeId = null);
    }

    public class SpotSizeUsageService : CrudService<SpotSizeUsage, SpotSizeUsageDto, ISpotSizeUsageRepository>, ISpotSizeUsageService
    {
        public SpotSizeUsageService(ISpotSizeUsageRepository repository)
            : base(repository)
        {
        }

        public IEnumerable<SpotSizeUsageDto> Filter(int? usage = null, int? vehicleSizeId = null, int? spotSizeId = null)
        {
            return base.Filter(x => (usage == null || x.Usage == usage) && (vehicleSizeId == null || x.VehicleSizeId == vehicleSizeId) && (spotSizeId == null || x.SpotSizeId == spotSizeId));
        }
    }
}

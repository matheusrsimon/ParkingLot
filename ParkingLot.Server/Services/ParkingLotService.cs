using ParkingLot.Server.Dtos;
using ParkingLot.Server.Models;
using ParkingLot.Server.Repositories;

namespace ParkingLot.Server.Services
{
    public interface IParkingLotService
    {
        public ParkingLotDto Get();
    }

    public class ParkingLotService : IParkingLotService
    {
        private readonly IParkingSectionRepository parkingSectionRepository;
        private readonly ISpotSizeRepository spotSizeRepository;
        private readonly ISpotSizeUsageRepository spotSizeUsageRepository;
        private readonly IVehicleRepository vehicleRepository;

        public ParkingLotService(IParkingSectionRepository parkingSectionRepository, ISpotSizeRepository spotSizeRepository, ISpotSizeUsageRepository spotSizeUsageRepository, IVehicleRepository vehicleRepository)
        {
            this.parkingSectionRepository = parkingSectionRepository;
            this.spotSizeRepository = spotSizeRepository;
            this.spotSizeUsageRepository = spotSizeUsageRepository;
            this.vehicleRepository = vehicleRepository;
        }

        public ParkingLotDto Get()
        {
            ParkingLotDto result = new ParkingLotDto();

            result.Sections = parkingSectionRepository.Filter().Select(section =>
            {
                section.Vehicles = vehicleRepository.Filter(s => s.SectionId == section.Id).Select(s =>
                {
                    s.Section = null;
                    return s;
                }).ToList();
                return new ParkingSectionDto(section);
            });

            result.Sizes = spotSizeRepository.Filter().Select(size =>
            {
                Func<SpotSizeUsage, SpotSizeUsage> flattener = s =>
                {
                    s.SpotSize = null;
                    s.VehicleSize = null;
                    return s;
                };
                size.SpotUsage = spotSizeUsageRepository.Filter(s => s.SpotSizeId == size.Id).Select(flattener).ToList();
                size.VehicleUsage = spotSizeUsageRepository.Filter(s => s.VehicleSizeId == size.Id).Select(flattener).ToList();
                return new SpotSizeDto(size);
            });

            return result;
        }
    }
}

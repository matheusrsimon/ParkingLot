using ParkingLot.Server.Dtos;
using ParkingLot.Server.Models;
using ParkingLot.Server.Repositories;

namespace ParkingLot.Server.Services
{
    public interface IVehicleService : ICrudService<Vehicle, VehicleDto>
    {
        public IEnumerable<VehicleDto> Filter(int? typeId = null, int? sectionId = null, string? plate = null);
    }

    public class VehicleService : CrudService<Vehicle, VehicleDto, IVehicleRepository>, IVehicleService
    {
        public VehicleService(IVehicleRepository repository)
            : base(repository)
        {
        }

        public IEnumerable<VehicleDto> Filter(int? typeId = null, int? sectionId = null, string? plate = null)
        {
            return base.Filter(x => (typeId == null || x.TypeId == typeId) && (sectionId == null || x.SectionId == sectionId) && (plate == null || x.Plate.ToLower().Contains(plate)));
        }
    }
}

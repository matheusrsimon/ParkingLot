using ParkingLot.Server.Dtos;
using ParkingLot.Server.Models;
using ParkingLot.Server.Repositories;

namespace ParkingLot.Server.Services
{
    public interface IVehicleTypeService : ICrudService<VehicleType, VehicleTypeDto>
    {
        public IEnumerable<VehicleTypeDto> Filter(int? sizeId = null, string? name = null);
    }

    public class VehicleTypeService : CrudService<VehicleType, VehicleTypeDto, IVehicleTypeRepository>, IVehicleTypeService
    {
        public VehicleTypeService(IVehicleTypeRepository repository)
            : base(repository)
        {
        }

        public IEnumerable<VehicleTypeDto> Filter(int? sizeId = null, string? name = null)
        {
            return base.Filter(x => (sizeId == null || x.SizeId == sizeId) && (name == null || x.Name.ToLower().Contains(name)));
        }
    }
}

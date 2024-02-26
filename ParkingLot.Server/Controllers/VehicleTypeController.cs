using Microsoft.AspNetCore.Mvc;
using ParkingLot.Server.Dtos;
using ParkingLot.Server.Models;
using ParkingLot.Server.Services;

namespace ParkingLot.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleTypeController: ControllerBase
    {
        private readonly IVehicleTypeService service;
        private readonly ILogger<VehicleTypeController> logger;

        public VehicleTypeController(IVehicleTypeService service, ILogger<VehicleTypeController> logger)
        {
            this.service = service;
            this.logger = logger;
        }

        [HttpGet("Find")]
        public VehicleTypeDto? Find(int id)
        {
            return service.Find(id);
        }

        [HttpGet("Filter")]
        public IEnumerable<VehicleTypeDto> Filter(int? sizeId, string? name)
        {
            return service.Filter(sizeId, name);
        }

        [HttpPost()]
        public int? Create(VehicleTypeDto vehicleType)
        {
            return service.Create(vehicleType);
        }

        [HttpPut()]
        public bool Update(VehicleTypeDto vehicleType)
        {
            return service.Update(vehicleType);
        }

        [HttpDelete()]
        public bool Delete(int id)
        {
            return service.Delete(id);
        }
    }
}

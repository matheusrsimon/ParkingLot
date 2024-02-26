using Microsoft.AspNetCore.Mvc;
using ParkingLot.Server.Dtos;
using ParkingLot.Server.Models;
using ParkingLot.Server.Services;

namespace ParkingLot.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleController: ControllerBase
    {
        private readonly IVehicleService service;
        private readonly ILogger<VehicleController> logger;

        public VehicleController(IVehicleService service, ILogger<VehicleController> logger)
        {
            this.service = service;
            this.logger = logger;
        }

        [HttpGet("Find")]
        public VehicleDto? Find(int id)
        {
            return service.Find(id);
        }

        [HttpGet("Filter")]
        public IEnumerable<VehicleDto> Filter(int? typeId, int? sectionId, string? plate)
        {
            return service.Filter(typeId, sectionId, plate);
        }

        [HttpPost()]
        public int? Create(VehicleDto Vehicle)
        {
            return service.Create(Vehicle);
        }

        [HttpPut()]
        public bool Update(VehicleDto Vehicle)
        {
            return service.Update(Vehicle);
        }

        [HttpDelete()]
        public bool Delete(int id)
        {
            return service.Delete(id);
        }
    }
}

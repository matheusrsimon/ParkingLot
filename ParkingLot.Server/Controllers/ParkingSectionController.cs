using Microsoft.AspNetCore.Mvc;
using ParkingLot.Server.Dtos;
using ParkingLot.Server.Models;
using ParkingLot.Server.Services;

namespace ParkingLot.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParkingSectionController: ControllerBase
    {
        private readonly IParkingSectionService service;
        private readonly ILogger<ParkingSectionController> logger;

        public ParkingSectionController(IParkingSectionService service, ILogger<ParkingSectionController> logger)
        {
            this.service = service;
            this.logger = logger;
        }

        [HttpGet("Find")]
        public ParkingSectionDto? Find(int id)
        {
            return service.Find(id);
        }

        [HttpGet("Filter")]
        public IEnumerable<ParkingSectionDto> Filter(int? sizeId, int? count)
        {
            return service.Filter(sizeId, count);
        }

        [HttpPost()]
        public int? Create(ParkingSectionDto ParkingSection)
        {
            return service.Create(ParkingSection);
        }

        [HttpPut()]
        public bool Update(ParkingSectionDto ParkingSection)
        {
            return service.Update(ParkingSection);
        }

        [HttpDelete()]
        public bool Delete(int id)
        {
            return service.Delete(id);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using ParkingLot.Server.Dtos;
using ParkingLot.Server.Services;

namespace ParkingLot.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpotSizeController: ControllerBase
    {
        private readonly ISpotSizeService service;
        private readonly ILogger<SpotSizeController> logger;

        public SpotSizeController(ISpotSizeService service, ILogger<SpotSizeController> logger)
        {
            this.service = service;
            this.logger = logger;
        }

        [HttpGet("Find")]
        public SpotSizeDto? Find(int id)
        {
            return service.Find(id);
        }

        [HttpGet("Filter")]
        public IEnumerable<SpotSizeDto> Filter(string? name)
        {
            return service.Filter(name);
        }

        [HttpPost()]
        public int? Create(SpotSizeDto SpotSize)
        {
            return service.Create(SpotSize);
        }

        [HttpPut()]
        public bool Update(SpotSizeDto SpotSize)
        {
            return service.Update(SpotSize);
        }

        [HttpDelete()]
        public bool Delete(int id)
        {
            return service.Delete(id);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using ParkingLot.Server.Dtos;
using ParkingLot.Server.Services;

namespace ParkingLot.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpotSizeUsageController: ControllerBase
    {
        private readonly ISpotSizeUsageService service;
        private readonly ILogger<SpotSizeUsageController> logger;

        public SpotSizeUsageController(ISpotSizeUsageService service, ILogger<SpotSizeUsageController> logger)
        {
            this.service = service;
            this.logger = logger;
        }

        [HttpGet("Find")]
        public SpotSizeUsageDto? Find(int id)
        {
            return service.Find(id);
        }

        [HttpGet("Filter")]
        public IEnumerable<SpotSizeUsageDto> Filter(int? usage, int? vehicleSizeId, int? spotSizeId)
        {
            return service.Filter(usage, vehicleSizeId, spotSizeId);
        }

        [HttpPost()]
        public int? Create(SpotSizeUsageDto SpotSizeUsage)
        {
            return service.Create(SpotSizeUsage);
        }

        [HttpPut()]
        public bool Update(SpotSizeUsageDto SpotSizeUsage)
        {
            return service.Update(SpotSizeUsage);
        }

        [HttpDelete()]
        public bool Delete(int id)
        {
            return service.Delete(id);
        }
    }
}

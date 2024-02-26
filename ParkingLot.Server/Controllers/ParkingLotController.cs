using Microsoft.AspNetCore.Mvc;
using ParkingLot.Server.Dtos;
using ParkingLot.Server.Models;
using ParkingLot.Server.Services;

namespace ParkingLot.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParkingLotController: ControllerBase
    {
        private readonly IParkingLotService service;
        private readonly ILogger<ParkingLotController> logger;

        public ParkingLotController(IParkingLotService service, ILogger<ParkingLotController> logger)
        {
            this.service = service;
            this.logger = logger;
        }

        [HttpGet()]
        public ParkingLotDto Find()
        {
            return service.Get();
        }
    }
}

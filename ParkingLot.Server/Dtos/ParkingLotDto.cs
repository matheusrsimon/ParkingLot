using ParkingLot.Server.Models;

namespace ParkingLot.Server.Dtos
{
    public class ParkingLotDto
    {
        public IEnumerable<ParkingSectionDto>? Sections { get; set; }
        public IEnumerable<SpotSizeDto>? Sizes { get; set; }

        public ParkingLotDto() : base()
        {
        }
    }
}

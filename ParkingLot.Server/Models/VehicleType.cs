using ParkingLot.Server.Core;

namespace ParkingLot.Server.Models
{
    public class VehicleType : Entity
    {
        public string Name { get; set; }

        public int SizeId { get; set; }

        public SpotSize? Size { get; set; }
    }
}

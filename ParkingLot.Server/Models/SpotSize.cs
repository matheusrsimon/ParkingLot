using ParkingLot.Server.Dtos;

namespace ParkingLot.Server.Models
{
    public class SpotSize : Entity
    {
        public string Name { get; set; }

        public IEnumerable<SpotSizeUsage>? VehicleUsage { get; set; }
        public IEnumerable<SpotSizeUsage>? SpotUsage { get; set; }
    }
}

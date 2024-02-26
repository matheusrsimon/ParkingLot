namespace ParkingLot.Server.Models
{
    public class ParkingSection : Entity
    {
        public int Count { get; set; }

        public int SizeId { get; set; }

        public SpotSize? Size { get; set; }
        public IEnumerable<Vehicle>? Vehicles { get; set; }
    }
}

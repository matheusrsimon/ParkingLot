namespace ParkingLot.Server.Models
{
    public class Vehicle : Entity
    {
        public string Plate { get; set; }

        public int TypeId { get; set; }
        public int? SectionId { get; set; }

        public VehicleType? Type { get; set; }
        public ParkingSection? Section { get; set; }
    }
}

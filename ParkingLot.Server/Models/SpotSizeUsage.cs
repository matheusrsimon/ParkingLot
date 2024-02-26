using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingLot.Server.Models
{
    public class SpotSizeUsage : Entity
    {
        public int Usage { get; set; }

        public int VehicleSizeId { get; set; }
        public int SpotSizeId { get; set; }

        [ForeignKey("VehicleSizeId")]
        public SpotSize? VehicleSize { get; set; }
        [ForeignKey("SpotSizeId")]
        public SpotSize? SpotSize { get; set; }
    }
}

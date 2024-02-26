using ParkingLot.Server.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingLot.Server.Dtos
{
    public class SpotSizeUsageDto : EntityDto<SpotSizeUsage>
    {
        public int? Usage { get; set; }

        public int? VehicleSizeId { get; set; }
        public int? SpotSizeId { get; set; }

        public SpotSizeDto? VehicleSize { get; set; }
        public SpotSizeDto? SpotSize { get; set; }

        public SpotSizeUsageDto() : base()
        {
        }

        public SpotSizeUsageDto(SpotSizeUsage entity) : base(entity)
        {
        }

        public override void FromEntity(SpotSizeUsage entity)
        {
            Id = entity.Id;
            Usage = entity.Usage;
            VehicleSizeId = entity.VehicleSizeId;
            SpotSizeId = entity.SpotSizeId;
            VehicleSize = entity.VehicleSize != null ? new SpotSizeDto(entity.VehicleSize) : null;
            SpotSize = entity.SpotSize != null ? new SpotSizeDto(entity.SpotSize) : null;
        }

        public override SpotSizeUsage ToEntity()
        {
            return new SpotSizeUsage
            {
                Id = Id,
                Usage = Usage ?? 0,
                VehicleSizeId = VehicleSizeId ?? 0,
                SpotSizeId = SpotSizeId ?? 0,
                VehicleSize = VehicleSize != null ? VehicleSize.ToEntity() : null,
                SpotSize = SpotSize != null ? SpotSize.ToEntity() : null,
            };
        }
    }
}

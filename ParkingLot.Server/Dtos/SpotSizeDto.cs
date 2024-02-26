using ParkingLot.Server.Models;

namespace ParkingLot.Server.Dtos
{
    public class SpotSizeDto : EntityDto<SpotSize>
    {
        public string? Name { get; set; }

        public IEnumerable<SpotSizeUsageDto>? VehicleUsage { get; set; }
        public IEnumerable<SpotSizeUsageDto>? SpotUsage { get; set; }

        public SpotSizeDto() : base()
        {
        }

        public SpotSizeDto(SpotSize entity) : base(entity)
        {
        }

        public override void FromEntity(SpotSize entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            VehicleUsage = entity.VehicleUsage != null ? entity.VehicleUsage.Select(v => new SpotSizeUsageDto(v)) : null;
            SpotUsage = entity.SpotUsage != null ? entity.SpotUsage.Select(v => new SpotSizeUsageDto(v)) : null;
        }

        public override SpotSize ToEntity()
        {
            return new SpotSize
            {
                Id = Id,
                Name = Name,
                VehicleUsage = VehicleUsage != null ? VehicleUsage.Select(v => v.ToEntity()) : null,
                SpotUsage = SpotUsage != null ? SpotUsage.Select(v => v.ToEntity()) : null,
            };
        }
    }
}

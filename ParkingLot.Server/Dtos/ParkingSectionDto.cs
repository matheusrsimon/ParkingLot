using ParkingLot.Server.Models;

namespace ParkingLot.Server.Dtos
{
    public class ParkingSectionDto : EntityDto<ParkingSection>
    {
        public int? Count { get; set; }

        public int? SizeId { get; set; }

        public SpotSizeDto? Size { get; set; }
        public IEnumerable<VehicleDto>? Vehicles { get; set; }

        public ParkingSectionDto() : base()
        {
        }

        public ParkingSectionDto(ParkingSection entity) : base(entity)
        {
        }

        public override void FromEntity(ParkingSection entity)
        {
            Id = entity.Id;
            Count = entity.Count;
            SizeId = entity.SizeId;
            Size = entity.Size != null ? new SpotSizeDto(entity.Size) : null;
            Vehicles = entity.Vehicles != null ? entity.Vehicles.Select(v => new VehicleDto(v)) : null;
        }

        public override ParkingSection ToEntity()
        {
            return new ParkingSection
            {
                Id = Id,
                Count = Count ?? 0,
                SizeId = SizeId ?? 0,
                Size = Size != null ? Size.ToEntity() : null,
                Vehicles = Vehicles != null ? Vehicles.Select(v =>v.ToEntity()) : null,
            };
        }
    }
}

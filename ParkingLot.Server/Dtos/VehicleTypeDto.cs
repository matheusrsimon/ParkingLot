using ParkingLot.Server.Models;

namespace ParkingLot.Server.Dtos
{
    public class VehicleTypeDto : EntityDto<VehicleType>
    {
        public string? Name { get; set; }

        public int? SizeId { get; set; }

        public SpotSizeDto? Size { get; set; }

        public VehicleTypeDto() : base()
        {
        }

        public VehicleTypeDto(VehicleType entity) : base(entity)
        {
        }

        public override void FromEntity(VehicleType entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            SizeId = entity.SizeId;
            Size = entity.Size != null ? new SpotSizeDto(entity.Size) : null;
        }

        public override VehicleType ToEntity()
        {
            return new VehicleType
            {
                Id = Id,
                Name = Name,
                SizeId = SizeId ?? 0,
                Size = Size != null ? Size.ToEntity() : null,
            };
        }
    }
}

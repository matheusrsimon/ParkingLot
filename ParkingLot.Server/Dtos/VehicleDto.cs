using ParkingLot.Server.Models;
using System.Drawing;

namespace ParkingLot.Server.Dtos
{
    public class VehicleDto : EntityDto<Vehicle>
    {
        public string? Plate { get; set; }

        public int? TypeId { get; set; }
        public int? SectionId { get; set; }

        public VehicleTypeDto? Type { get; set; }
        public ParkingSectionDto? Section { get; set; }

        public VehicleDto() : base()
        {
        }

        public VehicleDto(Vehicle entity) : base(entity)
        {
        }

        public override void FromEntity(Vehicle entity)
        {
            Id = entity.Id;
            Plate = entity.Plate;
            TypeId = entity.TypeId;
            SectionId = entity.SectionId;
            Type = entity.Type != null ? new VehicleTypeDto(entity.Type) : null;
            Section = entity.Section != null ? new ParkingSectionDto(entity.Section) : null;
        }

        public override Vehicle ToEntity()
        {
            return new Vehicle
            {
                Id = Id,
                Plate = Plate,
                TypeId = TypeId ?? 0,
                SectionId = SectionId ?? 0,
                Type = Type != null ? Type.ToEntity() : null,
                Section = Section != null ? Section.ToEntity() : null,
            };
        }
    }
}

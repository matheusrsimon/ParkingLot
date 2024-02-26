namespace ParkingLot.Server.Core
{
    public class Car : Vehicle
    {
        public override SpotSize Size { get { return SpotSize.Medium; } }

        public override int? Spots(SpotSize size)
        {
            return size == SpotSize.Small ? null : 1;
        }
    }
}

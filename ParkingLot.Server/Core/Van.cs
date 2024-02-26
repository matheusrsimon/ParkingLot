namespace ParkingLot.Server.Core
{
    public class Van : Vehicle
    {
        public override SpotSize Size { get { return SpotSize.Large; } }

        public override int? Spots(SpotSize size)
        {
            return size == SpotSize.Small ? null : size == SpotSize.Medium ? 3 : 1;
        }
    }
}

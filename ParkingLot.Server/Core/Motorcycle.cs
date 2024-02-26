namespace ParkingLot.Server.Core
{
    public class Motorcycle : Vehicle
    {
        public override SpotSize Size { get { return SpotSize.Small; } }

        public override int? Spots(SpotSize size)
        {
            return 1;
        }
    }
}

namespace ParkingLot.Server.Core
{
    public class ParkingSection
    {
        public int count;

        public List<Vehicle> vehicles;

        public ParkingSection(int count)
        {
            this.count = count;
            vehicles = new List<Vehicle>();
        }

        public int Count(SpotSize size)
        {
            return vehicles.Where(v => v.Size == size).Count();
        }

        public void Remove(Vehicle vehicle)
        {
            vehicles.RemoveAll(v => v == vehicle);
        }
    }
}

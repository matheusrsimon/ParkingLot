namespace ParkingLot.Server.Core
{
    public abstract class Vehicle
    {
        public ParkingSection? parkedAt;

        public abstract SpotSize Size { get; }

        public abstract int? Spots(SpotSize size);

        public bool Park(ParkingLot lot)
        {
            if (parkedAt != null)
            {
                return false;
            }
            IEnumerable<SpotSize> sizes = Enum.GetValues<SpotSize>();
            sizes = sizes.SkipWhile(v => v < Size).Concat(sizes.TakeWhile(v => v < Size).Reverse());
            foreach (SpotSize size in sizes)
            {
                ParkingSection? section = lot.Add(this, size);
                if (section != null)
                {
                    parkedAt = section;
                    return true;
                }
            }
            return false;
        }

        public bool Leave()
        {
            if (parkedAt == null)
            {
                return false;
            }
            parkedAt.Remove(this);
            parkedAt = null;
            return true;
        }
    }
}

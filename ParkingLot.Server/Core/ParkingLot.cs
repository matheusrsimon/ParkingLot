using System;
using System.Linq;
using System.Collections.Generic;

#nullable enable

namespace ParkingLot.Server.Core
{
    public class ParkingLot
    {
        protected Dictionary<SpotSize, ParkingSection> spots;

        public ParkingLot(Dictionary<SpotSize, ParkingSection> spots)
        {
            this.spots = spots;
        }

        public ParkingLot(int smallSpots, int mediumSpots, int largeSpots)
            : this(new Dictionary<SpotSize, ParkingSection>()
            {
                [SpotSize.Small] = new ParkingSection(smallSpots),
                [SpotSize.Medium] = new ParkingSection(mediumSpots),
                [SpotSize.Large] = new ParkingSection(largeSpots)
            })
        {
        }

        public bool IsFull { get { return SpotsLeft() == 0; } }
        public bool IsEmpty { get { return spots.Sum(s => s.Value.vehicles.Count) == 0; } }

        public List<Vehicle> VehiclesIn(SpotSize size)
        {
            return spots[size].vehicles;
        }

        public int Count(SpotSize spotSize, SpotSize vehicleSize)
        {
            return spots[spotSize].Count(vehicleSize);
        }

        public int SpotsLeft(SpotSize? size = null)
        {
            if (size == null)
            {
                return spots.Sum(s => SpotsLeft(s.Key));
            }
            ParkingSection usage = spots[(SpotSize)size];
            switch (size)
            {
                case SpotSize.Medium:
                    return usage.count - (usage.vehicles.Count(v => v.Size != SpotSize.Large) + usage.vehicles.Count(v => v.Size == SpotSize.Large) * 3);
                default:
                    return usage.count - usage.vehicles.Count;
            }
        }

        public int SpotsCount(SpotSize? size = null)
        {
            if (size == null)
            {
                return spots.Sum(s => s.Value.count);
            }
            return spots[(SpotSize)size].count;
        }

        public ParkingSection? Add(Vehicle vehicle, SpotSize size)
        {
            int? spots = vehicle.Spots(size);
            if (spots != null && SpotsLeft(size) >= (int)spots)
            {
                ParkingSection section = this.spots[size];
                section.vehicles.Add(vehicle);
                return section;
            }
            return null;
        }

        public bool RemoveFirst(SpotSize spotSize, SpotSize vehicleSize)
        {
            Vehicle? vehicle = spots[spotSize].vehicles.FirstOrDefault(v => v.Size == vehicleSize);
            return vehicle == null ? false : vehicle.Leave();
        }
    }
}
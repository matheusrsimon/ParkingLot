namespace ParkingLot.Server.Core
{
    class Solution
    {
        static void Main(string[] args)
        {
            ParkingLot? lot = ReadParkingLot();
            Console.WriteLine("--------------------");
            if (lot != null)
            {
                PrintLotInfo(lot);
                Console.WriteLine("--------------------");
                Action? action;
                while ((action = ReadAction()) != null)
                {
                    switch (action)
                    {
                        case Action.Add:
                            Vehicle? vehicle = ReadVehicleAddition();
                            if (vehicle == null)
                            {
                                break;
                            }
                            PrintPark(lot, vehicle);
                            Console.WriteLine("--------------------");
                            break;
                        case Action.Remove:
                            Tuple<SpotSize, SpotSize>? sizes = ReadVehicleRemoval();
                            if (sizes == null)
                            {
                                break;
                            }
                            PrintRemoval(lot, sizes);
                            Console.WriteLine("--------------------");
                            break;
                    }
                    PrintLotInfo(lot);
                    Console.WriteLine("--------------------");
                }
            }
            Console.WriteLine("THE END");
        }

        static void PrintRemoval(ParkingLot lot, Tuple<SpotSize, SpotSize> sizes)
        {
            Console.WriteLine("Removing " + sizes.Item2 + " sized vehicle from " + sizes.Item1 + " section.");
            if (lot.RemoveFirst(sizes.Item1, sizes.Item2))
            {
                Console.WriteLine("Removed successfully.");
            }
            else
            {
                Console.WriteLine("Removal failed.");
            }
        }

        static Action? ReadAction()
        {
            Console.Write("Enter the action to be taken (a = Add Vehicle, r = Remove Vehicle): ");
            ConsoleKeyInfo option = Console.ReadKey();
            Console.WriteLine();
            switch (option.Key)
            {
                case ConsoleKey.A:
                    return Action.Add;
                case ConsoleKey.R:
                    return Action.Remove;
                default:
                    return null;
            }
        }

        static ParkingLot? ReadParkingLot()
        {
            int smallSpots, mediumSpots, largeSpots;
            Console.Write("Enter the amount of Motorcycle spots: ");
            if (!int.TryParse(Console.ReadLine(), out smallSpots))
            {
                return null;
            }
            Console.Write("Enter the amount of Car spots: ");
            if (!int.TryParse(Console.ReadLine(), out mediumSpots))
            {
                return null;
            }
            Console.Write("Enter the amount of Van spots: ");
            if (!int.TryParse(Console.ReadLine(), out largeSpots))
            {
                return null;
            }
            return new ParkingLot(smallSpots, mediumSpots, largeSpots);
        }

        static Vehicle? ReadVehicleAddition()
        {
            Console.Write("Select vehicle to park (m = Motorcycle, c = Car, v = Van): ");
            ConsoleKeyInfo option = Console.ReadKey();
            Console.WriteLine();
            switch (option.Key)
            {
                case ConsoleKey.M:
                    return new Motorcycle();
                case ConsoleKey.C:
                    return new Car();
                case ConsoleKey.V:
                    return new Van();
                default:
                    return null;
            }
        }

        static Tuple<SpotSize, SpotSize>? ReadVehicleRemoval()
        {
            Console.Write("Select vehicle to remove (m = Motorcycle, c = Car, v = Van): ");
            ConsoleKeyInfo vehicleOption = Console.ReadKey();
            Console.WriteLine();
            SpotSize? vehicleSize = KeyToSpotSize(vehicleOption.Key);
            Console.Write("Select section to remove from (m = Motorcycle, c = Car, v = Van): ");
            ConsoleKeyInfo spotOption = Console.ReadKey();
            Console.WriteLine();
            SpotSize? spotSize = KeyToSpotSize(spotOption.Key);
            return spotSize != null && vehicleSize != null ? new Tuple<SpotSize, SpotSize>((SpotSize)spotSize, (SpotSize)vehicleSize) : null;
        }

        static SpotSize? KeyToSpotSize(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.M:
                    return SpotSize.Small;
                case ConsoleKey.C:
                    return SpotSize.Medium;
                case ConsoleKey.V:
                    return SpotSize.Large;
                default:
                    return null;
            }
        }

        static void PrintPark(ParkingLot lot, Vehicle vehicle)
        {
            Console.WriteLine("Parking " + vehicle.Size + " sized vehicle.");
            if (vehicle.Park(lot))
            {
                Console.WriteLine("Parked successfully.");
            }
            else
            {
                Console.WriteLine("Parking failed.");
            }
        }

        static void PrintLotInfo(ParkingLot lot)
        {
            Console.WriteLine("Spots Left: " + lot.SpotsLeft() + " out of " + lot.SpotsCount());
            Console.WriteLine("    Small: " + lot.SpotsLeft(SpotSize.Small) + " (Motorcycles: " + lot.Count(SpotSize.Small, SpotSize.Small) + ")");
            Console.WriteLine("    Medium: " + lot.SpotsLeft(SpotSize.Medium) + " (Motorcycles: " + lot.Count(SpotSize.Medium, SpotSize.Small) + ", Cars: " + lot.Count(SpotSize.Medium, SpotSize.Medium) + ", Vans: " + lot.Count(SpotSize.Medium, SpotSize.Large) + ")");
            Console.WriteLine("    Large: " + lot.SpotsLeft(SpotSize.Large) + " (Motorcycles: " + lot.Count(SpotSize.Large, SpotSize.Small) + ", Cars: " + lot.Count(SpotSize.Large, SpotSize.Medium) + ", Vans: " + lot.Count(SpotSize.Large, SpotSize.Large) + ")");
            Console.WriteLine("Is Full: " + lot.IsFull);
            Console.WriteLine("Is Empty: " + lot.IsEmpty);
        }
    }
}

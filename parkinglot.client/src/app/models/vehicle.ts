import { ParkingSection } from "./parking-section";
import { SpotSize } from "./spot-size";
import { VehicleType } from "./vehicle-type";

export interface Vehicle {
  id?: number;
  plate: string;
  
  typeId: number;
  sectionId?: number;

  type?: VehicleType;
  section?: ParkingSection;
}

export function sectionSpotsUsed(section?: ParkingSection, types?: VehicleType[], sizes?: SpotSize[]): number {
  return !section || !types || !sizes ? 0 : section?.vehicles?.reduce((spots, vehicle) => {
    return spots += sizes?.find(s => s.id === types?.find(t => t.id === vehicle.typeId)?.id)?.vehicleUsage?.find(s => s.spotSizeId === section?.sizeId)?.usage ?? 0;
  }, 0) ?? 0;
}

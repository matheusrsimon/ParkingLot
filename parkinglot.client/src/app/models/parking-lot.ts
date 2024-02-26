import { ParkingSection } from "./parking-section";
import { SpotSize } from "./spot-size";

export interface ParkingLot {
  sections: ParkingSection[];
  sizes: SpotSize[];
}

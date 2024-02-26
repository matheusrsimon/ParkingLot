import { SpotSize } from "./spot-size";
import { Vehicle } from "./vehicle";

export interface ParkingSection {
  id?: number;
  count: number;

  sizeId: number;

  size?: SpotSize;
  vehicles?: Vehicle[];
}

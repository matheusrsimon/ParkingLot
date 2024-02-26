import { SpotSize } from "./spot-size";

export interface SpotSizeUsage {
  id?: number;

  usage: number;

  vehicleSizeId: number; 
  spotSizeId: number;

  vehicleSize?: SpotSize;
  spotSize?: SpotSize;
}

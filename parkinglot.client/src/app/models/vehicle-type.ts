import { SpotSize } from "./spot-size";

export interface VehicleType {
  id?: number;
  name: string;

  sizeId: number;

  size?: SpotSize;
}

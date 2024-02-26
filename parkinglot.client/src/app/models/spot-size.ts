import { SpotSizeUsage } from "./spot-size-usage";

export interface SpotSize {
  id?: number;
  name: string;
  vehicleUsage?: SpotSizeUsage[];
  spotUsage?: SpotSizeUsage[];
}

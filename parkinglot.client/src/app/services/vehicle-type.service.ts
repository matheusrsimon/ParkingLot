import { HttpClient } from "@angular/common/http";
import { VehicleType } from "../models/vehicle-type";
import { Injectable } from "@angular/core";
import { CrudService } from "./crud.service";

@Injectable()
export class VehicleTypeService extends CrudService<VehicleType> {
  public constructor(http: HttpClient) {
    super('vehicletype', http);
  }

  public override toEntity(apiDto: any): VehicleType {
    return apiDto;
  }
  public override toApiDto(entity: VehicleType): any {
    return entity;
  }
}

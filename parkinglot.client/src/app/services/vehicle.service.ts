import { HttpClient } from "@angular/common/http";
import { Vehicle } from "../models/vehicle";
import { Injectable } from "@angular/core";
import { CrudService } from "./crud.service";

@Injectable()
export class VehicleService extends CrudService<Vehicle> {
  public constructor(http: HttpClient) {
    super('vehicle', http);
  }

  public override toEntity(apiDto: any): Vehicle {
    return apiDto;
  }
  public override toApiDto(entity: Vehicle): any {
    return entity;
  }
}

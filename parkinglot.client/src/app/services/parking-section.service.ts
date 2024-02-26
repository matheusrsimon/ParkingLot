import { HttpClient } from "@angular/common/http";
import { ParkingSection } from "../models/parking-section";
import { Injectable } from "@angular/core";
import { CrudService } from "./crud.service";

@Injectable()
export class ParkingSectionService extends CrudService<ParkingSection> {
  public constructor(http: HttpClient) {
    super('parkingsection', http);
  }

  public override toEntity(apiDto: any): ParkingSection {
    return apiDto;
  }
  public override toApiDto(entity: ParkingSection): any {
    return entity;
  }
}

import { HttpClient } from "@angular/common/http";
import { SpotSize } from "../models/spot-size";
import { Injectable } from "@angular/core";
import { CrudService } from "./crud.service";

@Injectable()
export class SpotSizeService extends CrudService<SpotSize> {
  public constructor(http: HttpClient) {
    super('spotsize', http);
  }

  public override toEntity(apiDto: any): SpotSize {
    return apiDto;
  }
  public override toApiDto(entity: SpotSize): any {
    return entity;
  }
}

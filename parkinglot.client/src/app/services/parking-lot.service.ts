import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ParkingLot } from "../models/parking-lot";
import { Service } from "./service";
import { Observable, map } from "rxjs";

@Injectable()
export class ParkingLotService extends Service<ParkingLot> {
  public constructor(http: HttpClient) {
    super('parkinglot', http);
  }

  public get(): Observable<ParkingLot> {
    return this.http.get<any>(this.baseUrl).pipe(
      map(this.toEntity)
    );
  }

  public override toEntity(apiDto: any): ParkingLot {
    return apiDto;
  }
  public override toApiDto(entity: ParkingLot): any {
    return entity;
  }
}

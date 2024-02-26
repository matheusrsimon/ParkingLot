import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { VehicleType } from '../../models/vehicle-type';
import { VehicleTypeService } from "app/services/vehicle-type.service";
import { ParkingSection } from '../../models/parking-section';
import { ParkingSectionService } from '../../services/parking-section.service';
import { ParkingLotService } from '../../services/parking-lot.service';
import { ParkingLot } from '../../models/parking-lot';
import { VehicleService } from '../../services/vehicle.service';
import { Vehicle, sectionSpotsUsed } from '../../models/vehicle';
import { StringHelper } from '../../helpers/string.helper';
import { tap } from 'rxjs';
import { SpotSize } from '../../models/spot-size';

@Component({
  selector: 'parking-lot',
  templateUrl: './parking-lot.component.html',
  styleUrl: './parking-lot.component.css'
})
export class ParkingLotComponent implements OnInit {
  public types: VehicleType[];

  public parkingLot?: ParkingLot;

  public constructor(
    private vehicleTypeService: VehicleTypeService,
    private parkingLotService: ParkingLotService,
    private vehicleService: VehicleService
  ) {
    this.types = [];
  }
  
  public ngOnInit() {
    this.getVehicleTypes();
    this.getParkingLot();
  }

  public get spotsUsed(): number {
    return this.parkingLot?.sections.reduce((total, section) => total += sectionSpotsUsed(section, this.types, this.parkingLot?.sizes), 0) ?? 0;
  }

  public get totalSpots(): number {
    return this.parkingLot?.sections.reduce((total, section) => total += section.count ?? 0, 0) ?? 0;
  }

  public get spotsLeft(): number {
    return this.totalSpots - this.spotsUsed;
  }

  public get isEmpty(): boolean {
    return this.spotsUsed === 0;
  }

  public get isFull(): boolean {
    return this.spotsLeft === 0;
  }

  public addVehicle(vehicle: Required<Pick<Vehicle, 'typeId' | 'sectionId'>>) {
    this.vehicleService.create({ ...vehicle, plate: StringHelper.random(7) }).pipe(tap(result => {
      if (!result) {
        return;
      }
      this.parkingLot?.sections.find(s => s.id === vehicle.sectionId)?.vehicles?.push(result);
    })).subscribe();
  }

  public deleteVehicle(vehicle: Required<Pick<Vehicle, 'id' | 'sectionId'>>) {
    this.vehicleService.delete(vehicle.id).pipe(tap(result => {
      if (!result) {
        return;
      }
      const section = this.parkingLot?.sections.find(s => s.id === vehicle.sectionId);
      if (!section) {
        return;
      }
      section.vehicles = section.vehicles?.filter(v => v.id !== vehicle.id);
    })).subscribe();
  }
  
  public getVehicleTypes() {
    this.vehicleTypeService.filter().subscribe(types => this.types = types);
  }
  public getParkingLot() {
    this.parkingLotService.get().subscribe(parkingLot => this.parkingLot = parkingLot);
  }
}

import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormControl } from '@angular/forms';
import { VehicleType } from '../../models/vehicle-type';
import { ParkingSection } from '../../models/parking-section';
import { SpotSize } from '../../models/spot-size';
import { Vehicle, sectionSpotsUsed } from '../../models/vehicle';

@Component({
  selector: 'parking-section',
  templateUrl: './parking-section.component.html',
  styleUrl: './parking-section.component.css'
})
export class ParkingSectionComponent {
  @Input() public section?: ParkingSection;
  @Input() public sizes?: SpotSize[];
  @Input() public types?: VehicleType[];

  @Output() public onNewVehicle = new EventEmitter<Required<Pick<Vehicle, "typeId" | "sectionId">>>();
  @Output() public onDeleteVehicle = new EventEmitter<Required<Pick<Vehicle, "id" | "sectionId">>>();

  public constructor() {
  }

  public get sizeName() {
    return this.sizes?.find(s => s.id === this.section?.sizeId)?.name;
  }

  public get spotsUsed(): number {
    return sectionSpotsUsed(this.section, this.types, this.sizes);
  }

  public get totalSpots(): number {
    return this.section?.count ?? 0;
  }

  public get spotsLeft(): number {
    return this.totalSpots - this.spotsUsed;
  }

  public typeName(vehicle: Vehicle) {
    return this.types?.find(t => t.id === vehicle.typeId)?.name;
  }

  public emitAddNewVehicle(typeId: number, sectionId: number) {
    this.onNewVehicle.emit({ typeId, sectionId });
  }

  public addVehicle(typeId: number) {
    if (!this.section?.id) {
      return;
    }

    const vehicleSize = this.sizes?.find(s => s.id === this.types?.find(t => t.id === typeId)?.id);    
    const usage: number = vehicleSize?.vehicleUsage?.find(s => s.spotSizeId === this.section?.sizeId)?.usage ?? 0;

    if (!usage || this.spotsLeft < usage) {
      return;
    }

    this.emitAddNewVehicle(typeId, this.section.id)
  }

  public emitDeleteVehicle(id?: number) {
    if (!id || !this.section?.id) {
      return;
    }
    this.onDeleteVehicle.emit({ id, sectionId: this.section.id });
  }
}

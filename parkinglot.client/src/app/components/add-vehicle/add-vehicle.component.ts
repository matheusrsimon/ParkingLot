import { Component, EventEmitter, Input, Output } from '@angular/core';
import { VehicleType } from '../../models/vehicle-type';

@Component({
  selector: 'add-vehicle',
  templateUrl: './add-vehicle.component.html',
  styleUrl: './add-vehicle.component.css'
})
export class AddVehicleComponent {
  @Input() public types?: VehicleType[];

  @Output() public onNewVehicle = new EventEmitter<number>();

  public constructor() {
    this.types = [];
  }

  public emitAddNewVehicle(value: string) {
    const sizeId: number = Number(value);
    if (!sizeId) {
      return;
    }
    this.onNewVehicle.emit(sizeId);
  }
}

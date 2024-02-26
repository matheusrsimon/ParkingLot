import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FlexLayoutModule } from "@angular/flex-layout";
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ParkingLotComponent } from './components/parking-lot/parking-lot.component';
import { AddVehicleComponent } from './components/add-vehicle/add-vehicle.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { VehicleTypeService } from "./services/vehicle-type.service";
import { ParkingSectionComponent } from './components/parking-section/parking-section.component';
import { ParkingSectionService } from './services/parking-section.service';
import { SpotSizeService } from './services/spot-size.service';
import { VehicleService } from './services/vehicle.service';
import { ParkingLotService } from './services/parking-lot.service';

@NgModule({
  declarations: [
    AppComponent,
    ParkingLotComponent,
    ParkingSectionComponent,
    AddVehicleComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    FlexLayoutModule
  ],
  providers: [
    ParkingLotService,
    ParkingSectionService,
    SpotSizeService,
    VehicleService,
    VehicleTypeService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

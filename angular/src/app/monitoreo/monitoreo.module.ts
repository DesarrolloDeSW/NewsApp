import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';

import { MonitoreoRoutingModule } from './monitoreo-routing.module';
import { MonitoreoComponent } from './monitoreo.component';


@NgModule({
  declarations: [
    MonitoreoComponent
  ],
  imports: [
    SharedModule,
    MonitoreoRoutingModule
  ]
})
export class MonitoreoModule { }

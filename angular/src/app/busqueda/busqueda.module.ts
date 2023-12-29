import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { BusquedaRoutingModule } from './busqueda-routing.module';
import { BusquedaComponent } from './busqueda.component';


@NgModule({
  declarations: [
    BusquedaComponent
  ],
  imports: [
    SharedModule,
    BusquedaRoutingModule
  ]
})
export class BusquedaModule { }
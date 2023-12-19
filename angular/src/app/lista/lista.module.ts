import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { ListaRoutingModule } from './lista-routing.module';
import { ListaComponent } from './lista.component';

@NgModule({
  declarations: [ListaComponent],
  imports: [
    ListaRoutingModule,
    SharedModule
  ]
})
export class ListaModule { }


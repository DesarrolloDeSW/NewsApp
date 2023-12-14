import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { NotificacionRoutingModule } from './notificacion-routing.module';
import { NotificacionComponent } from './notificacion.component';

@NgModule({
  declarations: [NotificacionComponent],
  imports: [
    NotificacionRoutingModule,
    SharedModule
  ]
})
export class NotificacionModule { }
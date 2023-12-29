import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';

import { NoticiaModalRoutingModule } from './noticia-modal-routing.module';
import { NoticiaModalComponent } from './noticia-modal.component';


@NgModule({
  declarations: [
    NoticiaModalComponent
  ],
  imports: [
    SharedModule,
    NoticiaModalRoutingModule
  ]
})
export class NoticiaModalModule { }

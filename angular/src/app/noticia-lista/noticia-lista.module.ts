import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';

import { NoticiaListaRoutingModule } from './noticia-lista-routing.module';
import { NoticiaListaComponent } from './noticia-lista.component';


@NgModule({
  declarations: [
    NoticiaListaComponent
  ],
  imports: [
    SharedModule,
    NoticiaListaRoutingModule
  ]
})
export class NoticiaListaModule { }

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NoticiaListaComponent } from './noticia-lista.component';

const routes: Routes = [{ path: '', component: NoticiaListaComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class NoticiaListaRoutingModule { }

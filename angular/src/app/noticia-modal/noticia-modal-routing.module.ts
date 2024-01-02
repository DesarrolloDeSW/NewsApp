import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NoticiaModalComponent } from './noticia-modal.component';

const routes: Routes = [{ path: '', component: NoticiaModalComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class NoticiaModalRoutingModule { }

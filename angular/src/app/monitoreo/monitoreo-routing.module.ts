import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MonitoreoComponent } from './monitoreo.component';
import { AuthGuard, PermissionGuard } from '@abp/ng.core';

const routes: Routes = [{ path: '', component: MonitoreoComponent, canActivate: [AuthGuard, PermissionGuard] }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MonitoreoRoutingModule { }
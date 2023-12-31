import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NoticiaListaComponent } from './noticia-lista/noticia-lista.component';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    loadChildren: () => import('./home/home.module').then(m => m.HomeModule),
  },
  {
    path: 'account',
    loadChildren: () => import('@abp/ng.account').then(m => m.AccountModule.forLazy()),
  },
  {
    path: 'identity',
    loadChildren: () => import('@abp/ng.identity').then(m => m.IdentityModule.forLazy()),
  },
  {
    path: 'tenant-management',
    loadChildren: () =>
      import('@abp/ng.tenant-management').then(m => m.TenantManagementModule.forLazy()),
  },
  {
    path: 'setting-management',
    loadChildren: () =>
      import('@abp/ng.setting-management').then(m => m.SettingManagementModule.forLazy()),
  },
  { path: 'notificaciones', loadChildren: () => import('./notificacion/notificacion.module').then(m => m.NotificacionModule) },
  { path: 'listas', loadChildren: () => import('./lista/lista.module').then(m => m.ListaModule) },
  { path: 'noticias/:idLista', component: NoticiaListaComponent },
  { path: 'noticiasLista', loadChildren: () => import('./noticia-lista/noticia-lista.module').then(m => m.NoticiaListaModule) },
  { path: 'monitoreos', loadChildren: () => import('./monitoreo/monitoreo.module').then(m => m.MonitoreoModule) },
  { path: 'busquedas', loadChildren: () => import('./busqueda/busqueda.module').then(m => m.BusquedaModule) },
  { path: 'noticia-modal', loadChildren: () => import('./noticia-modal/noticia-modal.module').then(m => m.NoticiaModalModule) }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {})],
  exports: [RouterModule],
})
export class AppRoutingModule {}

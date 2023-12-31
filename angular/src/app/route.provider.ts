import { RoutesService, eLayoutType } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const APP_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/',
        name: '::Menu:Home',
        iconClass: 'fas fa-home',
        order: 1,
        layout: eLayoutType.application,
      },
      { 
        path: '/busquedas',
        name: '::Menu:Busquedas',
        iconClass: 'fas fa-pen',
        order: 2,
        layout: eLayoutType.application,
      },
      { 
        path: '/listas',
        name: '::Menu:Listas',
        iconClass: 'fas fa-list',
        order: 3,
        layout: eLayoutType.application,
      },

      {
        path: '/notificaciones',
        name: '::Menu:Notificaciones',
        iconClass: 'fas fa-envelope',
        order: 4,
        layout: eLayoutType.application,
      },

      { 
        path: '/monitoreos',
        name: '::Menu:Monitoreo',
        iconClass: 'fas fa-eye',
        order: 5,
        layout: eLayoutType.application,
        requiredPolicy: 'NewsApp.Monitoreo',
      }
    ]);
  };
}


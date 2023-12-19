import type { AlertaDto, NotificacionDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class AlertaService {
  apiName = 'Default';
  

  gestionarAlerta = (alertaId: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'POST',
      url: `/api/app/alerta/gestionar-alerta/${alertaId}`,
    },
    { apiName: this.apiName,...config });
  

  getAlertas = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, AlertaDto[]>({
      method: 'GET',
      url: '/api/app/alerta/alertas',
    },
    { apiName: this.apiName,...config });
  

  getNotificaciones = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, NotificacionDto[]>({
      method: 'GET',
      url: '/api/app/alerta/notificaciones',
    },
    { apiName: this.apiName,...config });
  

  marcarNotificacionesComoLeidas = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'POST',
      url: '/api/app/alerta/marcar-notificaciones-como-leidas',
    },
    { apiName: this.apiName,...config });
  

  postAlerta = (cadenaBusqueda: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, AlertaDto>({
      method: 'POST',
      url: '/api/app/alerta/alerta',
      params: { cadenaBusqueda },
    },
    { apiName: this.apiName,...config });
  

  postNotificacion = (alertaId: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, NotificacionDto>({
      method: 'POST',
      url: `/api/app/alerta/notificacion/${alertaId}`,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}

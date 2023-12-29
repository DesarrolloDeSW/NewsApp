import type { AccesoAPIDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class MonitoreoAPIService {
  apiName = 'Default';
  

  getAccesosAPI = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, AccesoAPIDto[]>({
      method: 'GET',
      url: '/api/app/monitoreo-aPI/accesos-aPI',
    },
    { apiName: this.apiName,...config });
  

  getCantidadAccesosUsuario = (usuarioId: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, number>({
      method: 'GET',
      url: `/api/app/monitoreo-aPI/cantidad-accesos-usuario/${usuarioId}`,
    },
    { apiName: this.apiName,...config });
  

  getCantidadTotalAccesos = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, number>({
      method: 'GET',
      url: '/api/app/monitoreo-aPI/cantidad-total-accesos',
    },
    { apiName: this.apiName,...config });
  

  getPorcentajeExito = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, number>({
      method: 'GET',
      url: '/api/app/monitoreo-aPI/porcentaje-exito',
    },
    { apiName: this.apiName,...config });
  

  getTiempoPromedio = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, string>({
      method: 'GET',
      responseType: 'text',
      url: '/api/app/monitoreo-aPI/tiempo-promedio',
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}

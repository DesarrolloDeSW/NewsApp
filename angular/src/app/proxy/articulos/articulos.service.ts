import type { CodigosIdiomas } from './codigos-idiomas.enum';
import type { OrdenBusqueda } from './orden-busqueda.enum';
import { RestService, Rest } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { NoticiaDto } from '../listas/models';

@Injectable({
  providedIn: 'root',
})
export class ArticulosService {
  apiName = 'Default';
  

  getBusquedaApiNews = (cadena: string, idioma: CodigosIdiomas, ordenarPor: OrdenBusqueda, config?: Partial<Rest.Config>) =>
    this.restService.request<any, NoticiaDto[]>({
      method: 'GET',
      url: '/api/app/articulos/busqueda-api-news',
      params: { cadena, idioma, ordenarPor },
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}

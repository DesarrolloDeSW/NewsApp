import type { AgregarNoticiaDto, CreateListaDto, ListaDto, UpdateListaDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ListaService {
  apiName = 'Default';
  

  agregarNoticia = (input: AgregarNoticiaDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ListaDto>({
      method: 'POST',
      url: '/api/app/lista/agregar-noticia',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  deleteLista = (id: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ListaDto>({
      method: 'DELETE',
      url: `/api/app/lista/${id}/lista`,
    },
    { apiName: this.apiName,...config });
  

  getLista = (id: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ListaDto>({
      method: 'GET',
      url: `/api/app/lista/${id}/a`,
    },
    { apiName: this.apiName,...config });
  

  getListas = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, ListaDto[]>({
      method: 'GET',
      url: '/api/app/lista/as',
    },
    { apiName: this.apiName,...config });
  

  getListasUsuario = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, ListaDto[]>({
      method: 'GET',
      url: '/api/app/lista/as-usuario',
    },
    { apiName: this.apiName,...config });
  

  postLista = (input: CreateListaDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ListaDto>({
      method: 'POST',
      url: '/api/app/lista/lista',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  updateLista = (input: UpdateListaDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ListaDto>({
      method: 'PUT',
      url: '/api/app/lista/lista',
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}

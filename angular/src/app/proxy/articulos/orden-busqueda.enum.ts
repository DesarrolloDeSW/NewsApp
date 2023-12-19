import { mapEnumToOptions } from '@abp/ng.core';

export enum OrdenBusqueda {
  relevancia = 0,
  popularidad = 1,
  fechaPublicacion = 2,
}

export const ordenBusquedaOptions = mapEnumToOptions(OrdenBusqueda);

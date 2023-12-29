import type { EntityDto } from '@abp/ng.core';
import type { ErrorCodes } from './error-codes.enum';

export interface AccesoAPIDto extends EntityDto<number> {
  usuarioId?: string;
  tiempoTotal?: string;
  tiempoInicio?: string;
  tiempoFin?: string;
  errorCode?: ErrorCodes;
  errorMessage?: string;
}

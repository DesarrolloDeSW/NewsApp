import type { EntityDto } from '@abp/ng.core';

export interface AlertaDto extends EntityDto<number> {
  fechaCreacion?: string;
  activa: boolean;
  cadenaBusqueda?: string;
  usuarioId?: string;
}

export interface NotificacionDto extends EntityDto<number> {
  fechaEnvio?: string;
  cadenaBusqueda?: string;
  usuarioId?: string;
  leida: boolean;
}

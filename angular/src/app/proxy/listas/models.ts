import type { EntityDto } from '@abp/ng.core';

export interface AgregarNoticiaDto {
  noticia: NoticiaDto;
  idLista: number;
}

export interface CreateListaDto {
  nombre: string;
  descripcion?: string;
  parentId?: number;
}

export interface ListaDto extends EntityDto<number> {
  nombre?: string;
  fechaCreacion?: string;
  descripcion?: string;
  alerta: boolean;
  parentId?: number;
  noticias: NoticiaDto[];
  listas: ListaDto[];
  usuarioId?: string;
}

export interface NoticiaDto extends EntityDto<number> {
  titulo?: string;
  autor?: string;
  descripcion?: string;
  url?: string;
  contenido?: string;
  fechaPublicacion?: string;
  fuente?: string;
  visto: boolean;
}

export interface UpdateListaDto {
  id: number;
  nombre?: string;
  descripcion?: string;
}

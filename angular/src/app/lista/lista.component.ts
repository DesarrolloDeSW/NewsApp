import { ListService, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { ListaService, ListaDto } from '@proxy/listas';
import { Observable, map } from 'rxjs';

@Component({
  selector: 'app-lista',
  templateUrl: './lista.component.html',
  styleUrls: ['./lista.component.scss'],
  providers: [ListService],
})
export class ListaComponent implements OnInit {
  lista = { items: [], totalCount: 0 } as PagedResultDto<ListaDto>;

  constructor(public readonly list: ListService, private listaService: ListaService) {}

  ngOnInit() {
    const listaStreamCreator = (query) => this.getListasUsuario(query);

    this.list.hookToQuery(listaStreamCreator).subscribe((response) => {
      this.lista = response;
    });
  }

  private getListasUsuario(query): Observable<PagedResultDto<ListaDto>> {
    return this.listaService.getListasUsuario(query).pipe(
      map((listaItems: ListaDto[]) => {
        return {
          items: listaItems,
          totalCount: listaItems.length // O ajusta aquí el total de elementos recibidos
        } as PagedResultDto<ListaDto>;
      })
    );
  }
  
}


import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ListaService, NoticiaDto } from '@proxy/listas';  // Ajusta la ruta según la ubicación real de tu servicio
import { ListService, PagedResultDto } from '@abp/ng.core';

@Component({
  selector: 'app-noticia-lista',
  templateUrl: './noticia-lista.component.html',
  styleUrls: ['./noticia-lista.component.scss'],
  providers: [ListService]
})

export class NoticiaListaComponent implements OnInit {
  noticias: NoticiaDto[] = []; // Inicializa como un array de NoticiaDto

  constructor(
    private route: ActivatedRoute,
    private listaService: ListaService
  ) {}

  ngOnInit() {
    const idListaString = this.route.snapshot.paramMap.get('idLista');
    const idLista = parseInt(idListaString, 10);

    this.listaService.getNoticiasLista(idLista).subscribe(
      (noticias: NoticiaDto[]) => {
        this.noticias = noticias;
      },
      (error) => {
        console.error('Error al obtener las noticias:', error);
      }
    );
  }
}
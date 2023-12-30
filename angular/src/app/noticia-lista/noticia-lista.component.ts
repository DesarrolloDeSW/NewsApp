// noticia-lista.component.ts
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ListaService, NoticiaDto } from '@proxy/listas';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { NoticiaModalComponent } from '../noticia-modal/noticia-modal.component';

@Component({
  selector: 'app-noticia-lista',
  templateUrl: './noticia-lista.component.html',
  styleUrls: ['./noticia-lista.component.scss']
})

export class NoticiaListaComponent implements OnInit {
  noticias: NoticiaDto[] = [];

  constructor(
    private route: ActivatedRoute,
    private listaService: ListaService,
    private modalService: NgbModal
  ) {}

  ngOnInit() {
    this.obtenerNoticiasLista();
  }

  obtenerNoticiasLista() {
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

  leerNoticia(noticia: NoticiaDto) {
    const modalRef = this.modalService.open(NoticiaModalComponent, { size: 'lg' }); // Ajusta el tamaño según tus necesidades
    modalRef.componentInstance.noticia = noticia;
  }

  eliminarNoticiaDeLista(noticia: NoticiaDto) {
    const idListaString = this.route.snapshot.paramMap.get('idLista');
    const idLista = parseInt(idListaString, 10);

    this.listaService.deleteNoticia(noticia.id)
      .subscribe(
        () => {
          // Actualizar la lista de noticias después de eliminar
          this.obtenerNoticiasLista();
        },
        (error) => {
          console.error('Error al eliminar la noticia:', error);
        }
      );
  }
}

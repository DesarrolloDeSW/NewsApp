// noticia-modal.component.ts
import { Component, Input } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { NoticiaDto } from '@proxy/listas';

@Component({
  selector: 'app-noticia-modal',
  templateUrl: './noticia-modal.component.html',
  styleUrls: ['./noticia-modal.component.scss']
})
export class NoticiaModalComponent {
  @Input() noticia: NoticiaDto;

  constructor(public activeModal: NgbActiveModal) {}

  // Puedes agregar métodos adicionales según sea necesario
}

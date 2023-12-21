import { ListService, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { ListaService, ListaDto, NoticiaDto } from '@proxy/listas';
import { Observable, map } from 'rxjs';
import { FormGroup, FormBuilder, Validators } from '@angular/forms'; 
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';
import { NgbModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';


@Component({
  selector: 'app-lista',
  templateUrl: './lista.component.html',
  styleUrls: ['./lista.component.scss'],
  providers: [ListService],
})

export class ListaComponent implements OnInit {
  lista = { items: [], totalCount: 0 } as PagedResultDto<ListaDto>;
  noticiasLista = {items: [], totalCount: 0} as PagedResultDto<NoticiaDto>;

  selectedLista = {} as ListaDto; // declare selectedLista
  private modalRef: NgbModalRef; // Agrega una referencia al modal

  form: FormGroup; // add this line
  isModalOpen = false; // add this line

  constructor(
    public readonly list: ListService, 
    private listaService: ListaService,
    private fb: FormBuilder, // inject FormBuilder
    private confirmation: ConfirmationService, 
    private modalService: NgbModal
    ) {}

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

  private getNoticiasLista(idLista): Observable<PagedResultDto<NoticiaDto>> {
    return this.listaService.getNoticiasLista(idLista).pipe(
      map((noticiaItems: NoticiaDto[]) => {
        return {
          items: noticiaItems,
          totalCount: noticiaItems.length // O ajusta aquí el total de elementos recibidos
        } as PagedResultDto<NoticiaDto>;
      })
    );
  }


 
  verNoticiasLista(id: number) {
    console.log('Ver Noticias - ID:', id); // Agrega este log para verificar si la función se está llamando correctamente
  
    this.getNoticiasLista(id).subscribe((pagedResult: PagedResultDto<NoticiaDto>) => {
      console.log('Noticias Lista:', pagedResult); // Agrega este log para verificar si recibes datos correctamente
  
      // Asigna las noticias a la propiedad en tu componente, por ejemplo:
      this.noticiasLista = pagedResult;
  
      // Agrega cualquier lógica adicional que necesites con las noticias aquí.
    });
  }
  
  

  crearLista() {
    this.selectedLista = {} as ListaDto; // reset the selected lista
    this.buildForm(); // add this line
    this.isModalOpen = true;
  }

   // Add editarLista method
  editarLista(id: number) {
    this.listaService.getLista(id).subscribe((lista) => {
      this.selectedLista = lista;
      this.buildForm();
      this.form.patchValue({
        Nombre: lista.nombre,
        Descripcion: lista.descripcion
      });
      
      // Asignar el id al objeto UpdateListaDto
      this.form.get('Id').setValue(lista.id);
      
      this.isModalOpen = true;
    });
  }

  eliminarLista(id: number) {
  this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe((status) => {
    if (status === Confirmation.Status.confirm) {
      this.listaService.deleteLista(id).subscribe(() => this.list.get());
    }
  });
}

    // add buildForm method
    buildForm() {
      this.form = this.fb.group({
        Id: [null], // Asegúrate de que este campo esté presente
        Nombre: ['', Validators.required],
        Descripcion: [null]
      });
    }    
  
    // add save method
    save() {
      if (this.form.invalid) {
        return;
      }
    
      const request = this.selectedLista.id
        ? this.listaService.updateLista(this.selectedLista.id, this.form.value)
        : this.listaService.postLista(this.form.value);
    
      request.subscribe(
        () => {
          this.isModalOpen = false;
          this.form.reset();
          this.list.get();
        }
      );
    }
    
    

}



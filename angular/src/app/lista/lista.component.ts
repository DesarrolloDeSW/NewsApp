import { ListService, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { ListaService, ListaDto } from '@proxy/listas';
import { Observable, map } from 'rxjs';
import { FormGroup, FormBuilder, Validators } from '@angular/forms'; 
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';

@Component({
  selector: 'app-lista',
  templateUrl: './lista.component.html',
  styleUrls: ['./lista.component.scss'],
  providers: [ListService],
})

export class ListaComponent implements OnInit {
  lista = { items: [], totalCount: 0 } as PagedResultDto<ListaDto>;

  selectedLista = {} as ListaDto; // declare selectedLista

  form: FormGroup; // add this line
  isModalOpen = false; // add this line

  constructor(
    public readonly list: ListService, 
    private listaService: ListaService,
    private fb: FormBuilder, // inject FormBuilder
    private confirmation: ConfirmationService 
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



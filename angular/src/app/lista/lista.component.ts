import { ListService, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { ListaService, ListaDto, NoticiaDto } from '@proxy/listas';
import { Observable, map } from 'rxjs';
import { FormGroup, FormBuilder, Validators } from '@angular/forms'; 
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';
import { Router } from '@angular/router';

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

  form: FormGroup; // add this line
  isModalOpen = false; // add this line

  constructor(
    public readonly list: ListService, 
    private listaService: ListaService,
    private fb: FormBuilder, // inject FormBuilder
    private confirmation: ConfirmationService, 
    private router: Router,
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
        // Filtrar las listas con ParentId = null
        const filteredListas = listaItems.filter(lista => lista.parentId === null);
  
        return {
          items: filteredListas,
          totalCount: filteredListas.length // O ajusta aquí el total de elementos filtrados
        } as PagedResultDto<ListaDto>;
      })
    );
  }

  private getSubListas(idLista: number): Observable<PagedResultDto<ListaDto>> {
    return this.listaService.getSubListasLista(idLista).pipe(
      map((subListaItems: ListaDto[]) => {
        return {
          items: subListaItems,
          totalCount: subListaItems.length
        } as PagedResultDto<ListaDto>;
      })
    );
  }

  verSubListas(idLista: number) {
    this.getSubListas(idLista).subscribe((subLista) => {
      this.lista = subLista;
    });
  }

  volverAListaPrincipal() {
    // Puedes proporcionar un objeto query vacío o nulo, según tu implementación.
    const query = {}; // o puedes usar const query = null;
  
    this.getListasUsuario(query).subscribe((response) => {
      this.lista = response;
    });
  }


  crearSublista(idListaPadre: number) {
    this.selectedLista = { parentId: idListaPadre } as ListaDto;
    this.buildForm();
    this.isModalOpen = true;
  }



  /*
  private getNoticiasLista(idLista): Observable<PagedResultDto<NoticiaDto>> {
    return this.listaService.getNoticiasLista(idLista).pipe(
      map((noticiaItems: NoticiaDto[]) => {
        return {
          items: noticiaItems,
          totalCount: noticiaItems.length // O ajusta aquí el total de elementos recibidos
        } as PagedResultDto<NoticiaDto>;
      })
    );
  }*/


  verNoticias(idLista:number) {
    this.router.navigate(['/noticias/', idLista]); 
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
  
    /*
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
    }*/

    save() {
      if (this.form.invalid) {
        return;
      }
    
      const request = this.selectedLista.id
        ? this.listaService.updateLista(this.selectedLista.id, this.form.value)
        : this.listaService.postLista({ ...this.form.value, parentId: this.selectedLista.parentId });
    
      request.subscribe(
        () => {
          this.isModalOpen = false;
          this.form.reset();
          this.list.get();
        }
      );
    }
    
    
    

}



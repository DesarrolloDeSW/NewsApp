import { ListService, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { ListaService, ListaDto } from '@proxy/listas';
import { Observable, map } from 'rxjs';
import { FormGroup, FormBuilder, Validators } from '@angular/forms'; 

@Component({
  selector: 'app-lista',
  templateUrl: './lista.component.html',
  styleUrls: ['./lista.component.scss'],
  providers: [ListService],
})

export class ListaComponent implements OnInit {
  lista = { items: [], totalCount: 0 } as PagedResultDto<ListaDto>;

  form: FormGroup; // add this line
  isModalOpen = false; // add this line

  constructor(
    public readonly list: ListService, 
    private listaService: ListaService,
    private fb: FormBuilder // inject FormBuilder
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
    this.buildForm(); // add this line
    this.isModalOpen = true;
  }

    // add buildForm method
    buildForm() {
      this.form = this.fb.group({
        Nombre: ['', Validators.required],
        Descripcion: [null]
      });
    }
  
    // add save method
    save() {
      if (this.form.invalid) {
        return;
      }
  
        this.listaService.postLista(this.form.value).subscribe(() => {
        this.isModalOpen = false;
        this.form.reset();
        this.list.get();
      });
    }
}



import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ListaService, ListaDto } from '@proxy/listas';
import { ArticulosService } from '@proxy/articulos/articulos.service';
import { NoticiaDto, AgregarNoticiaDto } from '@proxy/listas';
import { AlertaService } from '@proxy/alertas';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { NoticiaModalComponent } from '../noticia-modal/noticia-modal.component'; 

@Component({
  selector: 'app-busqueda',
  templateUrl: './busqueda.component.html',
  styleUrls: ['./busqueda.component.scss']
})
export class BusquedaComponent {
  searchText: string;
  form: FormGroup; // Agrega la propiedad del formulario
  listasUsuario: ListaDto[] = [];
  noticias: NoticiaDto[] = []; // Agrega un array de noticias para almacenar los resultados de la búsqueda
  selectedNoticia: NoticiaDto; // Añade esta propiedad al componente
  isModalOpen = false; // add this line

  constructor(
    private alertaService: AlertaService,
    private articulosService: ArticulosService,
    private fb: FormBuilder,
    private listaService: ListaService,
    private modalService: NgbModal // Agrega esta línea
  ) {}
  // Agrega el método para abrir el modal
  agregarNoticia(row: NoticiaDto) {
    // Recuperar la lista de listas del usuario
    this.listaService.getListasUsuario({}).subscribe((response) => {
      this.listasUsuario = response;

      this.buildForm();

      // Asignar la noticia seleccionada al formulario
      this.form.patchValue({
        ListaId: null, // Ajusta según tu lógica para seleccionar una lista por defecto
      });

      // Ajusta aquí la lógica para abrir el modal con la noticia y las listas
      this.selectedNoticia = row; // Añade una propiedad selectedNoticia al componente
      this.isModalOpen = true;
    });
  }

  // Agrega el método para construir el formulario
  buildForm() {
    this.form = this.fb.group({
      ListaId: [null],
    });
  }
  
  buscarNoticias() {
    if (this.searchText) {
      this.articulosService.getBusquedaApiNews(this.searchText, null, null).subscribe(
        (result) => {
          this.noticias = result;

          // Verifica si la búsqueda arrojó resultados
          if (this.noticias.length === 0) {
            // Si no hay resultados, crea una alerta
            this.crearAlerta();
          }
        },
        (error) => console.error('Error en la búsqueda:', error)
      );
    } else {
      console.log('Por favor, ingrese un texto de búsqueda.');
    }
  }

  // ... (resto del código)

  // Método para crear una alerta
  private crearAlerta() {
    const cadenaBusqueda = this.searchText;

    // Llama al método postAlerta del servicio de alertas
    this.alertaService.postAlerta(cadenaBusqueda).subscribe(
      (alertaCreada) => {
        // Manejar la respuesta de éxito, si es necesario
        console.log('Alerta creada exitosamente:', alertaCreada);
      },
      (error) => {
        // Manejar errores, si es necesario
        console.error('Error al crear la alerta:', error);
      }
    );
  }


  saveNoticiaToPlaylist() {
    if (this.form.invalid || !this.selectedNoticia) {
      return;
    }

    const listaId = this.form.value.ListaId;

    // Construye el objeto AgregarNoticiaDto
    const agregarNoticiaDto: AgregarNoticiaDto = {
      noticia: this.selectedNoticia,
      idLista: listaId
    };

    // Llama al método agregarNoticia del servicio de listas
    this.listaService.agregarNoticia(agregarNoticiaDto).subscribe(
      (listaActualizada) => {
        // Manejar la respuesta de éxito, si es necesario
        console.log('Noticia agregada exitosamente a la lista:', listaActualizada);
      },
      (error) => {
        // Manejar errores, si es necesario
        console.error('Error al agregar la noticia a la lista:', error);
      }
    );

    this.isModalOpen = false;
  }

  leerNoticia(row: NoticiaDto) {
    const modalRef = this.modalService.open(NoticiaModalComponent, { size: 'lg' }); // Ajusta el tamaño según sea necesario
    modalRef.componentInstance.noticia = row;
  }
}

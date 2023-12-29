// monitoreo.component.ts
import { Component, OnInit } from '@angular/core';
import { MonitoreoAPIService, AccesoAPIDto} from '@proxy/articulos';

@Component({
  selector: 'app-monitoreo',
  templateUrl: './monitoreo.component.html',
  styleUrls: ['./monitoreo.component.scss'],
})
export class MonitoreoComponent implements OnInit {
  userId: string;
  cantidadAccesosUsuario: number;
  cantidadTotalAccesos: number;
  porcentajeExito: number;
  tiempoPromedio: string;
  accesosAPI: AccesoAPIDto[] = []; // Agregamos un arreglo para almacenar los accesos API

  // Agregamos una bandera para controlar si se ha cargado la data de accesos del usuario
  loadedCantidadAccesosUsuarioData = false;

  constructor(private monitoreoService: MonitoreoAPIService) {}

  ngOnInit(): void {
    this.loadMonitoreoData();
    this.loadAccesosAPI();
  }
  
  loadMonitoreoData() {
    if (this.userId) {
      const usuarioId = this.userId;

      this.monitoreoService.getCantidadAccesosUsuario(usuarioId).subscribe(
        (result) => {
          this.cantidadAccesosUsuario = result;
          // Indicar que la data se ha cargado
          this.loadedCantidadAccesosUsuarioData = true;
        },
        (error) => console.error(error)
      );
    }

    // Las demás llamadas no dependen de la ID del usuario, así que siempre se realizan
    this.monitoreoService.getCantidadTotalAccesos().subscribe(
      (result) => (this.cantidadTotalAccesos = result),
      (error) => console.error(error)
    );

    this.monitoreoService.getPorcentajeExito().subscribe(
      (result) => (this.porcentajeExito = result),
      (error) => console.error(error)
    );

    this.monitoreoService.getTiempoPromedio().subscribe(
      (result) => (this.tiempoPromedio = result),
      (error) => console.error(error)
    );
  }

  // Método para cargar la data de accesos API
  loadAccesosAPI() {
    this.monitoreoService.getAccesosAPI().subscribe(
      (result) => (this.accesosAPI = result),
      (error) => console.error(error)
    );
  }
}
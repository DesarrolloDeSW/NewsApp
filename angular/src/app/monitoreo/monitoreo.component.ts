// monitoreo.component.ts
import { Component, OnInit } from '@angular/core';
import { MonitoreoAPIService } from '@proxy/articulos';

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

  constructor(private monitoreoService: MonitoreoAPIService) {}

  ngOnInit(): void {
    this.loadMonitoreoData();
  }

  loadMonitoreoData() {
    // Verificar si se ha ingresado algo en el campo de ID del usuario
    if (this.userId) {
      // Utiliza la ID ingresada por el usuario
      const usuarioId = this.userId;

      this.monitoreoService.getCantidadAccesosUsuario(usuarioId).subscribe(
        (result) => (this.cantidadAccesosUsuario = result),
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
}
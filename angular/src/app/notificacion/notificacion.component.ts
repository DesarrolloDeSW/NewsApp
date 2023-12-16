import { ListService, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { AlertaService, NotificacionDto } from '@proxy/alertas';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-notificacion',
  templateUrl: './notificacion.component.html',
  styleUrls: ['./notificacion.component.scss'],
  providers: [ListService],
})
export class NotificacionComponent implements OnInit {
  notificacion = { items: [], totalCount: 0 } as PagedResultDto<NotificacionDto>;

  constructor(public readonly list: ListService, private alertaService: AlertaService) {}

  ngOnInit() {
    const notificacionStreamCreator = (query) => this.alertaService.getNotificaciones(query)
      .pipe(
        map((notificaciones: NotificacionDto[]) => {
          return { items: notificaciones, totalCount: notificaciones.length } as PagedResultDto<NotificacionDto>;
        })
      );
  
      this.list.hookToQuery(notificacionStreamCreator).subscribe((response) => {
        // Ordenar las notificaciones primero por leída/no leída y luego por fecha de envío
        response.items.sort((a, b) => {
          const fechaEnvioA = new Date(a.fechaEnvio);
          const fechaEnvioB = new Date(b.fechaEnvio);
      
          if (a.leida === b.leida) {
            // Si tienen el mismo estado de lectura, ordenar por fecha de envío de forma descendente (más reciente primero)
            return fechaEnvioB.getTime() - fechaEnvioA.getTime();
          } else {
            // Si tienen estados de lectura diferentes, colocar las no leídas primero
            return a.leida ? 1 : -1;
          }
        });

        // Marcar notificaciones como leídas al entrar en la página
      this.alertaService.marcarNotificacionesComoLeidas().subscribe();
      
        this.notificacion = response;
      });
  }
  
}

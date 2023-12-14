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
      this.notificacion = response;
    });
  }
  
}

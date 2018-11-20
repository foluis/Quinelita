import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router'

@Component({
  selector: 'detalle-jornada',
  templateUrl: './detalle-jornada.component.html',
  styleUrls: ['./detalle-jornada.component.css']
})

export class DetalleJornadaComponent {

  jornada: any;
  jornadas: any[];
  partidos: any[];
  qinelaJornadaXUsuario: any;
  private baseUrl: string;
  private http: HttpClient;
  title = 'app';

  constructor(private router: Router, http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

    this.baseUrl = baseUrl;
    this.http = http;

  }

  ngOnInit() {
    var url0 = this.baseUrl + 'api/jornadas/31';

    this.http.get(url0)
      .subscribe(response => {
        this.jornada = response as any;
        
      }, error => console.error(error));

    let partidosUrl = this.baseUrl + 'api/partidos/GetPartidosJornadaXJornada/31';

    this.http.get(partidosUrl)
      .subscribe(response => {
        this.partidos = response as any[];
        
      }, error => console.error(error));

    let quinelaJornadaXUsuarioURL = this.baseUrl + 'api/QuinelasJornada/Jornada/31/UsuarioId/1';

    this.http.get(quinelaJornadaXUsuarioURL)
      .subscribe(response => {
        this.qinelaJornadaXUsuario = response as any[];
        console.log(response);
      }, error => console.error(error));
  }

}

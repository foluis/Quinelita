import { Component ,Inject} from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router'

@Component({
    selector: 'detalle-jornada',
    templateUrl: './detalle-jornada.component.html',
    styleUrls: ['./detalle-jornada.component.css']
})

export class DetalleJornadaComponent {

  jornada: any;
  private url = 'https://localhost:44322/api/jornadas';
  private baseUrl: string;

  constructor(private router: Router, private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

    this.baseUrl = baseUrl + 'api/jornadas/GetJornadaConPartidos/31';

    http.get(this.baseUrl)
      .subscribe(response => {
        this.jornada = response as any;
        console.log(response);
      }, error => console.error(error));
  }
}

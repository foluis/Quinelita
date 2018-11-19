import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router'

@Component({
  selector: 'jornada',
  templateUrl: './jornada.component.html',
  styleUrls: ['./jornada.component.css']
})

export class JornadaComponent {
  jornadas: any[];
    private url = 'https://localhost:44322/api/jornadas';
    private baseUrl: string;

  constructor(private router: Router, private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

    this.baseUrl = baseUrl + 'api/jornadas';

    http.get(this.baseUrl)
      .subscribe(response => {
        this.jornadas = response as any[];
        //console.log(response);
      }, error => console.error(error));
  }

  createJornada(nombreJornada: HTMLInputElement) {   

    let jornada = {
      nombre: nombreJornada.value,
      fecha: new Date(),
      abiertaAlPublico: true
    };

    nombreJornada.value = '';
    console.log(jornada);
    this.http.post(this.url, jornada)
      .subscribe(response => {
        //jornada['id'] = response.
        this.jornadas.splice(0, 0, jornada)
        console.log(response);
      });
  }

  jornadaSeleccionada(element) {
    console.log(this.jornadas[element]);
    this.router.navigateByUrl('/detalle-jornada'); 
    //let jornada = {
    //  nombre: nombreJornada.value,
    //  fecha: new Date(),
    //  abiertaAlPublico: true
    //};

    //nombreJornada.value = '';
    //console.log(jornada);
    //this.http.post(this.url, jornada)
    //  .subscribe(response => {
    //    //jornada['id'] = response.
    //    this.jornadas.splice(0, 0, jornada)
    //    console.log(response);]
    //  });
  }

  formatDate_YYYYMMDD(date) {
    var d = new Date(date),
      month = '' + (d.getMonth() + 1),
      day = '' + d.getDate(),
      year = d.getFullYear();

    if (month.length < 2) month = '0' + month;
    if (day.length < 2) day = '0' + day;

    return [year, month, day].join('-');
  }
}

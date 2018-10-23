import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'jornada',
  templateUrl: './jornada.component.html',
  styleUrls: ['./jornada.component.css']
})

export class JornadaComponent {
  jornadas: any[];
  private url = 'https://localhost:44322/api/jornadas';
  private baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

    this.baseUrl = baseUrl + 'api/jornadas';

    http.get(this.baseUrl)
      .subscribe(response => {
        this.jornadas = response as any[];
        //console.log(response);
      }, error => console.error(error));
  }

  createJornada(nombreJornada: HTMLInputElement) {   

    var d = new Date();
    var date = d.getDate()

    //let jornada = {
    //  nombre:"Prueba",
    //  fecha: this.formatDate_YYYYMMDD(d),
    //  abiertaAlPublico:true
    //};

    let jornada = {
      nombre: "Prueba2",
      fecha: new Date(),
      abiertaAlPublico: true
    };

    //let stringDate: string = "2018-10-09";
    
    //this.http.post(this.url, JSON.stringify(stringDate))
    //  .subscribe(response => {
    //    console.log(response);
    //  });

    this.http.post(this.url, jornada)
      .subscribe(response => {
        console.log(response);
      });
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

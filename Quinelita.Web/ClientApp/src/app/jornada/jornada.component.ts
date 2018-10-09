import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'jornada',
    templateUrl: './jornada.component.html',
    styleUrls: ['./jornada.component.css']
})

export class JornadaComponent {
  jornadas: any[];
  private url = 'http://localhost:56292/api/jornadas';

    constructor(private http:HttpClient) {

      http.get(this.url)
        .subscribe(response => {
          this.jornadas = response as any[];
          //console.log(response);
        }, error => console.error(error));
  }

  createJornada(nombreJornada: HTMLInputElement) {
    var d = new Date();
    var date = d.getDate()
    let jornada = {
      fecha: d
    };
    this.http.post(this.url, JSON.stringify(jornada))
      .subscribe(response => {
        console.log(response);
      });
  }
}

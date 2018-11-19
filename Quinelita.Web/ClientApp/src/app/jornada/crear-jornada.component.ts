import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router'

@Component({
  selector: 'crear-jornada',
  templateUrl: './crear-jornada.component.html',
  styleUrls: ['./crear-jornada.component.css']
})

export class CrearJornadaComponent {
  private url = 'https://localhost:44322/api/jornadas';
  private baseUrl: string;

  constructor(private router: Router, private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

    this.baseUrl = baseUrl + 'api/jornadas';
   
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
        //this.jornadas.splice(0, 0, jornada)
        this.router.navigateByUrl('/jornada');
        //this.router.navigate(['/user']);
        console.log(response);
      });
  }
}

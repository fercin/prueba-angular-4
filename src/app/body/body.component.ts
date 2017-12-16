import { Component, OnInit } from '@angular/core';
import { MiservicioService } from '../miservicio.service';

@Component({
  selector: 'app-body',
  templateUrl: './body.component.html',
  styleUrls: ['./body.component.css']
})
export class BodyComponent implements OnInit {
  lista: any;
  keloke: any;
  peliculas: any;
  actores: any;
  asociar: any;


  constructor(private miservicio: MiservicioService){

     this.miservicio.getpelicula().subscribe((data) => this.peliculas = data.json());
     this.miservicio.getactor().subscribe((data) => this.actores = data.json());
    //  console.log(this.actores);
    this.keloke = {
    Id: 0,
    Nombre: '',
    Apellido: ''
    };
    this.asociar = {
      id: 0,
      idpelicula: 0,
      idactor: 0
    };

    }

  ngOnInit() {}


  guardarasociar(datos){
     this.miservicio.postPeliActor(datos).subscribe(resp => console.log(resp) );
  }

}

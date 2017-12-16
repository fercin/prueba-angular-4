import { Component, OnInit } from '@angular/core';
import { MiservicioService } from '../miservicio.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-pelicula',
  templateUrl: './pelicula.component.html',
  styleUrls: ['./pelicula.component.css']
})
export class PeliculaComponent implements OnInit {

  pelicula: any;


  constructor(private miservicio: MiservicioService, private activatedroute: ActivatedRoute) {

    this.pelicula = {};

    this.activatedroute.params.subscribe(params => {

      this.miservicio.getpelicula(params.id).subscribe(data =>{
        this.pelicula = data.json();
        console.log(this.pelicula);
        console.log(this.pelicula.PeliculaActores[0]);
        // for(let actores of this.pelicula.PeliculaActores){
        //     console.log(actores.Actores.nombre);
        // }
      });

    });

   }




  ngOnInit() { }

}

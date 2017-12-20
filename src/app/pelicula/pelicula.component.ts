import { Component, OnInit } from '@angular/core';
import { MiservicioService } from '../miservicio.service';
import { ActivatedRoute, Router } from '@angular/router';
declare var $: any;
@Component({
  selector: 'app-pelicula',
  templateUrl: './pelicula.component.html',
  styleUrls: ['./pelicula.component.css']
})
export class PeliculaComponent implements OnInit {

  pelicula: any;
  actor: any;
  actorcrear: any;
  idpelicula: any;
  deleteid: any;
  constructor(private miservicio: MiservicioService, private activatedroute: ActivatedRoute, private mirouter: Router) {
    this.actorcrear = {
      id: 0,
      nombre: '',
      apellido: '',
      sexo: 'none'
    };

    this.actor = {

             id: 0,
             nombre: '',
             apellido: '',
             sexo: ''
          };
    this.pelicula = {};

    this.activatedroute.params.subscribe(params => {
      this.idpelicula = params.id;
      this.miservicio.getpelicula(params.id).subscribe(data => {
        this.pelicula = data.json();

      });

    });

   }
 ngOnInit() { }


 guardaractor(actor){
    console.log(actor);
     this.miservicio.postactor(actor, this.idpelicula).subscribe(data => {
     this.miservicio.getpelicula(this.idpelicula).subscribe(datos => {
     this.pelicula = datos.json();
     });
   });


  }


// habre modal de pregunta para eliminar
eliminar(id){
  $('#EliminarModalactor').modal('show');
  this.deleteid = id;

}

eliminarActor(){

this.miservicio.deleteactor(this.deleteid, this.idpelicula).subscribe(data => {

this.miservicio.getpelicula(this.idpelicula).subscribe(data => this.pelicula = data.json());

});

}

editar(datos){
// tslint:disable-next-line:prefer-const

this.actor = datos;

}

guardareditarActor(actor){

 this.miservicio.putactor(actor).subscribe(resp => console.log(resp));
}

verActor(id){
this.mirouter.navigate(['/actor', id]);
}




}

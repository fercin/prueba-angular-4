import { Router } from '@angular/router';
import { Http } from '@angular/http';
import { Component, OnInit } from '@angular/core';
import { MiservicioService } from '../miservicio.service';
declare var $: any;

@Component({
  selector: 'app-lista-actores',
  templateUrl: './lista-actores.component.html',
  styleUrls: ['./lista-actores.component.css']
})
export class ListaActoresComponent implements OnInit {
peliculas: any;
actor: any;
listaactor: any;
deleteid: any;
sexo: any[];



  constructor(private miservicio: MiservicioService, private mirouter: Router) {

    // Traer datos al select de peliculas
    this.miservicio.getpelicula().subscribe(data => {
      this.peliculas = data.json();


    });

    // Cargar Tabla con los actores
    this.miservicio.getactor().subscribe(data => this.listaactor = data.json());


    this.actor = {

       id: 0,
       nombre: '',
       apellido: '',
       sexo: ''
    };

    this.sexo = ['Masculino', 'Femenino'];

   }

  ngOnInit() {}


  guardaractor(actor){
    actor.sexo =  $('input[name=sexo]:checked').val();
  this.miservicio.postactor(actor).subscribe(data => {
    this.miservicio.getactor().subscribe(data => this.listaactor = data.json());
  });
  }

  // habre modal de pregunta para eliminar
  eliminar(id){
    $('#EliminarModalactor').modal('show');
    this.deleteid = id;

  }

eliminarActor(){

  this.miservicio.deleteactor(this.deleteid).subscribe(data => {

  this.miservicio.getactor().subscribe( data => this.listaactor = data.json());
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

import { Component, OnInit } from '@angular/core';
import { MiservicioService } from '../miservicio.service';
import { Router } from '@angular/router';
declare var $: any;


@Component({
  selector: 'app-lista-pelicula',
  templateUrl: './lista-pelicula.component.html',
  styleUrls: ['./lista-pelicula.component.css']
})
export class ListaPeliculaComponent implements OnInit {
pelicula: any;
listapelicula: any;
keloke: string;
deleteid: any;

  constructor(private miservicio: MiservicioService, private mirouter: Router) {

    this.miservicio.getpelicula().subscribe(data => {
      this.listapelicula = data.json();




    });

    this.pelicula = {
      id: 0,
      titulo: '',
      genero: '',
      ano: '',
      sinopsis: ''
    };


    // this.listapelicula = {
    //   titulo: '',
    //   genero: '',
    //   ano: '',
    //   sinopsis: ''
    // };

   }

  ngOnInit() { }




guardarpelicula(pelicula){
  this.miservicio.postpelicula(pelicula).subscribe(data => this.miservicio.getpelicula()
  .subscribe(data => this.listapelicula = data.json()) );
}

guardareditar(datos){
this.miservicio.putpelicula(datos).subscribe(res => this.miservicio.getpelicula().
subscribe(resp => this.listapelicula = resp.json()));
}



editar(datos){
    $('#EditarModal').modal('show');

    this.pelicula = datos;


}

eliminar(){
  this.miservicio.deletepelicula(this.deleteid).subscribe(res => this.miservicio.getpelicula()
  .subscribe(resp => this.listapelicula = resp.json()) );

}

eliminarpelicula(id){
 $('#EliminarModal').modal('show');
 this.deleteid = id;

}

verpelicula(id){
  this.mirouter.navigate(['/pelicula', id]);
}





}

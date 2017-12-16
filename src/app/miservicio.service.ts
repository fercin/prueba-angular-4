import { Injectable } from '@angular/core';
import { Http } from '@angular/http';


@Injectable()
export class MiservicioService {

  urlpelicula= 'http://localhost:31423/api/PeliculasApi/';
  urlactor = 'http://localhost:31423/api/ActoresApi/';
  urlpeliactor = 'http://localhost:31423/api/PeliActorApi/';

  constructor(private http: Http) { }

// Servicios de peliculas
getpelicula(id= ''){
 return this.http.get(this.urlpelicula + id);
}

postpelicula(objecto){
  return this.http.post(this.urlpelicula, objecto);
}
deletepelicula(objecto){
  return this.http.delete(this.urlpelicula + objecto);
}

putpelicula(objecto){
  return this.http.put(this.urlpelicula, objecto);
}

// Servicios de actor

getactor(id = ''){
  return this.http.get(this.urlactor + id);
}

postactor(objecto){
  return this.http.post(this.urlactor, objecto);
}

deleteactor(objecto){
  return this.http.delete(this.urlactor + objecto);
}
putactor(objecto){
  return this.http.put(this.urlactor,objecto);
}


postPeliActor(objecto){
  return this.http.post(this.urlpeliactor, objecto);
}




}




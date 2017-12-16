import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

// SERVICIOS
import { MiservicioService } from './miservicio.service';

// RUTAS
import { LISTAROUTES } from './app.routes';

import { AppComponent } from './app.component';
import { ListaPeliculaComponent } from './lista-pelicula/lista-pelicula.component';
import { ListaActoresComponent } from './lista-actores/lista-actores.component';
import { BodyComponent } from './body/body.component';
import { PeliculaComponent } from './pelicula/pelicula.component';
import { ActorComponent } from './actor/actor.component';






@NgModule({
  declarations: [
    AppComponent,
    ListaPeliculaComponent,
    ListaActoresComponent,
    BodyComponent,
    PeliculaComponent,
    ActorComponent,

  ],
  imports: [
    BrowserModule,
    HttpModule,
    FormsModule,
    RouterModule,
    LISTAROUTES
  ],
  providers: [MiservicioService],
  bootstrap: [AppComponent]
})
export class AppModule { }

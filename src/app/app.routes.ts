
import { Routes, RouterModule } from '@angular/router';
// componentes
import { BodyComponent } from './body/body.component';
import { ListaActoresComponent } from './lista-actores/lista-actores.component';
import { ListaPeliculaComponent } from './lista-pelicula/lista-pelicula.component';
import { PeliculaComponent } from './pelicula/pelicula.component';
import { ActorComponent } from './actor/actor.component';

const routes: Routes = [



  { path: 'home', component: BodyComponent},
  { path: 'pelicula/:id', component: PeliculaComponent},
  { path: 'actor/:id', component: ActorComponent},
  { path: '**',  pathMatch: 'full', redirectTo: 'home' }



  // { path: 'path/:routeParam', component: MyComponent },
  // { path: 'staticPath', component: ... },
  // { path: '**', component: ... },
  // { path: 'oldPath', redirectTo: '/staticPath' },
  // { path: ..., component: ..., data: { message: 'Custom' }
];


export const LISTAROUTES = RouterModule.forRoot(routes);

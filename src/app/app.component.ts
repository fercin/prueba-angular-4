
import { Component } from '@angular/core';
import { MiservicioService } from './miservicio.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {




// tslint:disable-next-line:one-line
constructor(private miservicio: MiservicioService){


}




}


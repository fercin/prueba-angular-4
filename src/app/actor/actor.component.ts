import { ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { MiservicioService } from '../miservicio.service';

@Component({
  selector: 'app-actor',
  templateUrl: './actor.component.html',
  styleUrls: ['./actor.component.css']
})
export class ActorComponent implements OnInit {

  actor: any;


  constructor(private miservicio: MiservicioService, private activerouter: ActivatedRoute) {

    this.actor = {};

    this.activerouter.params.subscribe(params => {
      this.miservicio.getactor(params.id).subscribe(data =>this.actor = data.json() );

    });

   }




  ngOnInit() {}

}

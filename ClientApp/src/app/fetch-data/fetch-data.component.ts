import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SignalRService } from '../Services/SignalR/signalR.service';
import { SuperHeroService } from '../Services/ApiService/SuperHero.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent implements OnInit {
  public heros: any[];
  public notification$: Observable<any>;
  public tempHeros: any[];
  constructor(private _apiService: SuperHeroService, private _signalR: SignalRService) {

    this.notification$ = this._signalR.notification$;
  }


  ngOnInit() {

    this.notification$.subscribe(res => {

      if (res[0] === undefined) {
        console.log("not working");
      }
      else {
        this.tempHeros = [];
        this.tempHeros = res;
      }
      this.heros = this.tempHeros;
    });
    this.getAllHeros();
  }




  getAllHeros() {
    this._apiService.GetAllHeros().subscribe(results => {
      this.heros = results;
    }, error => {
      console.log(error);
    });

  }


}



import { Component } from '@angular/core';
import { SignalRService } from './Services/SignalR/signalR.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';
  constructor(private _signalR: SignalRService) {
    this._signalR.startConnection();
  }






}

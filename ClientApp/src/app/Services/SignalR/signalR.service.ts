import { Injectable } from '@angular/core';
import * as signalR from "@microsoft/signalr";
import { BehaviorSubject, Subject } from 'rxjs';
import { SuperHeroService } from '../ApiService/SuperHero.service';


@Injectable({
  providedIn: 'root'
})
export class SignalRService {

  constructor(private _apiService: SuperHeroService) {
  }
  private hubConnection: signalR.HubConnection;
  private notificationSubject = new Subject<Array<string>>();
  public notification$ = this.notificationSubject.asObservable();

  public startConnection = () => {

    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('/notificationHub', {
        skipNegotiation: true,
        transport: signalR.HttpTransportType.WebSockets
      })
      .withAutomaticReconnect()
      .build();

    this.hubConnection.on('ReceiveMessage', (data) => {
      alert(data + " " + "joined Avengers");
      this._apiService.GetAllHeros().subscribe(res => {
        var userNotifications = res;
        this.notificationSubject.next(userNotifications);
      },
        err => {
          console.log(err);
        });
    });
    this.hubConnection
      .start()
      .then(() => {
        console.log('Connection started');
      })
      .catch(err => {
        console.log('Error while starting connection: ' + err);
      });
  }

  public disconnect(): void {
    if (typeof this.hubConnection !== 'undefined') {
      this.hubConnection.stop()
        .catch(err => console.log('Error while stopping connection: ' + err));
    }

  }


}

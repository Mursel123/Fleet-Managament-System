import { Injectable, inject } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';
import { Observable, Subject } from 'rxjs';
import { SignalR } from '../models/config/signalr';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class SignalrService {

  private signalr: SignalR | null = null; 
  private http = inject(HttpClient);
  private hubConnection: HubConnection | null = null; 
  private messageSubject = new Subject<string>();

  constructor() {
    this.readConfig().subscribe(signalrConfig => {
      this.signalr = signalrConfig;
      this.setupHubConnection();
    });
  }

  private setupHubConnection(): void {
    if (this.signalr && this.signalr.hub && this.signalr.hub.endpoint) {
      this.hubConnection = new HubConnectionBuilder()
        .withUrl(`${environment.signalr}${this.signalr.hub.endpoint}`)
        .build();

      this.hubConnection.start().catch(err => console.error(err));

      this.hubConnection.on(this.signalr.hub.method.name, (message: string) => {
        this.messageSubject.next(message);
      });
    } else {
      console.error('Invalid SignalR configuration');
    }
  }

  readConfig(): Observable<SignalR> {
    return this.http.get<SignalR>(`${environment.readApiUrl}/Config/signalr`);
  }

  getMessageSubject(): Observable<string> {
    return this.messageSubject.asObservable();
  }
}

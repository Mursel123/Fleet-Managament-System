import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http'
import { Voertuig } from '../models/voertuig';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { VoertuigSelectList } from '../models/voertuig-selectlist';

@Injectable({
  providedIn: 'root'
})
export class VoertuigService {

  constructor(private http: HttpClient) { }

  readVoertuigen() : Observable<Voertuig[]>{
    return this.http.get<Voertuig[]>(`${environment.readApiUrl}/Voertuig/all`)
    }

  readVoertuigById(id: string) : Observable<Voertuig>{
    return this.http.get<Voertuig>(`${environment.readApiUrl}/Voertuig/${id}`)
    }

  readVoertuigenSelectList(): Observable<VoertuigSelectList[]>{
    return this.http.get<VoertuigSelectList[]>(`${environment.readApiUrl}/voertuig/all/selectlist`)
  }
}

import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { GemeldeSchadeSelectList } from '../models/gemeldeSchade-selectlist';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class GemeldeSchadeService {

  private http = inject(HttpClient)

  readGemeldeSchadeSelectList() : Observable<GemeldeSchadeSelectList[]>{
    return this.http.get<GemeldeSchadeSelectList[]>(`${environment.readApiUrl}/GemeldeSchade/all/selectlist`)
    }
}

import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';
import { GarageSelectList } from '../models/garage-selectlist';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class GarageService {

  private http = inject(HttpClient)

  readGaragesSelectList() : Observable<GarageSelectList[]>{
    return this.http.get<GarageSelectList[]>(`${environment.readApiUrl}/Garage/all/selectlist`)
    }
}

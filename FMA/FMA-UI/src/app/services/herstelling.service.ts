import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { CreateHerstelling } from '../models/herstelling-create';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HerstellingService {

  private http = inject(HttpClient)

  createHerstelling(herstelling: CreateHerstelling) : Observable<string>{
    return this.http.post<string>(`${environment.writeApiUrl}/Herstelling`, herstelling)
  }
}
